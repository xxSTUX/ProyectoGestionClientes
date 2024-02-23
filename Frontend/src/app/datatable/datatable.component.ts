import { Component } from '@angular/core';
import { DataTablesModule} from "angular-datatables"
import { OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-datatable',
  standalone: true,
  imports: [DataTablesModule, HttpClientModule, CommonModule],
  templateUrl: './datatable.component.html',
  styleUrl: './datatable.component.css'
})
export class DatatableComponent implements OnInit {
  
  public getJsonValue: any;
  public postJsonValue: any;
  public keysJson: any;

  constructor(private http: HttpClient) {

  }



  dtoptions: DataTables.Settings = {}
  dtTrigger: Subject<any> = new Subject<any>();

  ngOnInit(): void{
     this.dtoptions = {
       pagingType:"full_numbers"

     };

    this.getMethod(); //Llamada al método que trae los datos a la tabla desde la api
  }

  public getMethod(){
    this.http.get("https://localhost:7075/api/cliente").subscribe((data) => {console.log(data);
    this.getJsonValue = data;
    this.dtTrigger.next(null);
    //this.keysJson = Object.keys(this.getJsonValue[0]); //Para coger las keys del json y emplearlas como nombre de columna
  }
  );
  }



}