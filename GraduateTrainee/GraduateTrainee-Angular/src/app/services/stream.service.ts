import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/ApiResponse{T}';
import { Stream } from '../models/stream.model';
import { AddStream } from '../models/add-stream.model';
import { UpdateStream } from '../models/update-stream.model';

@Injectable({
  providedIn: 'root'
})
export class StreamService {

  private apiUrl = 'http://localhost:5134/api/Steam/';
  constructor(private http: HttpClient,private router : Router) { }

  getAllStreams():Observable<ApiResponse<Stream[]>>{
    return this.http.get<ApiResponse<Stream[]>>(this.apiUrl+"GetAllStream")
  }

  getStreamById(streamId: number | undefined): Observable<ApiResponse<Stream>> {
    return this.http.get<ApiResponse<Stream>>(this.apiUrl + 'GetStreamById/' + streamId);
  }

  AddStream(addStream: AddStream): Observable<ApiResponse<string>>{
    return this.http.post<ApiResponse<string>>(this.apiUrl+"Create",addStream);
  }

  UpdateStream(updateStream : UpdateStream): Observable<ApiResponse<string>>{
    return this.http.put<ApiResponse<string>>(this.apiUrl+"ModifyStream",updateStream);
  }

  deleteStreamById(streamId: number | undefined):Observable<ApiResponse<string>>{
    return this.http.delete<ApiResponse<string>>(this.apiUrl+"Remove/"+streamId)
  }

  getStreamByDergreeId(degreeId: number | undefined): Observable<ApiResponse<Stream[]>> {
    return this.http.get<ApiResponse<Stream[]>>(this.apiUrl + 'GetStreamByDegreeId/' + degreeId);
  }
}
