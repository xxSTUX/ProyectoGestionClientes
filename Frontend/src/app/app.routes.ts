import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ErrorComponent } from './error/error.component';
import { ForgottenComponent } from './forgotten/forgotten.component';
import { ReestablishComponent } from './reestablish/reestablish.component';
import { TabmenuComponent } from './tabmenu/tabmenu.component';
import { PruebapantallaComponent } from './pruebapantalla/pruebapantalla.component';
import { FileComponent } from './file/file.component';

export const routes: Routes = [
    { path: "", redirectTo: "login", pathMatch: "full" },
    { path: "register", component: RegisterComponent, pathMatch: "full" },
    { path: "login", component: LoginComponent, pathMatch: "full"},
    { path: "dashboard", component: DashboardComponent, pathMatch: "full"},
    { path: "error", component: ErrorComponent, pathMatch: "full"},
    { path: "forgotten", component: ForgottenComponent, pathMatch: "full" },
    { path: "reestablish", component: ReestablishComponent, pathMatch: "full" },
    { path: "tabmenu", component: TabmenuComponent, pathMatch: "full" },
    { path: "pruebapantalla", component: PruebapantallaComponent, pathMatch: "full" },
    { path: 'dashboard/:path', component: FileComponent },
];
