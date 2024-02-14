import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reestablish',
  standalone: true,
  imports: [],
  templateUrl: './reestablish.component.html',
  styleUrl: './reestablish.component.css'
})
export class ReestablishComponent {
  reestablishForm: FormGroup;
  
  constructor(private fb: FormBuilder, private router: Router) {
    this.reestablishForm = this.fb.group({
      password: ['', Validators.required],
      passwordValidate: ['', Validators.required],
    });
    }

  public click(){
    const password = (<HTMLInputElement>document.getElementById('password')).value;
    const passwordValidate = (<HTMLInputElement>document.getElementById('passwordValidate')).value;
    if(password && passwordValidate){
      if(password===passwordValidate){
        alert('La contraseña ha sido reestablecida');
        this.router.navigate(['login']);
      }else{
        alert('La contraseña debe ser la misma en los dos campos');
      }
    }else{
    }
  }
}
