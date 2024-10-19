import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiResponse } from 'src/app/models/ApiResponse{T}';
import { AddStream } from 'src/app/models/add-stream.model';
import { Degree } from 'src/app/models/degree.model';
import { DegreeService } from 'src/app/services/degree.service';
import { StreamService } from 'src/app/services/stream.service';

@Component({
  selector: 'app-stream-add',
  templateUrl: './stream-add.component.html',
  styleUrls: ['./stream-add.component.css']
})
export class StreamAddComponent {
  stream : AddStream ={
    streamName: '',
    streamDescription: '',
    degreeId: 0,
  };
  degrees: Degree[] | undefined;
  loading: boolean = false;

  constructor(private streamService: StreamService,
              private degreeService: DegreeService,
              private router : Router){}

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

  onSubmit(addStreamForm: NgForm){
    if(addStreamForm.valid){
      this.loading = true;
      console.log('form submitted',addStreamForm.value)
      let addStream: AddStream={
        streamName: addStreamForm.controls['streamName'].value,
        streamDescription: addStreamForm.controls['streamDescription'].value,
        degreeId: addStreamForm.controls['degreeId'].value,
      };
      console.log(addStream)
      this.streamService.AddStream(addStream).subscribe({
        next:(response) =>{
          if(response.success){
            this.router.navigate(['/streams']);
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
  };
}
