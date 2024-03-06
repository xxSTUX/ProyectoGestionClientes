import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

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
  postProyectosFromAPI(id:number, nombre:String, tipo:String): Observable<any> {
    const bodyProyecto = {
      id:id,
      nombre: nombre,
      tipo:tipo
    };
    return this.http.post<any>('https://localhost:7075/api/proyecto', bodyProyecto);
  }
}
