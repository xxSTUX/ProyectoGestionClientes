import { Component } from '@angular/core';
import { HeaderComponent } from "../header/header.component";
import { TreeMenuComponent } from "../tree-menu/tree-menu.component";
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common'
import { Alert } from 'bootstrap';
import { Location } from '@angular/common';



@Component({
  selector: 'app-eliminar-cliente',
  standalone: true,
  imports: [],
  templateUrl: './eliminar-cliente.component.html',
  styleUrl: './eliminar-cliente.component.css'
})
export class EliminarClienteComponent {

  data: any;

  constructor(private router: Router, private http: HttpClient, private apiService: ApiService, private location:Location) {

  }
  ngOnInit(): void {
  }
  async eliminarCliente() {
    const id = this.location.path().split("/")[2];
    this.apiService.deleteCliente(id);
    const newPath = this.location.path().split("/")[1];
    this.location.go(newPath);
  }
}
