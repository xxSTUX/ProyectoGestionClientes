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
  showWarningModal() {
    this.warningModal.nativeElement.classList.add('show');
    this.warningModal.nativeElement.style.display = 'block';
  }

  // Método para ocultar el modal de advertencia
  hideWarningModal() {
    this.warningModal.nativeElement.classList.remove('show');
    this.warningModal.nativeElement.style.display = 'none'; // Ocultar el modal
  }
}
