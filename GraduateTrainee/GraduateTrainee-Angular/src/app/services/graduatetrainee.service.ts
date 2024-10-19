import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/ApiResponse{T}';
import { GraduateTrainee } from '../models/graduatetrainee.model';
import { AddGraduateTrainee } from '../models/add-graduatetrainee.model';
import { UpdateGraduateTrainee } from '../models/update-graduatetrainee.model';

@Injectable({
  providedIn: 'root'
})
export class GraduatetraineeService {

  private apiUrl = 'http://localhost:5134/api/GraduateTrainee/';
  constructor(private http: HttpClient,private router : Router) { }

  getAllTrainees():Observable<ApiResponse<GraduateTrainee[]>>{
    return this.http.get<ApiResponse<GraduateTrainee[]>>(this.apiUrl+'GetAll')
  }

  getTraineeById(traineeId: number | undefined):Observable<ApiResponse<GraduateTrainee>>{
    return this.http.get<ApiResponse<GraduateTrainee>>(this.apiUrl+"GetById/"+traineeId)
  }

  AddTrainee(addTrainee: AddGraduateTrainee): Observable<ApiResponse<string>>{
    return this.http.post<ApiResponse<string>>(this.apiUrl+"AddTrainee",addTrainee);
  }

  UpdateTrainee(updateTrainee: UpdateGraduateTrainee): Observable<ApiResponse<string>>{
    return this.http.put<ApiResponse<string>>(this.apiUrl+"UpdateTrainee",updateTrainee);
  }

  deleteTraineeById(traineeId: number | undefined):Observable<ApiResponse<string>>{
    return this.http.delete<ApiResponse<string>>(this.apiUrl+"Remove/"+traineeId)
  }
}
