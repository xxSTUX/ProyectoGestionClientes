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
  
  constructor(private apiservice:ApiService, private location:Location){}
  async creaSeg() {
    const nombreSeg = (<HTMLInputElement>document.getElementById('nombreSeg')).value;
    const obsevacionSeg = (<HTMLInputElement>document.getElementById('obsevacionSeg')).value;
    const newPath = this.location.path().split("/")[1];
    const id = this.location.path().split("/")[2];
    this.apiservice.postSeguimientoToAPI(nombreSeg,id,obsevacionSeg);
    this.location.go(newPath);
    
  }
  
}
