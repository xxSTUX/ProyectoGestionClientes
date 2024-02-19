import { Component } from '@angular/core';
import { TabmenuComponent } from '../tabmenu/tabmenu.component';
import { SideMenuComponent } from '../side-menu/side-menu.component';
import { TreeMenuComponent } from '../tree-menu/tree-menu.component';
import { HeaderComponent } from '../header/header.component';

@Component({
  selector: 'app-pruebapantalla',
  standalone: true,
  imports: [TabmenuComponent, SideMenuComponent, TreeMenuComponent,HeaderComponent],
  templateUrl: './pruebapantalla.component.html',
  styleUrl: './pruebapantalla.component.css'
})
export class PruebapantallaComponent {

}
