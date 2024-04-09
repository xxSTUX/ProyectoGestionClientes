import { Component, ViewChild } from '@angular/core';
import { HeaderComponent } from "../header/header.component";
import { TreeMenuComponent } from "../tree-menu/tree-menu.component";
import { HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
    @ViewChild('modalCreacion') modalCreacion: any;

    constructor(private fb: FormBuilder, private apiService: ApiService) {
        this.creaClienteForm = this.fb.group({
            nombreCliente: ['', Validators.required],
            descripcionCliente: ['', Validators.required],
        });
    }

    async creaCliente(event: Event) {
        event.preventDefault();
        const nombreCliente = (<HTMLInputElement>document.getElementById('nombreCliente')).value;
        const descripcionCliente = (<HTMLInputElement>document.getElementById('descripcionCliente')).value;
        try {
          console.log("creacliente ejecutado");
          const resultado = await this.apiService.postClientesFromAPI(nombreCliente, descripcionCliente);
          console.log("Respuesta del servidor:", resultado);
          if(resultado === true){
            this.hideWarningModal();
            alert("Se ha creado el cliente " + nombreCliente + " con la descripcion: " + descripcionCliente);
          }
          else
            this.showWarningModal();
            //alert("El cliente " + nombreCliente + " ya existe.");

        } catch (error) {
          console.error("Error al llamar a la función postClientesFromAPI:", error);
        }

    }

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
    cerrar() {
      //sadasd
  }
}
