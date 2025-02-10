export enum ExerciseType {
    CARDIO = 0,
    STRENGTH_TRAINING = 1,
    FLEXIBILITY = 2
}
  
export interface Training {
    id: number,
    type: ExerciseType
    duration: string,
    burnedCalories: number,
    difficulty: number,
    fatique: number,
    note: string,
    dateTime: Date,
    userId: number
}