import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Degree } from 'src/app/models/degree.model';
import { DegreeService } from 'src/app/services/degree.service';

@Component({
  selector: 'app-degree-details',
  templateUrl: './degree-details.component.html',
  styleUrls: ['./degree-details.component.css']
})
export class DegreeDetailsComponent implements OnInit{
  degreeId: number | undefined;
  degree : Degree={
    degreeId: 0,
    degreeName : '',
    degreeDescription : '' 
  };

  constructor(private degreeService: DegreeService,private route : ActivatedRoute){ }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.degreeId = params['id'];
      this.loadDegreeDetails(this.degreeId);
    });
   }

  loadDegreeDetails(degreeId:number | undefined): void{
    this.degreeService.getDegreeById(degreeId).subscribe({
      next:(response) =>{
        if(response.success){
          this.degree = response.data;
        }
        else{
          console.error('Failed to fetch degree: ',response.message);
        }
      },
      error:(err) =>{
        alert(err.error.message);
      },
      complete:()=>{
        console.log("completed");
      }
    })
   };


}
