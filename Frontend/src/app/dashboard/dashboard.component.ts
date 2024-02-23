import { Component } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { SideMenuComponent } from '../side-menu/side-menu.component';
import { TreeMenuComponent } from '../tree-menu/tree-menu.component';
import { TabmenuComponent } from '../tabmenu/tabmenu.component';
import { ChildComponent } from '../child/child.component';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { AsyncPipe, NgIf } from '@angular/common';
import { ErrorComponent } from '../error/error.component';


@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [HeaderComponent, SideMenuComponent,TreeMenuComponent,TabmenuComponent, ChildComponent, NgIf, AsyncPipe, ErrorComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  fragment$ = this.route.fragment.pipe(map(fragment => fragment || 'default'));

  constructor(private route: ActivatedRoute) { }
}