import { AuthService } from './../services/auth.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DashboardComponent } from '../dashboard/dashboard.component';
@Component({
  selector: 'app-header',
  standalone: true,
  imports: [DashboardComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  constructor(private authService: AuthService, private router: Router, private dashboard: DashboardComponent) { }

  onHomeClick() {
    this.router.navigate(['/dashboard']);
    this.dashboard.reload()
  }

  onProfileClick() {
    this.router.navigate(['/profile']); // Navegar a la ruta del perfil del usuario
  }

  onAccountClick() {
    this.router.navigate(['/account']); // Navegar a la configuración de la cuenta
  }

  onTasksClick() {
    this.router.navigate(['/tasks']); // Navegar a las tareas del usuario
  }

  onLogoutClick() {
    this.authService.logout();
    this.router.navigate(['login']); // Redireccionar al usuario a la página de inicio de sesión después de cerrar sesión
  }
}
