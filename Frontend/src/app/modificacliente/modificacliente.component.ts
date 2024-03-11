import { Component, Inject, Renderer2 } from '@angular/core';
import { Router } from '@angular/router';
import { AngularEditorConfig, AngularEditorModule } from '@kolkov/angular-editor';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ApiService } from '../services/api.service';
import * as bootstrap from 'bootstrap';
import { CreaClienteComponent } from "../crea-cliente/crea-cliente.component";
import { AniadecontactoComponent } from "../aniadecontacto/aniadecontacto.component";

interface Elemento{
  id: any;
  click: boolean;
  nombre: string;
}

@Component({
    selector: 'app-modificacliente',
    standalone: true,
    templateUrl: './modificacliente.component.html',
    styleUrl: './modificacliente.component.css',
    imports: [AngularEditorModule, FormsModule, HttpClientModule, CreaClienteComponent, AniadecontactoComponent]
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

  contactos=[{click: true, nombre:'marrakech', id:1}, {click: false, nombre:'federicou', id:2}, {click: true, nombre:'andaneelmacnifico', id:3}, {click: true, nombre:'marrakech', id:1}, {click: false, nombre:'federicou', id:2}, {click: true, nombre:'andaneelmacnifico', id:3}];

  proyectos=[{click: true, nombre:'proyecto1', id:1}, {click: false, nombre:'proyecto2', id:2}];

  licitaciones=[{click: true, nombre:'licitacion1', id:1}, {click: false, nombre:'licitacion2', id:2}];

  seguimientos=[{click: true, nombre:'seguimiento1', id:1}, {click: false, nombre:'seguimiento2', id:2}];

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
        botonEliminar.addEventListener('click', () => this.eliminar(elemento.id));
  
        tdBotones.appendChild(botonModificar);
        tdBotones.appendChild(botonEliminar);
  
        tr.appendChild(tdCheckbox);
        tr.appendChild(tdNombre);
        tr.appendChild(tdBotones);
  
        tabla.appendChild(tr);
      }
    }
  }
  
  modifica(id: number) {
    alert("Se va a modificar el id: "+ id);
  }
  
  eliminar(id: number) {
    alert("Se va a eliminar el id: " + id);
  }
  

  ngOnInit(){
    this.creatabla('bodytable-contactos', this.contactos);
    this.creatabla('bodytable-proyectos', this.proyectos);
    this.creatabla('bodytable-licitaciones', this.licitaciones);
    this.creatabla('bodytable-seguimientos', this.seguimientos);
  }

  updateClient(){
    alert('Cliente modificado a nombre: '+this.nombre+' id: '+this.id+ 'fecha nacimiento: '+this.fecha);
    this.apiService.putClienteFromAPI(parseInt(this.id), this.nombre);
  }

  deleteClient(){
    alert('Cliente borrado');
    this.apiService.deleteClientFromAPI(parseInt(this.id));
  }

  toasty(){
    const toast = document.getElementById("añadirContacto");
    if (toast!=null){
      const toastElement = new bootstrap.Toast(toast, this.option);
      toastElement.show();
    }
  }
}
