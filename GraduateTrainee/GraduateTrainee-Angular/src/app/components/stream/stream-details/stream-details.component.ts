import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Stream } from 'src/app/models/stream.model';
import { StreamService } from 'src/app/services/stream.service';

@Component({
  selector: 'app-stream-details',
  templateUrl: './stream-details.component.html',
  styleUrls: ['./stream-details.component.css']
})
export class StreamDetailsComponent implements OnInit{
  streamId: number | undefined;
  stream: Stream ={
    streamId: 0,
    streamName: '',
    streamDescription: '',
    degreeId: 0,
    degree: {
      degreeId: 0,
      degreeName: '',
      degreeDescription: ''
    }
  };

  constructor(private streamService: StreamService, private router: ActivatedRoute) { }

  ngOnInit(): void {
    this.router.params.subscribe((params) => {
      this.streamId = params['id'];
      this.loadStreamDetail(this.streamId);
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
}
