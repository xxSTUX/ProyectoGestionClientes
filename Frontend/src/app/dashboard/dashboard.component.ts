import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
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
import { SplitterModule } from "primeng/splitter";
import { LoadingComponent } from '../loading/loading.component';


@Component({
    selector: 'app-dashboard',
    standalone: true,
    templateUrl: './dashboard.component.html',
    styleUrl: './dashboard.component.css',
    imports: [HeaderComponent, SideMenuComponent, TreeMenuComponent, TabmenuComponent, ChildComponent, NgIf, AsyncPipe, ErrorComponent, LicitacionesComponent, SeguimientosComponent, SplitterModule, LoadingComponent]
})
export class DashboardComponent implements OnInit {

  halal = true;
  //Fragment es la condicion que hace que se muestre un componente u otro segun el valor de este en el div
  fragment$: Observable<string> = new Observable<string>;

  constructor(private route: ActivatedRoute, private router: Router, private cdr: ChangeDetectorRef) { }
  //Suscribirse al evento navigationEnd para actulizar el div dinamico con el componente que corresponda cuando se produzca
  ngOnInit(): void {
    console.log("Componente principal inicializado");
    this.updateFragmentObservable();
    // Observa los cambios de la ruta y actualiza el fragment$
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe(() => {
      this.updateFragmentObservable();
      console.log("La ruta ha cambiado");
      this.cdr.detectChanges(); // Actualizar la vista
    });
  }

updateFragmentObservable(): void {
    console.log("fragmentupdate");
    this.fragment$ = this.route.fragment.pipe(
      map(fragment => fragment || 'default')
    );
    this.fragment$.subscribe(fragment => {
      console.log("Valor del fragmento:", fragment);
    });
}
getFragmentTipoNodo(fragment: string): string {
  const fragmentType = fragment.split('=')[0];
  return fragmentType;
}

}

