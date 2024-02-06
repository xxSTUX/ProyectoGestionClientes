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

  login(username: string, password: string): boolean {
    const user = this.validUsers.find((u) => u.username === username && u.password === password);
    if (user) {
      this.isAuthenticated = true;
      return true;
    } else {
      this.isAuthenticated = false;
      return false;
    }
  }
}