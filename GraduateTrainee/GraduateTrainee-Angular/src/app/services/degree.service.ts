import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiResponse } from '../models/ApiResponse{T}';
import { Observable } from 'rxjs';
import { Degree } from '../models/degree.model';
import { Router } from '@angular/router';
import { AddDegree } from '../models/add-degree.model';
import { UpdateDegree } from '../models/update-degree.model';

@Injectable({
  providedIn: 'root'
})
export class DegreeService {
  private apiUrl = 'http://localhost:5134/api/Degree/';
  constructor(private http: HttpClient,private router : Router) { }

  getAllDegrees():Observable<ApiResponse<Degree[]>>{
    return this.http.get<ApiResponse<Degree[]>>(this.apiUrl+"GetAll")
  }

  getDegreeById(degreeId: number | undefined):Observable<ApiResponse<Degree>>{
    return this.http.get<ApiResponse<Degree>>(this.apiUrl+"GetDegreeById/"+degreeId)
  }

  AddDegree(addDegree: AddDegree): Observable<ApiResponse<string>>{
    return this.http.post<ApiResponse<string>>(this.apiUrl+"Create",addDegree);
  }

  UpdateDegree(updateDegree : UpdateDegree): Observable<ApiResponse<string>>{
    return this.http.put<ApiResponse<string>>(this.apiUrl+"ModifyDegree",updateDegree);
  }

  deleteDegreeById(degreeId: number | undefined):Observable<ApiResponse<string>>{
    return this.http.delete<ApiResponse<string>>(this.apiUrl+"Remove/"+degreeId)
  }
}
