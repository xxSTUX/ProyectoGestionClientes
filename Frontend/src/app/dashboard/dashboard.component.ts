import { Component } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { SideMenuComponent } from '../side-menu/side-menu.component';
import { TreeMenuComponent } from '../tree-menu/tree-menu.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [HeaderComponent, SideMenuComponent,TreeMenuComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {

}
