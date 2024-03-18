import { Component } from '@angular/core';
import { HeaderComponent } from "../header/header.component";
import { TreeMenuComponent } from "../tree-menu/tree-menu.component";
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';

@Component({
    selector: 'app-crea-cliente',
    standalone: true,
    templateUrl: './crea-cliente.component.html',
    styleUrl: './crea-cliente.component.css',
    imports: [HeaderComponent, TreeMenuComponent, HttpClientModule]
})
export class CreaClienteComponent {

    creaClienteForm: FormGroup;

    constructor(private fb: FormBuilder, private http: HttpClient, private router: Router, private ApiService: ApiService) {
        this.creaClienteForm = this.fb.group({
            nombreCliente: ['', Validators.required],
            descripcionCliente: ['', Validators.required],
        });
    }

    creaCliente() {

        const nombreCliente = (<HTMLInputElement>document.getElementById('nombreCliente')).value;
        const descripcionCliente = (<HTMLInputElement>document.getElementById('descripcionCliente')).value;

        const body = {
            nombre: nombreCliente,
            descripcion: descripcionCliente
        }

        this.ApiService.postClientesFromAPI(nombreCliente, descripcionCliente).subscribe(
            (response) => {
                console.log(response);
            },
            (error) => {
                console.error(error);
            }
        );
        alert("Se ha creado el cliente "+nombreCliente + " con la descripcion: " + descripcionCliente);
    }
}
