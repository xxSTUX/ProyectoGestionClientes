import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private router: Router, private authService: AuthService) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      valid: true,
    });
  }

  onSubmit() {
    let username = (<HTMLInputElement>document.getElementById('username')).value;
    var password = (<HTMLInputElement>document.getElementById('password')).value;
    if (this.authService.login(username, password)) {
      this.router.navigate(['dashboard']);
    } else {
      this.router.navigate(['error']);
    }
  }

  onRegister() {
    this.router.navigate(['register']);
  }

  onForgotten(){
    this.router.navigate(['forgotten']);
  }
}