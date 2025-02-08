import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Training } from '../models/training.model';
import { Observable } from 'rxjs';
import { Jwt } from '../models/jwt.model';

@Injectable({
  providedIn: 'root'
})
export class TrainingService {

  constructor(private http: HttpClient) { }

  createTraining(training: Training): Observable<Training> {
    return this.http.post<Training>("https://localhost:7149/training", training);
  }
}
