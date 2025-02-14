import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainingStatisticsComponent } from './training-statistics.component';

describe('TrainingStatisticsComponent', () => {
  let component: TrainingStatisticsComponent;
  let fixture: ComponentFixture<TrainingStatisticsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TrainingStatisticsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TrainingStatisticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
