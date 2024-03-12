import { Component, Renderer2 } from '@angular/core';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ApiService } from '../services/api.service';
import * as bootstrap from 'bootstrap';
import { CreaClienteComponent } from "../crea-cliente/crea-cliente.component";
import { AniadecontactoComponent } from "../aniadecontacto/aniadecontacto.component";
import { CommonModule } from '@angular/common';
import { Observable, map } from 'rxjs';

interface Elemento{
  id: any;
  click: boolean;
  nombre: string;
  deleted:boolean;
}

@Component({
  selector: 'app-modificacliente',
  standalone: true,
  templateUrl: './modificacliente.component.html',
  styleUrls: ['./modificacliente.component.css'],
  imports: [AngularEditorModule, FormsModule, HttpClientModule, CreaClienteComponent, AniadecontactoComponent, CommonModule]
})

export class ModificaclienteComponent {
  id = '';
  nombre = '';
  fecha = '';

  constructor(private http: HttpClient, private apiService: ApiService, private renderer: Renderer2) {}

  option={
    animation:true,
    delay:2000
  }

  contactos: Observable<any> | undefined;
  proyectos: Observable<any> | undefined;
  licitaciones: Observable<any> | undefined;
  seguimientos: Observable<any> | undefined;

  creatabla(nombreelemento: string, elementos: Elemento[]) {
    const tabla = document.getElementById(nombreelemento);
    if (tabla != null) {
      for (const elemento of elementos) {
        const tr = document.createElement('tr');
        const tdCheckbox = document.createElement('td');
        const checkbox = document.createElement('input');
        checkbox.type = 'checkbox';
        checkbox.checked = elemento.click;
        tdCheckbox.appendChild(checkbox);

        const tdNombre = document.createElement('td');
        tdNombre.textContent = elemento.nombre;

        const tdBotones = document.createElement('td');
        const botonModificar = document.createElement('button');
        botonModificar.textContent = 'Modificar';
        botonModificar.addEventListener('click', () => this.modifica(elemento.id));
        const botonEliminar = document.createElement('button');
        botonEliminar.textContent = 'Eliminar';
        botonEliminar.addEventListener('click', () => this.eliminar());

        tdBotones.appendChild(botonModificar);
        tdBotones.appendChild(botonEliminar);

        tr.appendChild(tdCheckbox);
        tr.appendChild(tdNombre);
        tr.appendChild(tdBotones);

        tabla.appendChild(tr);
      }
    }
  }

  async modifica(id: number) {
    const contacto = await this.apiService.getContactoById(id).toPromise();
    if (contacto) {
      // Mostrar el popup con los datos del contacto
      // Puedes usar un modal o cualquier otra forma de mostrar la información del contacto
      alert(`ID: ${contacto.id}
      Cargo: ${contacto.cargo}
      Email: ${contacto.email}
      Teléfono: ${contacto.telefono}`);

      // Código para editar los datos del contacto
      const cargoEditado = prompt("Introduce el nuevo cargo:", contacto.cargo);
      const emailEditado = prompt("Introduce el nuevo email:", contacto.email);
      const telefonoEditado = prompt("Introduce el nuevo teléfono:", contacto.telefono);

      // Actualizar la información del contacto
      const updatedContact = {
        cargo: cargoEditado ? cargoEditado : contacto.cargo,
        email: emailEditado ? emailEditado : contacto.email,
        telefono: telefonoEditado ? telefonoEditado : contacto.telefono,
      };

      await this.apiService.putContactoFromAPI(id, updatedContact).toPromise();

      alert("Contacto actualizado correctamente");
    } else {
      alert("No se ha encontrado el contacto con ID " + id);
    }
  }

  async eliminar() {
    // Recorrer todos los contactos
    this.contactos?.forEach(contacto => {
      // Si el contacto está seleccionado, marcarlo como eliminado
      if (contacto.click) {
        contacto.deleted = true;
      }
    });
  
    alert("Contactos marcados como eliminados correctamente");
  }
  

  toggleTodos(event: any) {
    let isChecked = event.target.checked;
    this.contactos?.forEach(contacto => contacto.click = isChecked);
  }
  
  hayContactosSeleccionados(): Observable<boolean> | undefined {
    return this.contactos?.pipe(
      map((contactos: Elemento[]) => {
        let haySeleccionados = contactos.some(contacto => contacto.click);
        console.log('hayContactosSeleccionados:', haySeleccionados);
        return haySeleccionados;
      })
    );
  }   
   

  ngOnInit() {
    // **Llamada a la API solo una vez**
    this.contactos = this.apiService.getDataContactosFromAPI().pipe(
      map(contactos => contactos.filter((contacto: Elemento) => {
        return !contacto.deleted && typeof contacto === 'object';
      }))
    );    
    this.proyectos = this.apiService.getDataProyectosFromAPI();
    this.licitaciones = this.apiService.getDataLicitacionesFromAPI();
    this.seguimientos = this.apiService.getDataSeguimientosFromAPI();

    this.contactos.subscribe((data) => {
      this.creatabla('bodytable-contactos', data);
    });

    this.proyectos.subscribe((data) => {
      this.creatabla('bodytable-proyectos', data);
    });

    this.licitaciones.subscribe((data) => {
      this.creatabla('bodytable-licitaciones', data);
    });

    this.seguimientos.subscribe((data) => {
      this.creatabla('bodytable-seguimientos', data);
    });
  }

  updateClient(){
    alert('Cliente modificado a nombre: '+this.nombre+' id: '+this.id+ 'fecha nacimiento: '+this.fecha);
    this.apiService.putClienteFromAPI(parseInt(this.id), this.nombre);
  }

  deleteClient(){
    alert('Cliente borrado');
    this.apiService.deleteClientFromAPI(parseInt(this.id));
  }

  toasty(nombreArchivo: string){
    const toast = document.getElementById(nombreArchivo);
    if (toast!=null){
      const toastElement = new bootstrap.Toast(toast, this.option);
      toastElement.show();
    }
  }
}