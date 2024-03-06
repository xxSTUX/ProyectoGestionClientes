import { Component } from '@angular/core';
import { SideMenuComponent } from "../side-menu/side-menu.component";
import { HeaderComponent } from "../header/header.component";
import { TreeMenuComponent } from "../tree-menu/tree-menu.component";
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'app-crea-cliente',
    standalone: true,
    templateUrl: './crea-cliente.component.html',
    styleUrl: './crea-cliente.component.css',
    imports: [SideMenuComponent, HeaderComponent, TreeMenuComponent, HttpClientModule]
})
export class CreaClienteComponent {

    creaClienteForm: FormGroup;

    constructor(private fb: FormBuilder,private http: HttpClient, private router: Router) {
        this.creaClienteForm = this.fb.group({
            nombreCliente: ['', Validators.required],
          });
    }

    creaCliente(){

        const nombreCliente = (<HTMLInputElement>document.getElementById('nombreCliente')).value;

        const body = {
            nombre: nombreCliente,
        }

        alert("Se va a crear el cliente: "+nombreCliente);
        this.http.post("https://localhost:7075/api/cliente", body).subscribe((response) => {
        // La respuesta se recibe aquí
            console.log(response);
        });
        console.log("Se deberia haber creado un nuevo cliente");
        this.router.navigate(['dashboard']);
    }
}
