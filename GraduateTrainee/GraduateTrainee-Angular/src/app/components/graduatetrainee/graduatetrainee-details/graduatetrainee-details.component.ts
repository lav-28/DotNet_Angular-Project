import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GraduateTrainee } from 'src/app/models/graduatetrainee.model';
import { GraduatetraineeService } from 'src/app/services/graduatetrainee.service';

@Component({
  selector: 'app-graduatetrainee-details',
  templateUrl: './graduatetrainee-details.component.html',
  styleUrls: ['./graduatetrainee-details.component.css']
})
export class GraduatetraineeDetailsComponent implements OnInit{
  contactId: number | undefined;
  trainee: GraduateTrainee = {
    graduateTraineeId: 0,
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
    isAdmisisonConfirmed: false,
    degree: {
      degreeId: 0,
      degreeName: '',
      degreeDescription: 0
    },
    stream: {
      streamId: 0,
      streamName: '',
      streamDescription: ''
    },
  };

  constructor(private traineeService: GraduatetraineeService, private route : ActivatedRoute){ }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.contactId = params['id'];
      this.loadTraineeDetails(this.contactId);
    });
  };

  loadTraineeDetails(traineeId:number | undefined): void{
    this.traineeService.getTraineeById(traineeId).subscribe({
      next:(response) =>{
        if(response.success){
          this.trainee = response.data;
        }
        else{
          console.error('Failed to fetch graduate trainee: ',response.message);
        }
      },
      error:(err) =>{
        alert(err.error.message);
      },
      complete:()=>{
        console.log("completed");
      }
    })
   }

} 
