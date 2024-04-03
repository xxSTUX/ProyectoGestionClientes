import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  api: string = 'https://localhost:7075/api/';

  constructor(private http: HttpClient) { }

  getDataClientesFromAPI(): Observable<any> {
    return this.http.get<any>(this.api+'cliente');
  }
  getDataArbolFromAPI(): Observable<any> {
    return this.http.get<any>(this.api+'cliente/Arbol'); 
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

  getEstadoProyectos(): Observable<any>{
    return this.http.get<any>(this.api+'Proyecto/GetEstadoPoryectos');
  }
  getClientePorNombre(nombre:string){
    alert(nombre)
    return this.http.get<any>(this.api+'Cliente/clientenombre/'+nombre);
  }


  getClienteNombre(nombre: string) : Observable<any> {
    return this.http.get<any>(this.api + 'Cliente/nombre/' + nombre);
  }


  postClientesFromAPI(nombre:String, descripcion:String) {
    const bodyCliente = {
      nombre: nombre,
      descripcion: descripcion
    };
    return fetch(this.api+'Cliente', {
      method: 'POST',
      headers: {
        'accept': '*/*',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(bodyCliente),
    }).then(response => response.json());
}

  async postProyectosFromAPI(id:string, nombre:String, tipo:String, estado:string) {
    const bodyProyecto = {
      nombre: nombre,
      estado:estado,
      tipo:tipo
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

  async postLicitacionToClienteAPI(nombre:string,tipo:string,id:string,estado:string) {
    const bodyProyecto = {
      nombre: nombre,
      tipo: tipo,
      estado:estado
    };
    console.log(bodyProyecto)
    const response = fetch('https://localhost:7075/api/Cliente/InsertLicitacion/'+id, {
      method: 'POST',
      headers: {
        'accept': '*/*',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(bodyProyecto),
    });
  }

  async postSeguimientoToAPI(nombre:string,id:string,observaciones:string) {
    alert("ayiyi")
    var oParser = new DOMParser();
    var oDOM = oParser.parseFromString(observaciones, "text/html");
    var text = oDOM.body.innerText;
    const bodyProyecto = {
      nombre: nombre,
      tipo:"",
      observaciones:text
    };
    const response = fetch('https://localhost:7075/api/Cliente/InsertSeguimiento/'+ id, {
      method: 'POST',
      headers: {
        'accept': '*/*',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(bodyProyecto),
    });

}
async deleteCliente(id:number){
  const response = await fetch(this.api+'Cliente/UpdateEliminado/'+ id, {
    method: 'PUT',
    headers: {
      'accept': '*/*',
      'Content-Type': 'application/json',
    }
  });
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
      tipo: newProyecto.tipo,
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
      tipo: updatedProyecto.tipo,
      seguimientos: updatedProyecto.seguimientos,
      licitaciones: updatedProyecto.licitaciones,
      facturacion: updatedProyecto.facturacion,
      puestos: updatedProyecto.puestos,
      proyectoEliminado: updatedProyecto.proyectoEliminado,
    };

    return this.http.put<any>(`https://localhost:7075/api/proyecto/${id}`, bodyProyecto);
  }

  async putLicitacionFromAPI(id: number, updatedLicitacion: any): Promise<void> {
    const response = await this.http.put<any>(`${this.api}licitacion/${id}`, updatedLicitacion).toPromise();

    if (!response) {
      throw new Error('Error al actualizar la licitación.');
    }
}

}
