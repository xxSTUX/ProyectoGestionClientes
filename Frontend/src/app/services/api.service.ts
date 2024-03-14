import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { data } from 'jquery';
 
@Injectable({
  providedIn: 'root'
})
export class ApiService {
 
  api: string = 'https://localhost:7075/api/';
 
  constructor(private http: HttpClient) { }
 
  getDataClientesFromAPI(): Observable<any> {
    return this.http.get<any>(this.api+'cliente');
  }
 
  getDataProyectosFromAPI(): Observable<any> {
    return this.http.get<any>(this.api+'Proyecto');
  }
 
  getDataLicitacionesFromAPI(): Observable<any> {
    return this.http.get<any>(this.api+'licitacion');
  }
 
  getDataSeguimientosFromAPI(): Observable<any> {
    return this.http.get<any>(this.api+'seguimineto');
  }

  getDataContactosFromAPI():Observable<any> {
    return this.http.get<any>(this.api+'contacto');
  }
  getContactoById(id: number): Observable<any> {
    return this.http.get<any>(`${this.api}/contacto/${id}`);
  }
 
   
  postClientesFromAPI(nombre:String): Observable<any> {
    const bodyCliente = {
      nombre: nombre
    };
    return this.http.post<any>(this.api+'proyecto', bodyCliente);
  }
  async postProyectosFromAPI(id:number, nombre:String, tapio:String, estado:String) {
    const bodyProyecto = {
      nombre: nombre,
      estado:estado,
      tapio:tapio
    };
    const response = await fetch(this.api+'Cliente/InsertProyecto/'+ id, {
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

  async postLicitacionFromAPI(nombre:string,tapio:string) {
    const bodyProyecto = {
      nombre: nombre,
      tapio:tapio
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

  async postLicitacionToClienteAPI(nombre:string,tapio:string,id:string,estado:string) {
      const bodyProyecto = {
        nombre: nombre,
        tapio:tapio,
        estado:estado
      };
      alert(estado)
      const response = await fetch(this.api+'Cliente/rInsertLicitacion/'+ id, {
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
      tapio:"",
      fecha:fechaCre,
      observaciones:text
    };
    const response = await fetch(this.api+'Cliente/InsertSeguimiento/'+ id, {
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
    const response = fetch(this.api+'Proyecto/UpdateEliminado/'+ id, {
      method: 'PUT',
      headers: {
        'accept': '*/*',
        'Content-Type': 'application/json',
      }
    });
  }
  deleteContactoAPI(id:number){
    const response = fetch(this.api+'Proyecto/UpdateEliminado/'+ id, {
      method: 'PUT',
      headers: {
        'accept': '*/*',
        'Content-Type': 'application/json',
      }
    });
  }

  putClienteFromAPI(id: number, nombre: string): Observable<any> {
    const bodyCliente = {
      nombre: nombre,
    };
  
    return this.http.put<any>('https://localhost:7075/api/proyecto/${id}', bodyCliente);
  }

  putContactoFromAPI(id: number, updatedContact: any): Observable<any> {
    const bodyContacto = {
      cargo: updatedContact.cargo,
      email: updatedContact.email,
      telefono: updatedContact.telefono,
      contactoEliminado: updatedContact.contactoEliminado,
    };
  
    return this.http.put<any>(`https://localhost:7075/api/contacto/${id}`, bodyContacto);
  }

  postProyectoFromAPI(newProyecto: any): Observable<any> {
    const bodyProyecto = {
      nombre: newProyecto.nombre,
      estado: newProyecto.estado,
      tapio: newProyecto.tapio,
      seguimientos: newProyecto.seguimientos,
      licitaciones: newProyecto.licitaciones,
      facturacion: newProyecto.facturacion,
      puestos: newProyecto.puestos,
    };
  
    return this.http.post<any>('https://localhost:7075/api/proyecto', bodyProyecto);
  }  
 
  putProyectoFromAPI(id: number, updatedProyecto: any): Observable<any> {
    const bodyProyecto = {
      nombre: updatedProyecto.nombre,
      estado: updatedProyecto.estado,
      tapio: updatedProyecto.tapio,
      seguimientos: updatedProyecto.seguimientos,
      licitaciones: updatedProyecto.licitaciones,
      facturacion: updatedProyecto.facturacion,
      puestos: updatedProyecto.puestos,
      proyectoEliminado: updatedProyecto.proyectoEliminado,
    };
  
    return this.http.put<any>(`https://localhost:7075/api/proyecto/${id}`, bodyProyecto);
  }
}