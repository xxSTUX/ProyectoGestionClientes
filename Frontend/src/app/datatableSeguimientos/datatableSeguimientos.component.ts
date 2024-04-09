import { Component, Input, input } from '@angular/core';
import { DataTablesModule } from "angular-datatables"
import { OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule, Location } from '@angular/common';
import { Subject } from 'rxjs';
import { ApiService } from '../services/api.service';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { CreaSeguiminetoComponent } from '../crea-seguimineto/crea-seguimineto.component';

@Component({
    selector: 'app-datatable-seguimiento',
    standalone: true,
    templateUrl: './datatableSeguimientos.component.html',
    styleUrl: './datatableSeguimientos.component.css',
    imports: [DataTablesModule, HttpClientModule, CommonModule, DashboardComponent, CreaSeguiminetoComponent]
})
export class DatatableSeguimientosComponent implements OnInit {

  public clienteId: any;
  public seguimientos: any;
  public keysJson: any;

  constructor(private http: HttpClient, private apiService: ApiService, private dashboard:DashboardComponent, private location:Location) {
    
  }
  dtoptions: DataTables.Settings = {}
  dtTrigger: Subject<any> = new Subject<any>();
  loadedOnce = false;
  ngOnInit(): void {
    if (!this.loadedOnce) {
      // Realiza la recarga o cualquier otra acción que necesites

      //TODO RELOAD AL CLICAR EN LA TAB

      this.reload();
      this.loadedOnce = true;
  }
    this.dtoptions = {
      pagingType: "full_numbers",
      "search": false,

    };
    this.getMethod(); //Llamada al método que trae los datos a la tabla desde la api
  }

  openCreaSeg(event: Event, cliente:any) {
    this.location.go(this.location.path()+"/" +cliente.id);//Cambio de la ruta mostrada, mostrar la del padre del item TODO-Gian quitar a aprtir del = en la fragmet para tratar el componente mostrado
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

  public getMethod() {
    this.dtTrigger.next(null);
  }
  
  reload(){
    this.clienteId = this.dashboard.getClienteId()
    this.seguimientos = this.dashboard.getClienteSeguimientos()
    this.ngOnInit()
  }
  openCreaSeguimiento(event: Event) {
    event.preventDefault();
  }
  
}
