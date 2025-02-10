import { Training } from "./training.model";

export interface Week {
    weekNumber: number,
    startOfWeek: Date,
    endOfWeek: Date,
    trainings: Training[],
    numOfTrainings: 0,
    totalDuration: string,
    averageDifficulty: number,
    averageFatique: number
}