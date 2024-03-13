import { ChangeDetectorRef, Component, ComponentFactoryResolver, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
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
import { CreaClienteComponent } from '../crea-cliente/crea-cliente.component';
import { AnonymousSubject } from 'rxjs/internal/Subject';




@Component({
    selector: 'app-dashboard',
    standalone: true,
    templateUrl: './dashboard.component.html',
    styleUrl: './dashboard.component.css',
    imports: [HeaderComponent, SideMenuComponent, TreeMenuComponent, TabmenuComponent, ChildComponent, NgIf, AsyncPipe, ErrorComponent, LicitacionesComponent, SeguimientosComponent, SplitterModule, LoadingComponent]
})
export class DashboardComponent{
  halal = true;
  private componentRef: any;
  @ViewChild('contenedor', { read: ViewContainerRef }) contenedor!: ViewContainerRef;
  constructor(private route: ActivatedRoute, private router: Router, private cdr: ChangeDetectorRef, private componentFactoryResolver: ComponentFactoryResolver) { }
  
  creaComponente1(){
    const contenedor = document.getElementById("contenedor");
    if(contenedor!=null){
      const componentFactory = this.componentFactoryResolver.resolveComponentFactory(TabmenuComponent);
      if(this.componentRef){
        this.componentRef.destroy();
      }
      this.componentRef = this.contenedor.createComponent(componentFactory);
    }
  }
  creaComponente2(){
    const contenedor = document.getElementById("contenedor");
    if(contenedor!=null){
      const componentFactory = this.componentFactoryResolver.resolveComponentFactory(CreaClienteComponent);
      if(this.componentRef){
        this.componentRef.destroy();
      }
      this.componentRef = this.contenedor.createComponent(componentFactory);
    }
  }

}

