import { Component, ViewChild } from '@angular/core';
import { ApiService } from '../services/api.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-crea-seguimineto',
  standalone: true,
  imports: [],
  templateUrl: './crea-seguimineto.component.html',
  styleUrl: './crea-seguimineto.component.css'
})
export class CreaSeguiminetoComponent {

  @ViewChild('warningModal') warningModal: any;
  router: any;
  
  constructor(private apiService:ApiService, private location:Location){}
  ngOnInit(): void {
  }
  async creaSeg() { 
    const obsevacionSeg = (<HTMLInputElement>document.getElementById('obsevacionSeg')).value;
    const newPath = this.location.path().split("/")[1];
    const id = this.location.path().split("/")[2];
    await this.apiService.postSeguimientoToAPI(id,obsevacionSeg);
    this.location.go(newPath);
    
  }
}
