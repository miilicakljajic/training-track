import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { TrainingCreateComponent } from './components/training-create/training-create.component';
import { TrainingStatisticsComponent } from './components/training-statistics/training-statistics.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { AuthGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home-page', component: HomePageComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'training/create', component: TrainingCreateComponent, canActivate: [AuthGuard] },
  { path: 'training/statistics', component: TrainingStatisticsComponent, canActivate: [AuthGuard] },
];
