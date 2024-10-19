import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiResponse } from 'src/app/models/ApiResponse{T}';
import { Stream } from 'src/app/models/stream.model';
import { StreamService } from 'src/app/services/stream.service';

@Component({
  selector: 'app-stream-list',
  templateUrl: './stream-list.component.html',
  styleUrls: ['./stream-list.component.css']
})
export class StreamListComponent {
  streams: Stream[] | undefined;
  streamId: number | undefined; 
  loading: boolean = false;

  constructor(private streamService: StreamService,private router : Router){ }
  ngOnInit(): void {
    this.loadStreams();
  };

  loadStreams(): void{
    this.loading = true;
    this.streamService.getAllStreams().subscribe({
      next: (response: ApiResponse<Stream[]>) =>{
        if(response.success){
          this.streams = response.data;
        }
        else{
          console.error('Failed to fetch streams: ',response.message);
        }
        this.loading = false; 
      },
        error:(error) =>{
          console.error('Error fetching streams: ',error);
          this.loading = false;
      }
    })
  };

  confirmDelete(id : number): void{
    if(confirm('Are you sure?')){
      this.streamId = id;
      this.deleteStream();
    }
  };
  deleteStream(): void{
    this.streamService.deleteStreamById(this.streamId).subscribe({
      next:(response) => {
        if(response.success){
          this.loadStreams();
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

  streamDetails(streamId: number): void {
    this.router.navigate(['stream/details/',streamId]);
  }
  
  streamUpdate(id:number): void{
    this.router.navigate(['stream/update/', id])
  }
  

}
