import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { SideMenuComponent } from '../side-menu/side-menu.component';
import { TreeMenuComponent } from '../tree-menu/tree-menu.component';
import { TabmenuComponent } from '../tabmenu/tabmenu.component';
import { ChildComponent } from '../child/child.component';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { filter, map } from 'rxjs/operators';
import { AsyncPipe, NgIf } from '@angular/common';
import { ErrorComponent } from '../error/error.component';
import { LicitacionesComponent } from "../child/licitaciones/licitaciones.component";
import { SeguimientosComponent } from "../child/seguimientos/seguimientos.component";
import { Observable } from 'rxjs';


@Component({
    selector: 'app-dashboard',
    standalone: true,
    templateUrl: './dashboard.component.html',
    styleUrl: './dashboard.component.css',
    imports: [HeaderComponent, SideMenuComponent, TreeMenuComponent, TabmenuComponent, ChildComponent, NgIf, AsyncPipe, ErrorComponent, LicitacionesComponent, SeguimientosComponent]
})
export class DashboardComponent implements OnInit {
  fragment$: Observable<string> = new Observable<string>;

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.fragment$ = this.route.fragment.pipe(
      map(fragment => fragment || 'default')
    );
    // Observa los cambios de la ruta y actualiza el fragment$
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe(() => {
      this.fragment$ = this.route.fragment.pipe(
        map(fragment => fragment || 'default')
      );
    });
  }
}
