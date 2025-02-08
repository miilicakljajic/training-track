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
import { Register } from '../../models/register.model';
import { AuthService } from '../../services/auth.service';
import { Jwt } from '../../models/jwt.model';

@Component({
  selector: 'app-register',
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
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  registerForm: FormGroup;
  hidePassword = true;

  register: Register = {
    Email: "",
    Password: "",
  }

  constructor(private formBuilder: FormBuilder, private snackBar:  MatSnackBar, private authService: AuthService) {
    this.registerForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]]
    });
  }

  togglePasswordVisibility() {
    this.hidePassword = !this.hidePassword;
  }

  onSubmit() {
    if(this.registerForm.valid) {
      this.authService.register(this.register).subscribe({
        next: (result: Jwt) => {
          this.snackBar.open('Successfully registered!', 'Close', {
            duration: 3000
          })
        },

        error: (error) => {
          this.snackBar.open('Failed to register', 'Close', {
            duration: 3000
          })
        }
      })
    }
  }
}