import { Routes } from '@angular/router';
import { WeatherComponent } from './components/weather/weather.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { TrainingCreateComponent } from './components/training-create/training-create.component';

export const routes: Routes = [
  { path: 'weather', component: WeatherComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'training/create', component: TrainingCreateComponent },
];
