import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ErrorComponent } from './error/error.component';
import { ForgottenComponent } from './forgotten/forgotten.component';
import { ReestablishComponent } from './reestablish/reestablish.component';
import { PruebapantallaComponent } from './pruebapantalla/pruebapantalla.component';
import { DatatableComponent } from './datatable/datatable.component';
import { ChildComponent } from './child/child.component';
import { LicitacionesComponent } from './child/licitaciones/licitaciones.component';
import { SeguimientosComponent } from './child/seguimientos/seguimientos.component';
import { NgModule } from '@angular/core';
import { CreaClienteComponent } from './crea-cliente/crea-cliente.component';
import { ModificaclienteComponent } from './modificacliente/modificacliente.component';
import { CreaProyectoComponent } from './crea-proyecto/crea-proyecto.component';
import { HomeComponent } from './home/home.component';
import { DatatableProyectosComponent } from './datatableProyectos/datatableProyectos.component';
import { CreaSeguiminetoComponent } from './crea-seguimineto/crea-seguimineto.component';
import { CreaSeguimientoComponent } from './tabmenu/crea-seguimiento/crea-seguimiento.component';
import { DatatableSeguimientosComponent } from './datatableSeguimientos/datatableSeguimientos.component';
import { DatatableLicitacionesComponent } from './datatableLicitaciones/datatableLicitaciones.component';
import { DatatableAreaComponent } from './datatableArea/datatableArea.component';
import { EliminarClienteComponent } from './eliminar-cliente/eliminar-cliente.component';


export const routes: Routes = [
    { path: "", redirectTo: "login", pathMatch: "full" },
    { path: "register", component: RegisterComponent, pathMatch: "full" },
    { path: "login", component: LoginComponent, pathMatch: "full"},
    { path: "dashboard", component: DashboardComponent, pathMatch: "full"},
    { path: "error", component: ErrorComponent, pathMatch: "full"},
    { path: "forgotten", component: ForgottenComponent, pathMatch: "full" },
    { path: "reestablish", component: ReestablishComponent, pathMatch: "full" },
    { path: "pruebapantalla", component: PruebapantallaComponent, pathMatch: "full" },
    { path: "modificacliente", component: ModificaclienteComponent, pathMatch: "full"},
    { path: "datatable", component: DatatableComponent, pathMatch: "full" },
    { path: "creaproyecto",component:CreaProyectoComponent, pathMatch: "full" },
    { path: "creacliente", component: CreaClienteComponent, pathMatch: "full" },
    { path: 'licitaciones', component: LicitacionesComponent,  },
    { path: 'seguimientos', component: SeguimientosComponent,  },
    { path: ':home', component: HomeComponent },
    { path: ':nodeName', component: ChildComponent },
    { path: "datatableProyecto", component: DatatableProyectosComponent, pathMatch: "full" },
    { path: "datatableSeguimiento", component: DatatableSeguimientosComponent, pathMatch: "full" },
    { path: "datatableLicitaciones", component: DatatableLicitacionesComponent, pathMatch: "full" },
    { path: "datatableArea", component: DatatableAreaComponent, pathMatch: "full" },
    { path: "creaseguimiento",component:CreaSeguimientoComponent, pathMatch: "full" },
    { path: "eliminarCliente", component: EliminarClienteComponent, pathMatch: "full" },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
