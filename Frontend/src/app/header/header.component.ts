import { AuthService } from './../services/auth.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  constructor(private authService: AuthService, private router: Router) { }

  onHomeClick() {
    this.router.navigate(['/']);
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
