import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Login } from '../../models/login.model';
import { Jwt } from '../../models/jwt.model';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    ReactiveFormsModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;
  hidePassword = true;

  constructor(private formBuilder: FormBuilder, private snackBar: MatSnackBar, private authService: AuthService) {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }

  togglePasswordVisibility() {
    this.hidePassword = !this.hidePassword;
  }

  onSubmit() {
    if(this.loginForm.valid) {
      let login: Login = {
        Email: this.loginForm.value["email"],
        Password: this.loginForm.value["password"]
      }

      this.authService.login(login).subscribe({
        next: (result: Jwt) => {
          localStorage.setItem("jwt", result.token);
          this.snackBar.open('Successfully logged in', 'Close', {
            duration: 3000
          });
        },

        error: (error) => {
          this.snackBar.open('Failed to log in', 'Close', {
            duration: 3000
          });
        }
      })
    }
  }
}
