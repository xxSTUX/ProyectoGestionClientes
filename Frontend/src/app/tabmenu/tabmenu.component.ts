import { Component } from '@angular/core';
import { TreeMenuComponent } from '../tree-menu/tree-menu.component';
import { HeaderComponent } from '../header/header.component';
import { HttpClientModule} from '@angular/common/http';
import { AngularEditorConfig, AngularEditorModule } from '@kolkov/angular-editor';
import { CreaSeguimientoComponent } from "./crea-seguimiento/crea-seguimiento.component";
import { CreaLicitacionComponent } from "./crea-licitacion/crea-licitacion.component";
import { DatatableComponent } from "../datatable/datatable.component";

import { Subject } from 'rxjs';
import { ModificaclienteComponent } from "../modificacliente/modificacliente.component";


@Component({
    selector: 'app-tabmenu',
    standalone: true,
    templateUrl: './tabmenu.component.html',
    styleUrl: './tabmenu.component.css',
    imports: [HeaderComponent, TreeMenuComponent, HttpClientModule, AngularEditorModule, CreaSeguimientoComponent, DatatableComponent, CreaLicitacionComponent, ModificaclienteComponent]
})
export class TabmenuComponent {
  

}
