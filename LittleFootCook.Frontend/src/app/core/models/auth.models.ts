// auth.models.ts
export interface RegisterDto {
  email: string;
  password: string;
  username: string;
}

export interface LoginDto {
  email: string;
  password: string;
}

export interface AuthResponse {
  token: string;
  email: string;
  username: string;
  expiresAt: string;
}
