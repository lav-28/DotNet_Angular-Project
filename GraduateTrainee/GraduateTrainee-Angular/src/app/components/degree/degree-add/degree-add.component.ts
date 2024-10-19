import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AddDegree } from 'src/app/models/add-degree.model';
import { DegreeService } from 'src/app/services/degree.service';

@Component({
  selector: 'app-degree-add',
  templateUrl: './degree-add.component.html',
  styleUrls: ['./degree-add.component.css']
})
export class DegreeAddComponent {
  degree: AddDegree = {
    degreeName: '',
    degreeDescription: ''
  };

  loading: boolean = false;

  constructor(private degreeService: DegreeService, private router : Router){}

  onSubmit(addDegreeform: NgForm){
    if(addDegreeform.valid){
      this.loading = true;
      console.log('form submitted',addDegreeform.value)
      let addDegree: AddDegree={
        degreeName: addDegreeform.controls['degreeName'].value,
        degreeDescription: addDegreeform.controls['degreeDescription'].value,
      };
      this.degreeService.AddDegree(addDegree).subscribe({
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
