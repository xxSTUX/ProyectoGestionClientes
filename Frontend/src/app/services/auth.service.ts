import { Injectable } from '@angular/core';
import { User } from '../../models/user.model';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private validUsers: User[] = [
    { username: 'admin', password: '1234' },
    // Agregar más usuarios válidos
  ];

  isAuthenticated = false;
  currentUser: User | null = null;

  constructor(private cookieService: CookieService) {
    // Verifica si hay cookies al iniciar la aplicación y realiza la autenticación si es necesario
    this.checkAuthentication();
  }

  login(username: string, password: string): boolean {
    const user = this.validUsers.find((u) => u.username.toLowerCase() === username.toLowerCase() && u.password === password);
    if (user) {
      this.isAuthenticated = true;
      this.currentUser = user;
      // Almacena la información del usuario en cookies
      this.cookieService.set('user', JSON.stringify(user));
      return true;
    } else {
      this.isAuthenticated = false;
      this.currentUser = null;
      return false;
    }
  }

  logout() {
    this.isAuthenticated = false;
    this.currentUser = null;
    // Elimina la cookie al cerrar sesión
    this.cookieService.delete('user');
  }

  checkAuthentication(): void {
    const storedUser = this.cookieService.get('user');
    if (storedUser) {
      const user = JSON.parse(storedUser);
      this.currentUser = user;
      this.isAuthenticated = true;
    }
  }
}