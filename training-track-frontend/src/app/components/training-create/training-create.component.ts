import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatRadioModule } from '@angular/material/radio';
import { MatSliderModule } from '@angular/material/slider';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { ReactiveFormsModule } from '@angular/forms';
import { ExerciseType, Training } from '../../models/training.model';
import { TrainingService } from '../../services/training.service';
import { Jwt } from '../../models/jwt.model';

@Component({
  selector: 'app-training-create',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatRadioModule,
    MatSliderModule,
    MatDatepickerModule,
    MatNativeDateModule,
    ReactiveFormsModule,
  ],
  templateUrl: './training-create.component.html',
  styleUrl: './training-create.component.css'
})
export class TrainingCreateComponent {
  trainingForm: FormGroup;
  exerciseTypes = Object.entries(ExerciseType)
  .filter(([key, value]) => typeof value === 'number')
  .map(([key, value]) => key);

  training: Training = {
    Id: 0,
    Type: ExerciseType.CARDIO,
    Duration: '',
    BurnedCalories: 0,
    Difficulty: 0,
    Fatique: 0,
    Note: '',
    DateTime: new Date(),
    UserId: 0
  }

  constructor(private formBuilder: FormBuilder, private snackBar: MatSnackBar, private trainingService: TrainingService) {
    this.trainingForm = this.formBuilder.group({
      exerciseType: [ExerciseType.CARDIO, Validators.required],
      duration: [null, Validators.required],
      burnedCalories: [null, [Validators.required, Validators.min(1)]],
      difficulty: [1, Validators.required],
      fatique: [1, Validators.required],
      note: [''],
      dateTime: [null, Validators.required]
    })
  }

  get difficultyControl(): FormControl {
    return this.trainingForm.get('difficulty') as FormControl;
  }
  
  get fatiqueControl(): FormControl {
    return this.trainingForm.get('fatique') as FormControl;
  }

  onSubmit() {
    if(this.trainingForm.valid) {
      this.training.Type = ExerciseType[this.trainingForm.value["exerciseType"] as keyof typeof ExerciseType];
      this.training.Duration = this.trainingForm.value["duration"].toString();;
      this.training.BurnedCalories = this.trainingForm.value["burnedCalories"];
      this.training.Note = this.trainingForm.value["note"];
      this.training.DateTime = this.trainingForm.value["dateTime"];

      this.trainingService.createTraining(this.training).subscribe({
        next: (result: Training) => {
          this.snackBar.open('Training is successfully added!', 'Close', {
            duration: 3000
          });
        },

        error: (error) => {
          this.snackBar.open('Failed to add this workout!', 'Close', {
            duration: 3000
          });
        }
      })
    }
  }
}
