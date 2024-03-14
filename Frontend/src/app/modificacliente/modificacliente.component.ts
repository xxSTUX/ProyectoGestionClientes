import { Component } from '@angular/core';
import { ApiService } from '../services/api.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-modificacliente',
  standalone: true,
  templateUrl: './modificacliente.component.html',
  styleUrls: ['./modificacliente.component.css'],
  imports: [CommonModule, FormsModule]
})

export class ModificaclienteComponent {
  //Contactos
  listaContactos: any[] = [];
  idsContactosSeleccionados: number[] = [];
  todosContactosSeleccionados = false;
  listaContactosSeleccionados: any;
  botonEliminarContactosVisible = false;
  botonAniadirContactosVisible = true;

  //Proyectos
  listaProyectos: any[] = [];
  idsProyectosSeleccionados: number[] = [];
  todosProyectosSeleccionados = false;
  listaProyectosSeleccionados: any;
  botonEliminarProyectosVisible = false;
  botonAniadirProyectosVisible = true;

  constructor(private apiService: ApiService) { 
    //Contactos
    this.apiService.getDataContactosFromAPI().subscribe((data: any[]) => {
      this.listaContactos = data
        .filter((item: any) => item.eliminado === false)
        .map((item: any) => ({ ...item, isContactoSelected: false }));
    });    
    
    this.actualizarListaContactosSeleccionados();

    //Proyectos
    this.apiService.getDataProyectosFromAPI().subscribe((data: any[]) => {
      this.listaProyectos = data
        .filter((item: any) => item.Eliminado === false)
        .map((item: any) => ({ ...item, isProyectoSelected: false }));
    });    
    
    this.actualizarListaProyectosSeleccionados();
  }
  
  //CONTACTOS
  actualizarListaContactosSeleccionados(){
    this.listaContactosSeleccionados = [];
    for (var i = 0; i < this.listaContactos.length; i++) {
      if(this.listaContactos[i].isContactoSelected)
      this.listaContactosSeleccionados.push(this.listaContactos[i]);
    }
    this.listaContactosSeleccionados = JSON.stringify(this.listaContactosSeleccionados);
  }

  verificarSiTodosLosContactosEstanSeleccionados() {
    this.todosContactosSeleccionados = this.listaContactos.every(function(item:any) {
      return item.isContactoSelected == true;
    })
    this.idsContactosSeleccionados = this.listaContactos.filter(c => c.isContactoSelected).map(c => c.id);
    this.botonEliminarContactosVisible = this.idsContactosSeleccionados.length > 0;
    this.botonAniadirContactosVisible = this.idsContactosSeleccionados.length === 0;
    this.actualizarListaContactosSeleccionados();
    console.log('IDs de Contactos Seleccionados:', this.idsContactosSeleccionados);
  }
  
  seleccionarDeseleccionarTodosLosContactos() {
    for (var i = 0; i < this.listaContactos.length; i++) {
      this.listaContactos[i].isContactoSelected = this.todosContactosSeleccionados;
    }
    if(this.todosContactosSeleccionados){
      this.verificarSiTodosLosContactosEstanSeleccionados();
    } else {
      this.idsContactosSeleccionados = [];
      this.botonEliminarContactosVisible = false;
      this.botonAniadirContactosVisible = true;
      console.log('IDs de Contactos Seleccionados:', this.idsContactosSeleccionados);
    }
    this.actualizarListaContactosSeleccionados();
  }

  eliminarContactos() {
    // Recorrer todos los contactos
    this.listaContactos.forEach(contacto => {
      // Si el ID del contacto está en el array idsContactosSeleccionados, marcarlo como eliminado
      if (this.idsContactosSeleccionados.includes(contacto.id)) {
        contacto.contactoEliminado = true;
  
        // Actualizar el contacto en la base de datos
        this.apiService.putContactoFromAPI(contacto.id, contacto).subscribe(response => {
          console.log('Contacto actualizado correctamente en la base de datos', response);
        }, error => {
          console.error('Error actualizando el contacto en la base de datos', error);
        });
      }
    });
  }

  //PROYECTOS
  actualizarListaProyectosSeleccionados(){
    this.listaProyectosSeleccionados = [];
    for (var i = 0; i < this.listaProyectos.length; i++) {
      if(this.listaProyectos[i].isProyectoselected)
      this.listaProyectosSeleccionados.push(this.listaProyectos[i]);
    }
    this.listaProyectosSeleccionados = JSON.stringify(this.listaProyectosSeleccionados);
  }

  verificarSiTodosLosProyectosEstanSeleccionados() {
    this.todosProyectosSeleccionados = this.listaProyectos.every(function(item:any) {
      return item.isProyectoselected == true;
    })
    this.idsProyectosSeleccionados = this.listaProyectos.filter(c => c.isProyectoselected).map(c => c.id);
    this.botonEliminarProyectosVisible = this.idsProyectosSeleccionados.length > 0;
    this.botonAniadirProyectosVisible = this.idsProyectosSeleccionados.length === 0;
    this.actualizarListaProyectosSeleccionados();
    console.log('IDs de Proyectos Seleccionados:', this.idsProyectosSeleccionados);
  }
  
  seleccionarDeseleccionarTodosLosProyectos() {
    for (var i = 0; i < this.listaProyectos.length; i++) {
      this.listaProyectos[i].isProyectoselected = this.todosProyectosSeleccionados;
    }
    if(this.todosProyectosSeleccionados){
      this.verificarSiTodosLosProyectosEstanSeleccionados();
    } else {
      this.idsProyectosSeleccionados = [];
      this.botonEliminarProyectosVisible = false;
      this.botonAniadirProyectosVisible = true;
      console.log('IDs de Proyectos Seleccionados:', this.idsProyectosSeleccionados);
    }
    this.actualizarListaProyectosSeleccionados();
  }

  eliminarProyectos() {
    // Recorrer todos los Proyectos
    this.listaProyectos.forEach(proyecto => {
      // Si el ID del proyecto está en el array idsProyectosSeleccionados, marcarlo como eliminado
      if (this.idsProyectosSeleccionados.includes(proyecto.id)) {
        proyecto.proyectoEliminado = true;
  
        // Actualizar el proyecto en la base de datos
        this.apiService.putProyectoFromAPI(proyecto.id, proyecto).subscribe(response => {
          console.log('Proyecto actualizado correctamente en la base de datos', response);
        }, error => {
          console.error('Error actualizando el proyecto en la base de datos', error);
        });
      }
    });
  }
}
