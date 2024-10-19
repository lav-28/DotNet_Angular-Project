import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { UpdateDegree } from 'src/app/models/update-degree.model';
import { DegreeService } from 'src/app/services/degree.service';

@Component({
  selector: 'app-degree-update',
  templateUrl: './degree-update.component.html',
  styleUrls: ['./degree-update.component.css']
})
export class DegreeUpdateComponent implements OnInit{
  degreeId: number | undefined;
  degree : UpdateDegree = {
    degreeId: 0,
    degreeName: '',
    degreeDescription: ''
  };
  loading: boolean = false

  constructor(private degreeService: DegreeService, private router : Router,private route :ActivatedRoute){}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.degreeId = params['id'];
      this.loadCategoryDetails(this.degreeId);
    });
   }
  
  loadCategoryDetails(degreeId:number | undefined): void{
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

   onSubmit(updateDegreeForm: NgForm){
    if(updateDegreeForm.valid){
      this.loading = true;
      console.log('form submitted',updateDegreeForm.value)
      let updateDegree: UpdateDegree={
        degreeId: updateDegreeForm.controls['degreeId'].value,
        degreeName: updateDegreeForm.controls['degreeName'].value,
        degreeDescription: updateDegreeForm.controls['degreeDescription'].value,
      };
      this.degreeService.UpdateDegree(updateDegree).subscribe({
        next:(response) =>{
          if(response.success){
            this.router.navigate(['/degrees']);
          }
          else{
            alert(response.message);
          }
          this.loading = false;
        },
        error:(err) => {
          console.log(err.error.message);
          alert(err.error.message);
          this.loading=false;
        },
        complete:() =>{
          this.loading = false;
          console.log("completed");
        }
      });
    }
  }
}
