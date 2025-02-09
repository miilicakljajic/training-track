import { Routes } from '@angular/router';
import { WeatherComponent } from './components/weather/weather.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { TrainingCreateComponent } from './components/training-create/training-create.component';
import { TrainingStatisticsComponent } from './components/training-statistics/training-statistics.component';
import { HomePageComponent } from './components/home-page/home-page.component';

export const routes: Routes = [
  { path: 'weather', component: WeatherComponent },
  { path: 'home-page', component: HomePageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'training/create', component: TrainingCreateComponent },
  { path: 'training/statistics', component: TrainingStatisticsComponent },
];
