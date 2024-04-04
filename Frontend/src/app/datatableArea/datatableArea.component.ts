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
    selector: 'app-datatable-area',
    standalone: true,
    templateUrl: './datatableArea.component.html',
    styleUrl: './datatableArea.component.css',
    imports: [DataTablesModule, HttpClientModule, CommonModule, DashboardComponent, CreaSeguiminetoComponent]
})
export class DatatableAreaComponent implements OnInit {

  public clienteId: any;
  public areas: any;
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
    this.areas = this.dashboard.getClienteLicitaciones()
    this.ngOnInit()
  }
  openCreaSeguimiento(event: Event) {
    event.preventDefault();
  }
}
