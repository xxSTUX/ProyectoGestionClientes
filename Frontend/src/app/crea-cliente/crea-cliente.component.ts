import { Component, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';
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

    @ViewChild('warningModal') warningModal: any;

    constructor(private fb: FormBuilder, private apiService: ApiService) {
        this.creaClienteForm = this.fb.group({
            nombreCliente: ['', Validators.required],
            descripcionCliente: ['', Validators.required],
        });
    }

    creaCliente() {
        const nombreCliente = (<HTMLInputElement>document.getElementById('nombreCliente')).value;
        const descripcionCliente = (<HTMLInputElement>document.getElementById('descripcionCliente')).value;
        const clienteExiste = this.apiService.getClienteNombre(nombreCliente);
        



        {

        }
        // this.checkIfClientExists(nombreCliente).then((exists) => {
        //     if (exists) {
        //         this.showWarningModal();
        //     } else {
               // this.apiService.postClientesFromAPI(nombreCliente, descripcionCliente);
               // alert("Se ha creado el cliente " + nombreCliente + " con la descripcion: " + descripcionCliente);
            }
    //     });
    // }

    // Método para mostrar el modal de advertencia
    showWarningModal() {
        this.warningModal.nativeElement.classList.add('show');
        this.warningModal.nativeElement.style.display = 'block';
    }

    // Método para ocultar el modal de advertencia
    hideWarningModal() {
        this.warningModal.nativeElement.classList.remove('show');
        this.warningModal.nativeElement.style.display = 'none'; // Ocultar el modal
    }
}
