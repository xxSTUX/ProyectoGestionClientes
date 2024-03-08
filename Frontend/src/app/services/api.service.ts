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

   
  postClientesFromAPI(nombre:number): Observable<any> {
    const bodyCliente = {
      nombre: nombre
    };
    return this.http.post<any>('https://localhost:7075/api/proyecto', bodyCliente);
  }

  postProyectosFromAPI(id:number, nombre:String, tipo:String): Observable<any> {
    const bodyProyecto = {
      id:id,
      nombre: nombre,
      tipo:tipo
    };
    return this.http.post<any>('https://localhost:7075/api/proyecto', bodyProyecto);
  }
  async postLicitacionFromAPI(nombre:string,tipo:string) {
      const bodyProyecto = {
        nombre: nombre,
        tipo:tipo
      };
      console.log(bodyProyecto)
      const response = await fetch('https://localhost:7075/api/Cliente/InsertLicitacion/2', {
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

  putClienteFromAPI(id: number, nombre: string): Observable<any> {
    const bodyCliente = {
      nombre: nombre,
    };
  
    return this.http.put<any>('https://localhost:7075/api/proyecto/${id}', bodyCliente);
  }

  deleteClientFromAPI(id: number): Observable<any> {
    return this.http.delete<any>(`https://localhost:7075/api/cliente/${{id}}`);
  }
  
}
