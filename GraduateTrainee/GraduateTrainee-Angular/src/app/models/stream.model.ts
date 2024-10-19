import { StreamDegree } from "./stream.degree.model";

export interface Stream{
    streamId: number,
    streamName: string,
    streamDescription: string,
    degreeId: number,
    degree: StreamDegree
}