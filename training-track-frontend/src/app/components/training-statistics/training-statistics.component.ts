import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatChipsModule } from '@angular/material/chips';
import { Week } from '../../models/week.model';
import { TrainingService } from '../../services/training.service';
import { MatDividerModule } from '@angular/material/divider';

@Component({
  selector: 'app-training-statistics',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule, 
    MatButtonModule,
    MatExpansionModule,
    MatChipsModule,
    MatDividerModule
  ],
  templateUrl: './training-statistics.component.html',
  styleUrl: './training-statistics.component.css'
  
})
export class TrainingStatisticsComponent {
  selectedMonth: string = '';
  months: string[] = [
    'January', 'February', 'March', 'April', 'May', 'June', 'July', 
    'August', 'September', 'October', 'November', 'December'
  ];
  weeks : Week[] = [];

  constructor(private trainingService: TrainingService) {}

  selectMonth(month: string) {
    this.selectedMonth = month;

    this.trainingService.getTrainingsPerWeek(this.months.findIndex(m => m == month) + 1).subscribe({
      next: (result: Week[]) => {
        this.weeks = result;
      },

      error: (error) => {
        console.log(error);
      }
    })
  }
}
