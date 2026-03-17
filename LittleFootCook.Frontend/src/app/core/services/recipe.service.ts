import { Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { RecipeDto, CreateRecipeDto } from '../models';

@Injectable({
  providedIn: 'root',
})
export class RecipeService {
  private apiUrl = 'http://localhost:5228/api/recipes';

  recipes = signal<RecipeDto[]>([]);

  constructor(private http: HttpClient) {}

  async getAll(): Promise<RecipeDto[]> {
    const result = await firstValueFrom(this.http.get<RecipeDto[]>(this.apiUrl));
    this.recipes.set(result);
    return result;
  }

  async getById(id: string): Promise<RecipeDto> {
    return await firstValueFrom(this.http.get<RecipeDto>(`${this.apiUrl}/${id}`));
  }

  async create(dto: CreateRecipeDto): Promise<RecipeDto> {
    const result = await firstValueFrom(this.http.post<RecipeDto>(this.apiUrl, dto));
    this.recipes.update((recipes) => [...recipes, result]);
    return result;
  }

  async delete(id: string): Promise<void> {
    await firstValueFrom(this.http.delete(`${this.apiUrl}/${id}`));
    this.recipes.update((recipes) => recipes.filter((r) => r.id !== id));
  }
}
