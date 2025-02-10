import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../models/login.model';
import { Observable } from 'rxjs';
import { Register } from '../models/register.model';
import { Jwt } from '../models/jwt.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private router: Router) { }

  login(login: Login): Observable<Jwt> {
    return this.http.post<Jwt>("https://localhost:7149/Auth/login", login);
  }
  
  register(register: Register): Observable<Jwt> {
    return this.http.post<Jwt>("https://localhost:7149/Auth/register", register);
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('jwt');
  }

  logout(): void {
    localStorage.removeItem('jwt');
  }
}
