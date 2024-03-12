import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { data } from 'jquery';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getDataClientesFromAPI(): Observable<any> {
    return this.http.get<any>('https://localhost:7075/api/cliente');
  }
  getDataProyectosFromAPI(): Observable<any> {
    return this.http.get<any>('https://localhost:7075/api/proyecto');
  }
  getDataLicitacionesFromAPI(): Observable<any> {
    return this.http.get<any>('https://localhost:7075/api/licitacion');
  }
  getDataSeguimientosFromAPI(): Observable<any> {
    return this.http.get<any>('"https://localhost:7075/api/seguimineto');
  }

   
  postClientesFromAPI(nombre:String): Observable<any> {
    const bodyCliente = {
      nombre: nombre
    };
    return this.http.post<any>('https://localhost:7075/api/proyecto', bodyCliente);
  }
  async postProyectosFromAPI(id:number, nombre:String, tipo:String, estado:String) {
    const bodyProyecto = {
      nombre: nombre,
      estado:estado,
      tipo:tipo
    };
    const response = await fetch('https://localhost:7075/api/Cliente/InsertProyecto/'+ id, {
      method: 'POST',
      headers: {
        'accept': '*/*',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(bodyProyecto),
    });  
    if (!response.ok) {
      throw new Error(`Error! Status: ${response.status}`);
    }
  }
  async postLicitacionToClienteAPI(nombre:string,tipo:string,id:string,ganada:string) {
      const bodyProyecto = {
        nombre: nombre,
        tipo:tipo,
        ganada:ganada
      };
      const response = await fetch('https://localhost:7075/api/Cliente/InsertLicitacion/'+ id, {
        method: 'POST',
        headers: {
          'accept': '*/*',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(bodyProyecto),
      });  
      if (!response.ok) {
        throw new Error(`Error! Status: ${response.status}`);
      }
  }

  async postSeguimientoToAPI(nombre:string,id:string,observaciones:string,fechaCre:Date) {
    
    var oParser = new DOMParser();
    var oDOM = oParser.parseFromString(observaciones, "text/html");
    var text = oDOM.body.innerText;

    const bodyProyecto = {
      nombre: nombre,
      tipo:"",
      fecha:fechaCre,
      observaciones:text
    };
    const response = await fetch('https://localhost:7075/api/Cliente/InsertSeguimiento/'+ id, {
      method: 'POST',
      headers: {
        'accept': '*/*',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(bodyProyecto),
    });
    if (!response.ok) {
      throw new Error(`Error! Status: ${response.status}`);
    }
}
}
