import { Component, Input, input } from '@angular/core';
import { DataTablesModule } from "angular-datatables"
import { OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { Subject } from 'rxjs';
import { ApiService } from '../services/api.service';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { CreaSeguiminetoComponent } from "../crea-seguimineto/crea-seguimineto.component";

@Component({
    selector: 'app-datatable-contacto',
    standalone: true,
    templateUrl: './datatableContacto.component.html',
    styleUrl: './datatableContacto.component.css',
    imports: [DataTablesModule, HttpClientModule, CommonModule, DashboardComponent, CreaSeguiminetoComponent]
})
export class DatatableContactoComponent implements OnInit {

  public clienteId: any;
  public contactos: any;
  public keysJson: any;

  constructor(private http: HttpClient, private apiService: ApiService, private dashboard:DashboardComponent) {
    
  }
  dtoptions: DataTables.Settings = {}
  dtTrigger: Subject<any> = new Subject<any>();

  ngOnInit(): void {
    this.dtoptions = {
      pagingType: "full_numbers",
      "search": false,

    };
    this.getMethod(); //Llamada al método que trae los datos a la tabla desde la api
  }
  public getMethod() {
    this.dtTrigger.next(null);
  }
  
  reload(){
    this.clienteId = this.dashboard.getClienteId()
    this.contactos = this.dashboard.getClienteContacto()
    console.log(this.contactos)
    this.ngOnInit()
  }
  openCreaSeguimiento(event: Event) {
    event.preventDefault();
  }
  over(id:number, idCliente:number){
    switch (id) {
      case 1:
        var i = document.getElementById("editarSeguimiento"+idCliente)
        i?.classList.replace("bi-pencil","bi-pencil-fill")
        break;
      case 2:
        var i = document.getElementById("eliminarSeguimiento"+idCliente)
        i?.classList.replace("bi-trash","bi-trash-fill")
        break;
    }
    
  }
  out(id:number, idCliente:number){
    switch (id) {
      case 1:
          var i = document.getElementById("editarSeguimiento"+idCliente)
          i?.classList.replace("bi-pencil-fill","bi-pencil")
        break;
      case 2:
        var i = document.getElementById("eliminarSeguimiento"+idCliente)
        i?.classList.replace("bi-trash-fill","bi-trash")
        break;
    }
    
  }
}
