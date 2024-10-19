import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiResponse } from 'src/app/models/ApiResponse{T}';
import { AddGraduateTrainee } from 'src/app/models/add-graduatetrainee.model';
import { Degree } from 'src/app/models/degree.model';
import { Stream } from 'src/app/models/stream.model';
import { DegreeService } from 'src/app/services/degree.service';
import { GraduatetraineeService } from 'src/app/services/graduatetrainee.service';
import { StreamService } from 'src/app/services/stream.service';

@Component({
  selector: 'app-graduatetrainee-add',
  templateUrl: './graduatetrainee-add.component.html',
  styleUrls: ['./graduatetrainee-add.component.css']
})
export class GraduatetraineeAddComponent implements OnInit{
  trainee: AddGraduateTrainee={
    degreeId: 0,
    streamId: 0,
    traineeName: '',
    traineeEmail: '',
    universityName: '',
    isLastSemesterPending: false,
    gender: '',
    dateOfApplication: new Date,
    image: '',
    ai: 0,
    phyton: 0,
    businessAnalysis: 0,
    machineLearning: 0,
    practical: 0,
    totalMarks: 0,
    percentages: 0,
    isAdmisisonConfirmed: false
  };

  degrees: Degree[] | undefined;
  streams: Stream[] | undefined;
  loading: boolean = false;

  constructor(private traineeService: GraduatetraineeService, 
    private degreeService: DegreeService, 
    private streamService: StreamService,
    private router : Router
  ){}

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

  loadStreamsByDegreeId(degreeId: number | undefined) : void {
    this.streamService.getStreamByDergreeId(degreeId).subscribe({
      next: (response) => {
        if (response.success) {
          this.streams = response.data;
        } else {
          console.error("Falied to fetch streams", response.message);
        }
      },
      error: (err) => {
        alert(err.error.message);
        this.streams=[];
      },
      complete: () =>{
        console.log("Completed");
      }
    })
  };

  onDegreeChange(): void{
    this.loadStreamsByDegreeId(this.trainee.degreeId);
    this.trainee.streamId = 0;
  };

  getFileName(path: string): string {
    return path.substring(path.lastIndexOf('\\') + 1);
  }

  onSubmit(addTraineeForm: NgForm){
    console.log(this.trainee);
    if(addTraineeForm.valid){
      this.loading = true;
      console.log('form submitted',addTraineeForm.value)
      let addTrainee: AddGraduateTrainee={
        traineeName: addTraineeForm.controls['traineeName'].value,
        traineeEmail: addTraineeForm.controls['traineeEmail'].value,
        universityName: addTraineeForm.controls['universityName'].value,
        isLastSemesterPending: addTraineeForm.controls['isLastSemesterPending'].value,
        gender: addTraineeForm.controls['gender'].value,
        degreeId: Number(addTraineeForm.controls['degreeId'].value),
        streamId: Number(addTraineeForm.controls['streamId'].value),
        // image: addTraineeForm.controls['image'].value,
        image: this.getFileName(addTraineeForm.controls['image'].value),
        ai: addTraineeForm.controls['ai'].value,
        phyton: addTraineeForm.controls['phyton'].value,
        businessAnalysis: addTraineeForm.controls['businessAnalysis'].value,
        machineLearning: addTraineeForm.controls['machineLearning'].value,
        practical: addTraineeForm.controls['practical'].value,
        dateOfApplication: addTraineeForm.controls['dateOfApplication'].value,
        totalMarks: 0,
        percentages: 0,
        isAdmisisonConfirmed: false
      };
      console.log(addTrainee);
      this.traineeService.AddTrainee(addTrainee).subscribe({
        next:(response) =>{
          if(response.success){
            this.router.navigate(['/trainees']);
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
