import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { WeatherForecast } from '../../models/weather-forecast.model';
import { WeatherService } from '../../services/weather.service';

@Component({
  selector: 'app-weather',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './weather.component.html',
  styleUrl: './weather.component.css'
})
export class WeatherComponent {
  forecasts : WeatherForecast[] = [];

  constructor(private weatherService : WeatherService) {
    this.weatherService.getWeather().subscribe({
      next: (result: WeatherForecast[]) => {
        this.forecasts = result;
      },
      error: (error) => {
        console.error('Error fetching weather data:', error);
      }
    });
    
  }
}
