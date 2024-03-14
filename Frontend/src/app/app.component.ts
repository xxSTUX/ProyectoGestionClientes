import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ErrorComponent } from './error/error.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, DashboardComponent, ErrorComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Gestion Clientes';
}
