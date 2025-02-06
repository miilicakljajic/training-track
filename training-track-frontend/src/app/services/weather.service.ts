import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WeatherForecast } from '../models/weather-forecast.model';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  private apiUrl = 'https://localhost:7149/WeatherForecast';

  constructor(private http: HttpClient) { }

  getWeather(): Observable<WeatherForecast[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}
