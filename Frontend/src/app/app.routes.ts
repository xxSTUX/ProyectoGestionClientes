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
    { path: ':nodeName', component: ChildComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
