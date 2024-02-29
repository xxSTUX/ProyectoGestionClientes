import { Component } from '@angular/core';
import { TreeMenuComponent } from '../tree-menu/tree-menu.component';
import { SideMenuComponent } from '../side-menu/side-menu.component';
import { HeaderComponent } from '../header/header.component';
import { HttpClientModule} from '@angular/common/http';
import { AngularEditorConfig, AngularEditorModule } from '@kolkov/angular-editor';
import { CreaSeguimientoComponent } from "./crea-seguimiento/crea-seguimiento.component";
import { DatatableComponent } from "../datatable/datatable.component";
import { Subject } from 'rxjs';


@Component({
    selector: 'app-tabmenu',
    standalone: true,
    templateUrl: './tabmenu.component.html',
    styleUrl: './tabmenu.component.css',
    imports: [HeaderComponent, SideMenuComponent, TreeMenuComponent, HttpClientModule, AngularEditorModule, CreaSeguimientoComponent, DatatableComponent]
})
export class TabmenuComponent {
  

}
