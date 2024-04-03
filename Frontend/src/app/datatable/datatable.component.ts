import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { DataTablesModule } from "angular-datatables"
import { OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { Subject } from 'rxjs';
import { ApiService } from '../services/api.service';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { DatatableProyectosComponent } from '../datatableProyectos/datatableProyectos.component';
import { CreaSeguiminetoComponent } from '../crea-seguimineto/crea-seguimineto.component';
@Component({
  selector: 'app-datatable',
  standalone: true,
  imports: [DataTablesModule, HttpClientModule, CommonModule, DashboardComponent, DatatableProyectosComponent, CreaSeguiminetoComponent],
  templateUrl: './datatable.component.html',
  styleUrl: './datatable.component.css'
})
export class DatatableComponent implements OnInit {

  public cliente: any;
  public getJsonValue: any;
  public postJsonValue: any;
  public keysJson: any;
  router: any;

  constructor(private http: HttpClient, private location:Location, private apiService: ApiService, private dashboard: DashboardComponent) {

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

  openCreaSeg(event: Event, cliente:any) {
    this.location.go(this.location.path()+"/" +cliente.id);//Cambio de la ruta mostrada, mostrar la del padre del item TODO-Gian quitar a aprtir del = en la fragmet para tratar el componente mostrado
    event.preventDefault();
  }
  public editCliente(){
    alert("Funca");
  }
  public async eliminarCliente(id:number){
    alert("Se procede a eliminar el elemento seleccionado: " + id)
    await this.apiService.deleteCliente(id);
    window.location.reload();
}
  public getMethod() {
    this.apiService.getDataClientesFromAPI().subscribe((data) => {
      console.log(data);
      this.getJsonValue = data;
      this.dtTrigger.next(null);
    });
  }
  over(id:number, idCliente:number){
    switch (id) {
      case 1:
          var i = document.getElementById("iconoEditar"+idCliente)
          i?.classList.replace("bi-building-gear","bi-building-fill-gear")
        break;
      case 2:
          var i = document.getElementById("iconoEliminar"+idCliente)
          i?.classList.replace("bi-building-x","bi-building-fill-x")
        break;
      case 3:
          var i = document.getElementById("iconoPortapapeles"+idCliente)
          i?.classList.replace("bi-clipboard-plus","bi-clipboard-plus-fill")
        break;
    }
    
  }
  out(id:number, idCliente:number){
    switch (id) {
      case 1:
          var i = document.getElementById("iconoEditar"+idCliente)
          i?.classList.replace("bi-building-fill-gear","bi-building-gear")
        break;
    
      case 2:
          var i = document.getElementById("iconoEliminar"+idCliente)
          i?.classList.replace("bi-building-fill-x","bi-building-x")
        break;
      case 3:
          var i = document.getElementById("iconoPortapapeles"+idCliente)
          i?.classList.replace("bi-clipboard-plus-fill","bi-clipboard-plus")
        break;
    }
    
  }
  public seleCliente(cliente:any){
    console.log(cliente)
    this.cliente = cliente;
    this.location.go(this.location.path()+"/" +cliente.id)
    this.dashboard.seleccionarCliente(cliente)
  }
}
