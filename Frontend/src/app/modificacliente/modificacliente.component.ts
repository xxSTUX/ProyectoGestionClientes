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

  constructor(private apiService: ApiService) { 
    //Contactos
    this.apiService.getDataContactosFromAPI().subscribe((data: any[]) => {
      this.listaContactos = data
        .filter((item: any) => item.eliminado === false)
        .map((item: any) => ({ ...item, isSelected: false }));
    });    
    
    this.actualizarListaContactosSeleccionados();
  }
  
  //CONTACTOS
  actualizarListaContactosSeleccionados(){
    this.listaContactosSeleccionados = [];
    for (var i = 0; i < this.listaContactos.length; i++) {
      if(this.listaContactos[i].isSelected)
      this.listaContactosSeleccionados.push(this.listaContactos[i]);
    }
    this.listaContactosSeleccionados = JSON.stringify(this.listaContactosSeleccionados);
  }

  verificarSiTodosLosContactosEstanSeleccionados() {
    this.todosContactosSeleccionados = this.listaContactos.every(function(item:any) {
      return item.isSelected == true;
    })
    this.idsContactosSeleccionados = this.listaContactos.filter(c => c.isSelected).map(c => c.id);
    this.botonEliminarContactosVisible = this.idsContactosSeleccionados.length > 0;
    this.botonAniadirContactosVisible = this.idsContactosSeleccionados.length === 0;
    this.actualizarListaContactosSeleccionados();
    console.log('IDs de Contactos Seleccionados:', this.idsContactosSeleccionados);
  }
  
  seleccionarDeseleccionarTodosLosContactos() {
    for (var i = 0; i < this.listaContactos.length; i++) {
      this.listaContactos[i].isSelected = this.todosContactosSeleccionados;
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
        contacto.eliminado = true;
  
        // Actualizar el contacto en la base de datos
        this.apiService.putContactoFromAPI(contacto.id, contacto).subscribe(response => {
          console.log('Contacto actualizado correctamente en la base de datos', response);
        }, error => {
          console.error('Error actualizando el contacto en la base de datos', error);
        });
      }
    });
  }
}
