import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ApiResponse } from 'src/app/models/ApiResponse{T}';
import { Degree } from 'src/app/models/degree.model';
import { UpdateStream } from 'src/app/models/update-stream.model';
import { DegreeService } from 'src/app/services/degree.service';
import { StreamService } from 'src/app/services/stream.service';

@Component({
  selector: 'app-stream-update',
  templateUrl: './stream-update.component.html',
  styleUrls: ['./stream-update.component.css']
})
export class StreamUpdateComponent implements OnInit{
  streamId: number | undefined;
  stream: UpdateStream={
    streamId: 0,
    streamName: '',
    streamDescription: '',
    degreeId: 0
  };

  loading: boolean = false;
  degrees: Degree[] | undefined;

  constructor(private streamService:StreamService,
              private degreeService : DegreeService,
              private router: Router,
              private route: ActivatedRoute){}
  
  ngOnInit(): void {
    this.route.params.subscribe((params) =>{
      this.loadDegrees();
      this.streamId = params['id'];
      this.loadStreamDetail(this.streamId);
    });
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

  loadStreamDetail(streamId: number | undefined) : void {
    this.streamService.getStreamById(streamId).subscribe({
      next: (response) => {
        if (response.success) {
          this.stream = response.data;
        } else {
          console.error("Falied to fetch stream", response.message);
        }
      },
      error: (err) => {
        alert(err.error.message);
      },
      complete: () =>{
        console.log("Completed");
      }
    })
  };

  onSubmit(updateStreamForm: NgForm){
    if(updateStreamForm.valid){
      this.loading = true;
      console.log('form submitted',updateStreamForm.value)
      let updateStream: UpdateStream={
        streamId: updateStreamForm.controls['streamId'].value ,
        streamName: updateStreamForm.controls['streamName'].value,
        streamDescription: updateStreamForm.controls['streamDescription'].value,
        degreeId: updateStreamForm.controls['degreeId'].value
      };
      this.streamService.UpdateStream(updateStream).subscribe({
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
