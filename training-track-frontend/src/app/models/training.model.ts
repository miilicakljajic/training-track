export enum ExerciseType {
    CARDIO = 0,
    STRENGTH_TRAINING = 1,
    FLEXIBILITY = 2
}
  
export interface Training {
    Id: number,
    Type: ExerciseType
    Duration: string,
    BurnedCalories: number,
    Difficulty: number,
    Fatique: number,
    Note: string,
    DateTime: Date,
    UserId: number
}