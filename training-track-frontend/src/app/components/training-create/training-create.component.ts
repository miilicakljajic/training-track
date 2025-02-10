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
import { MatChipsModule } from '@angular/material/chips';
import { NgxMaskDirective } from 'ngx-mask';

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
    MatChipsModule,
    NgxMaskDirective,
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
    id: 0,
    type: ExerciseType.CARDIO,
    duration: '',
    burnedCalories: 0,
    difficulty: 0,
    fatique: 0,
    note: '',
    dateTime: new Date(),
    userId: 0
  }

  selectedType: ExerciseType = ExerciseType.CARDIO;
  selectedTypeString : string = "";
  types: string[] = [
    'Cardio', 'Strength workout', 'Flexibility'
  ]
  duration: string = "";
  trainingTime: string = "";

  constructor(private formBuilder: FormBuilder, private snackBar: MatSnackBar, private trainingService: TrainingService) {
    this.trainingForm = this.formBuilder.group({
      exerciseType: [ExerciseType.CARDIO, Validators.required],
      duration: [null, Validators.required],
      burnedCalories: [null, [Validators.required, Validators.min(1)]],
      difficulty: [1, Validators.required],
      fatique: [1, Validators.required],
      note: [''],
      dateTime: [null, Validators.required],
      trainingTime: ['', Validators.required]
    })
  }

  get difficultyControl(): FormControl {
    return this.trainingForm.get('difficulty') as FormControl;
  }
  
  get fatiqueControl(): FormControl {
    return this.trainingForm.get('fatique') as FormControl;
  }

  selectType(type: string) {
    this.selectedTypeString = type;
    if(type === "Cardio")
      this.selectedType = ExerciseType.CARDIO;
    if(type === "Strength workout")
      this.selectedType = ExerciseType.STRENGTH_TRAINING;
    if(type === "Flexibility")
      this.selectedType = ExerciseType.FLEXIBILITY;
  }

  onSubmit() {
    let dur: string = this.trainingForm.value["duration"].toString();
    let newStr = dur.slice(0, 2) + ':' + dur.slice(2, 4) + ":00";
    if(this.trainingForm.valid) {
      let selectedDate: Date = this.trainingForm.value["dateTime"];
      let selectedTime: string = this.trainingForm.value["trainingTime"];

      if (selectedDate && selectedTime) {
        selectedTime = selectedTime.slice(0,2) + ":" + selectedTime.slice(2,4);
        let [hours, minutes] = selectedTime.split(":").map(Number);
        selectedDate.setHours(hours, minutes, 0); 
      }

      this.training.type = this.selectedType;
      this.training.duration = newStr;
      this.training.burnedCalories = this.trainingForm.value["burnedCalories"];
      this.training.note = this.trainingForm.value["note"];
      this.training.dateTime = selectedDate;

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
