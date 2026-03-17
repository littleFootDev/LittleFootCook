import { Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { AuthResponse, LoginDto, RegisterDto } from '../models';

Injectable({
  providedIn: 'root',
});
export class AuthService {
  private apiUrl = 'http://localhost:5228/api/auth';

  // Signals pour l'état
  isLoggedIn = signal<boolean>(!!localStorage.getItem('token'));
  username = signal<string | null>(localStorage.getItem('username'));

  constructor(private http: HttpClient) {}

  async register(dto: RegisterDto): Promise<AuthResponse> {
    const response = await firstValueFrom(
      this.http.post<AuthResponse>(`${this.apiUrl}/register`, dto),
    );
    this.saveToken(response);
    return response;
  }

  async login(dto: LoginDto): Promise<AuthResponse> {
    const response = await firstValueFrom(
      this.http.post<AuthResponse>(`${this.apiUrl}/login`, dto),
    );
    this.saveToken(response);
    return response;
  }

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    this.isLoggedIn.set(false);
    this.username.set(null);
  }

  private saveToken(response: AuthResponse): void {
    localStorage.setItem('token', response.token);
    localStorage.setItem('username', response.username);
    this.isLoggedIn.set(true);
    this.username.set(response.username);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }
}
