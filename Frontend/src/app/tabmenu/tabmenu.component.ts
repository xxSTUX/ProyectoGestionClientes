import { Component, OnInit } from '@angular/core';
import { TreeMenuComponent } from '../tree-menu/tree-menu.component';
import { HeaderComponent } from '../header/header.component';
import { HttpClientModule } from '@angular/common/http';
import { AngularEditorConfig, AngularEditorModule } from '@kolkov/angular-editor';
import { CreaSeguimientoComponent } from "./crea-seguimiento/crea-seguimiento.component";
import { CreaLicitacionComponent } from "./crea-licitacion/crea-licitacion.component";
import { DatatableComponent } from "../datatable/datatable.component";
import { DatatableProyectosComponent } from '../datatableProyectos/datatableProyectos.component';

import { Subject } from 'rxjs';
import { ModificaclienteComponent } from "../modificacliente/modificacliente.component";
import { HomeComponent } from '../home/home.component';


@Component({
    selector: 'app-tabmenu',
    standalone: true,
    template: '<app-datatable-proyecto [childProperty]="cliente"></app-datatable-proyecto>',
    templateUrl: './tabmenu.component.html',
    styleUrl: './tabmenu.component.css',
    imports: [HeaderComponent, TreeMenuComponent, HttpClientModule, AngularEditorModule, CreaSeguimientoComponent, DatatableComponent, CreaLicitacionComponent, ModificaclienteComponent, HomeComponent, DatatableProyectosComponent]
})
export class TabmenuComponent {

    public cliente:any;
    ngOnInit() {
        this.changeHrColorOnClick();
        
    }

    changeHrColorOnClick() {
        const mycolDivs = document.querySelectorAll('.mycol'); // Selecciona todos los divs con clase mycol
        
        mycolDivs.forEach((div) => {
            const link = div.querySelector('a'); // Encuentra el enlace dentro del div actual
            const hr = div.querySelector('hr'); // Encuentra el hr dentro del div actual

            if (link && hr) {
                link.addEventListener('click', () => {
                    // Restaura el color original de todos los hr
                    mycolDivs.forEach((otherDiv) => {
                        const otherHr = otherDiv.querySelector('hr');
                        const otherA = otherDiv.querySelector('a');
                        if (otherHr && otherA) {
                            otherHr.style.backgroundColor = ''; // Restaura el color original (puede ser transparente)
                            otherHr.style.height = '';
                            otherA.style.fontWeight=''; // Restaura la altura original
                            otherA.style.fontSize=''; // Restaura la altura original
                        }
                    });

                    // Cambia el color del hr actual cuando se hace clic en el enlace
                    hr.style.backgroundColor = 'blue'; // Establece el color deseado
                    hr.style.height = '0.15rem';
                    link.style.fontWeight = 'bold'
                    link.style.fontSize = '0.78rem'; // Ajusta la altura según sea necesario
                });
            } else {
                console.error('Error: No se encontró el enlace o el <hr> dentro del div.');
            }
        });
        
    }
}
