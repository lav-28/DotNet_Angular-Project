import { GraduateTraineeStream } from "./graduaetrainee.stream.model";
import { GraduateTraineeDegree } from "./graduatetrainee.degree.model";

export interface GraduateTrainee{
    graduateTraineeId: number,
    degreeId: number,
    streamId: number,
    traineeName: string,
    traineeEmail: string,
    universityName: string,
    isLastSemesterPending: boolean,
    gender: string,
    dateOfApplication: Date,
    image: string,
    ai: number,
    phyton: number,
    businessAnalysis: number,
    machineLearning: number,
    practical: number,
    totalMarks: number,
    percentages: number,
    isAdmisisonConfirmed: boolean,
    degree: GraduateTraineeDegree,
    stream: GraduateTraineeStream
}