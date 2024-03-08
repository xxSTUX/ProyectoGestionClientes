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


@Component({
    selector: 'app-dashboard',
    standalone: true,
    templateUrl: './dashboard.component.html',
    styleUrl: './dashboard.component.css',
    imports: [HeaderComponent, SideMenuComponent, TreeMenuComponent, TabmenuComponent, ChildComponent, NgIf, AsyncPipe, ErrorComponent, LicitacionesComponent, SeguimientosComponent, SplitterModule]
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

  const fragmentType = fragment;

// Buscar la parte deseada de la URL usando una expresión regular
const regex = /#\/([^=]+)=/; // Captura todo lo que está entre '#/' y '='
const match = fragmentType.match(regex);
let fragResultado = "";

if (match && match.length > 1) {
    const fragmet = match[1];
    fragResultado = fragment;
    console.log("fragmet a pasar:", fragmet);
} else {
    console.error("Error al obtener elfragmet");
}
  return fragResultado;
}

}

