import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiResponse } from 'src/app/models/ApiResponse{T}';
import { GraduateTrainee } from 'src/app/models/graduatetrainee.model';
import { GraduatetraineeService } from 'src/app/services/graduatetrainee.service';

@Component({
  selector: 'app-graduatetrainee-list',
  templateUrl: './graduatetrainee-list.component.html',
  styleUrls: ['./graduatetrainee-list.component.css']
})
export class GraduatetraineeListComponent implements OnInit{
  trainees: GraduateTrainee[] | undefined;
  graduateTraineeId!:number;
  loading: boolean = false;

  constructor(private graduateTraineeService: GraduatetraineeService,private router : Router){ }

  ngOnInit(): void {
    this.loadTrainees();
  }

  loadTrainees(): void{
    this.loading = true;
    this.graduateTraineeService.getAllTrainees().subscribe({
      next: (response: ApiResponse<GraduateTrainee[]>) =>{
        if(response.success){
          this.trainees = response.data;
        }
        else{
          console.error('Failed to fetch Graduate trainees: ',response.message);
        }
        this.loading = false; 
      },
        error:(error) =>{
          console.error('Error fetching Graduate trainees: ',error);
          this.loading = false;
      }
    })
  };

  confirmDelete(id : number): void{
    if(confirm('Are you sure?')){
      this.graduateTraineeId = id;
      this.deleteTrainee();
    }
  };

  deleteTrainee(): void{
    this.graduateTraineeService.deleteTraineeById(this.graduateTraineeId).subscribe({
      next:(response) => {
        if(response.success){
          this.loadTrainees();
        }
        else{
          alert(response.message);
        }
      },
      error: (err) =>{
        alert(err.error.message);
      },
      complete:() =>{
        console.log('Completed')
      }
    });
  }

  traineeDetails(id:number): void{
    this.router.navigate(['graduate-trainee/details/', id])
  }

  traineeUpdate(id: number): void{
    this.router.navigate(['graduate-trainee/update/',id])
  }
}
