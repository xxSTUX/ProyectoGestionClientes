import { Injectable } from '@angular/core';
import { User } from '../../models/user.model';

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

  login(username: string, password: string): boolean {
    const user = this.validUsers.find((u) => u.username.toLowerCase() === username.toLowerCase() && u.password === password);
    if (user) {
      this.isAuthenticated = true;
      this.currentUser = user;
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
  }
}