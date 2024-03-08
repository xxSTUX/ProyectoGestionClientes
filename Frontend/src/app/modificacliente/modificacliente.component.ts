import { Component, Inject } from '@angular/core';
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

  constructor(private http: HttpClient, private apiService: ApiService) {}

  option={
    animation:true,
    delay:2000
  }

  contactos=[{click: true, nombre:'marrakech'}, {click: false, nombre:'federicou'}];

  proyectos=[{click: true, nombre:'proyecto1'}, {click: false, nombre:'proyecto2'}];

  licitaciones=[{click: true, nombre:'licitacion1'}, {click: false, nombre:'licitacion2'}];

  seguimientos=[{click: true, nombre:'seguimiento1'}, {click: false, nombre:'seguimiento2'}];

  creatabla(nombreelemento: string, elementos: Elemento[]){
    const tabla = document.getElementById(nombreelemento);
    if(tabla!=null){
      for(const elemento of elementos){
        const checkbox = elemento.click ? '<input type="checkbox" checked>' : '<input type="checkbox">';
        tabla.innerHTML += `<tr>
          <td>${checkbox}</td>
          <td>${elemento.nombre}</td></tr>`
      }
    }
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
