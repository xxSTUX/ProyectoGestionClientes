import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-error',
  standalone: true,
  imports: [],
  templateUrl: './error.component.html',
  styleUrl: './error.component.css'
})
export class ErrorComponent {
  constructor(private authService: AuthService, private router: Router) {}

  volverAPaginaPrincipal() {
    this.authService.checkAuthentication();

    if (this.authService.isAuthenticated) {
      this.router.navigate(['dashboard']);
    } else {
      this.router.navigate(['login']);
    }
  }
}