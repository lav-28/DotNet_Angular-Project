import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiResponse } from 'src/app/models/ApiResponse{T}';
import { Degree } from 'src/app/models/degree.model';
import { DegreeService } from 'src/app/services/degree.service';

@Component({
  selector: 'app-degree-list',
  templateUrl: './degree-list.component.html',
  styleUrls: ['./degree-list.component.css']
})
export class DegreeListComponent implements OnInit{
  degrees: Degree[] | undefined;
  degreeId: number | undefined; 
  loading: boolean = false;

  constructor(private degreeService: DegreeService, private router : Router){}

  ngOnInit(): void {
    this.loadDegrees();
  };

  loadDegrees(): void{
    this.loading = true;
    this.degreeService.getAllDegrees().subscribe({
      next:(response: ApiResponse<Degree[]>) =>{
        if(response.success){
          this.degrees = response.data;
        }
        else{
          console.error('Failed to fetch degrees ', response.message);
        }
        this.loading = false;
      },error:(error)=>{
        console.error('Error fetching degrees : ',error);
        this.loading = false;
      }
    });
  };

  confirmDelete(id : number): void{
    if(confirm('Are you sure?')){
      this.degreeId = id;
      this.deleteDegree();
    }
  }

  deleteDegree(): void{
    this.degreeService.deleteDegreeById(this.degreeId).subscribe({
      next:(response) => {
        if(response.success){
          this.loadDegrees();
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
  };

  degreeDetails(id:number): void{
    this.router.navigate(['degrees/details/', id])
  };

  degreeUpdate(id:number): void{
    this.router.navigate(['degree/update/', id])
  }

}
