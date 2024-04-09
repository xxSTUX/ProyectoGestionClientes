import { Component, Input, input } from '@angular/core';
import { DataTablesModule } from "angular-datatables"
import { OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { Subject } from 'rxjs';
import { ApiService } from '../services/api.service';
import { DashboardComponent } from '../dashboard/dashboard.component';

@Component({
  selector: 'app-datatable-proyecto',
  standalone: true,
  imports: [DataTablesModule, HttpClientModule, CommonModule, DashboardComponent],
  templateUrl: './datatableProyectos.component.html',
  styleUrl: './datatableProyectos.component.css'
})
export class DatatableProyectosComponent implements OnInit {

  public clienteId: any;
  public proyectos: any;
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
    this.proyectos = this.dashboard.getClienteProyectos()
    this.ngOnInit()
  }
  openCreaProyecto(event: Event) {
    event.preventDefault();
  }
}
