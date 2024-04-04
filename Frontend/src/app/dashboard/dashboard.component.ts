import { AngularSplitModule } from 'angular-split';
import { ChangeDetectorRef, Component, ComponentFactoryResolver, OnInit, Output, ViewChild, ViewContainerRef } from '@angular/core';
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
import { HomeComponent } from '../home/home.component';
import { CreaClienteComponent } from "../crea-cliente/crea-cliente.component";
import { DatatableComponent } from '../datatable/datatable.component';
import { DatatableProyectosComponent } from '../datatableProyectos/datatableProyectos.component';
import { contains } from 'jquery';
import { CreaProyectoComponent } from '../crea-proyecto/crea-proyecto.component';
import { CreaSeguiminetoComponent } from "../crea-seguimineto/crea-seguimineto.component";


@Component({
    selector: 'app-dashboard',
    standalone: true,
    templateUrl: './dashboard.component.html',
    styleUrl: './dashboard.component.css',
    imports: [HeaderComponent, TreeMenuComponent, TabmenuComponent, ChildComponent, NgIf, AsyncPipe, ErrorComponent, LicitacionesComponent, SeguimientosComponent, LoadingComponent, ModificaclienteComponent, HomeComponent, CreaClienteComponent, AngularSplitModule, AngularSplitModule, DatatableComponent, DatatableProyectosComponent, CreaProyectoComponent, CreaSeguiminetoComponent]
})
export class DashboardComponent implements OnInit {
  private buttonBaseText = "Crear nuevo ";
  public getJsonValue: any;
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
  openCreaCliente(event: Event) {
    event.preventDefault();
  }
  openCreaProyecto(event: Event) {
    event.preventDefault();
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

  toggleTree() {
    const contenedor = document.getElementById("contenedor");
    if (contenedor != null) {
      const componentFactory = this.componentFactoryResolver.resolveComponentFactory(TreeMenuComponent);
      if (this.isTreeVisible) {
        // Si el árbol ya está visible, lo eliminamos
        if (this.componentRef) {
          this.componentRef.destroy();
        }
        this.isTreeVisible = false;
      } else {
        // Si el árbol no está visible, lo creamos
        this.componentRef = this.contenedor.createComponent(componentFactory);
        this.isTreeVisible = true;
      }
    }
  }
  eliminaTree() {
    if (this.componentRef) {
      this.componentRef.destroy();
      this.isTreeVisible = false;
    }
  }
  public seleccionarCliente(cliente:any){
    console.log(cliente)
    alert(cliente.nombre);
    const contenedor = document.getElementById("tablaClientes");
    const tabMenu = document.getElementById("tabMenu");
    var btn = document.getElementById("botonCrearElemento")
    var txt = document.getElementById("Titulo") ;
    contenedor?.classList.add("d-none");
    tabMenu?.classList.remove("d-none");
    if (txt) txt.innerHTML = cliente.nombre;
    this.getJsonValue = cliente;
  }

  getClienteId(){
    return this.getJsonValue.id;
  }
  getClienteProyectos(){
    return this.getJsonValue.proyectos;
  }
  getClienteSeguimientos(){
    return this.getJsonValue.seguimientos;
  }
  getClienteLicitaciones(){
    return this.getJsonValue.licitaciones;
  }
  getClienteArea(){
    return this.getJsonValue.areas;
  }
  public reload(){
    window.location.reload()
  }

  creaProyecto(){
    const creaProyecto = document.getElementById("proyecto");
    if(creaProyecto?.className === "d-none"){
      creaProyecto.classList.remove("d-none");
      return;
    }

    creaProyecto?.classList.add("d-none");
  }
}