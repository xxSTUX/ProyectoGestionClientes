import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { data } from 'jquery';
 
@Injectable({
  providedIn: 'root'
})
export class ApiService {
 
  ip: string = 'https://localhost:7075/api/';
 
  constructor(private http: HttpClient) { }
 
  getDataClientesFromAPI(): Observable<any> {
    return this.http.get<any>(this.ip+'cliente');
  }
 
  getDataProyectosFromAPI(): Observable<any> {
    return this.http.get<any>(this.ip+'proyecto');
  }
 
  getDataLicitacionesFromAPI(): Observable<any> {
    return this.http.get<any>(this.ip+'licitacion');
  }
 
  getDataSeguimientosFromAPI(): Observable<any> {
    return this.http.get<any>(this.ip+'seguimineto');
  }
 
   
  postClientesFromAPI(nombre:String): Observable<any> {
    const bodyCliente = {
      nombre: nombre
    };
    return this.http.post<any>(this.ip+'proyecto', bodyCliente);
  }
  async postProyectosFromAPI(id:number, nombre:String, tipo:String, estado:String) {
    const bodyProyecto = {
      nombre: nombre,
      estado:estado,
      tipo:tipo
    };
    const response = await fetch(this.ip+'Cliente/InsertProyecto/'+ id, {
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
  async postLicitacionToClienteAPI(nombre:string,tipo:string,id:string,estado:string) {
      const bodyProyecto = {
        nombre: nombre,
        tipo:tipo,
        estado:estado
      };
      alert(estado)
      const response = await fetch(this.ip+'Cliente/rInsertLicitacion/'+ id, {
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
    const response = await fetch(this.ip+'Cliente/InsertSeguimiento/'+ id, {
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
 
   deleteProyectoToAPI(id:number){
    const response = fetch(this.ip+'Proyecto/UpdateEliminado/'+ id, {
      method: 'PUT',
      headers: {
        'accept': '*/*',
        'Content-Type': 'application/json',
      }
    });
  }
  deleteContactoAPI(id:number){
    const response = fetch(this.ip+'Proyecto/UpdateEliminado/'+ id, {
      method: 'PUT',
      headers: {
        'accept': '*/*',
        'Content-Type': 'application/json',
      }
    });
  }
 
 
}