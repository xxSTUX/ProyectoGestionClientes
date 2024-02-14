import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-forgotten',
  standalone: true,
  imports: [],
  templateUrl: './forgotten.component.html',
  styleUrl: './forgotten.component.css'
})
export class ForgottenComponent {
    forgottenForm: FormGroup;
  
    constructor(private fb: FormBuilder, private router: Router) {
      this.forgottenForm = this.fb.group({
        username: ['', Validators.required],
        valid: true,
      });
    }

    public click(){
      this.router.navigate(['reestablish']);
    }
}
