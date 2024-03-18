import { withInterceptorsFromDi } from '@angular/common/http';
import { ChangeDetectorRef, Component, ComponentFactoryResolver, ElementRef, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
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
import { ModificaclienteComponent } from "../modificacliente/modificacliente.component";
import { LoadingComponent } from '../loading/loading.component';
import { AngularSplitModule } from 'angular-split';


@Component({
  selector: 'app-dashboard',
  standalone: true,
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
  imports: [HeaderComponent, TreeMenuComponent, TabmenuComponent, ChildComponent, NgIf, AsyncPipe, ErrorComponent, LicitacionesComponent, SeguimientosComponent, LoadingComponent, ModificaclienteComponent, AngularSplitModule]
})
export class DashboardComponent implements OnInit {
  showTreeMenu: boolean = true;
  private componentRef: any;
  public isTreeVisible: boolean = false;
  @ViewChild('contenedor', { read: ViewContainerRef }) contenedor!: ViewContainerRef;
  
  //Fragment es la condicion que hace que se muestre un componente u otro segun el valor de este en el div
  fragment$: Observable<string> = new Observable<string>;

  constructor(private route: ActivatedRoute, private router: Router, private cdr: ChangeDetectorRef, private componentFactoryResolver: ComponentFactoryResolver) { }

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

  creaTree() {
    const contenedor = document.getElementById("contenedor");
    if (contenedor != null) {
      const componentFactory = this.componentFactoryResolver.resolveComponentFactory(TreeMenuComponent);
      if (this.componentRef) {
        this.componentRef.destroy();
      }
      this.componentRef = this.contenedor.createComponent(componentFactory);
      this.showTreeMenu = false;
      this.isTreeVisible = true;
    }
  }

  eliminaTree() {
    if (this.componentRef) {
      this.componentRef.destroy();
      this.showTreeMenu = true;
      this.isTreeVisible = false;
    }
  }

}