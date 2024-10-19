import { NgModel } from "@angular/forms"

export interface AddGraduateTrainee{
    degreeId: number,
    streamId: number,
    traineeName: string,
    traineeEmail: string,
    universityName: string,
    isLastSemesterPending: boolean,
    gender: string,
    dateOfApplication: Date,
    image: string,
    ai:number,
    phyton: number,
    businessAnalysis: number,
    machineLearning: number,
    practical: number,
    totalMarks: number,
    percentages: number,
    isAdmisisonConfirmed: boolean
}