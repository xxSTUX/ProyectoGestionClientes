import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LicitacionesComponent } from './licitaciones/licitaciones.component';

import { NgIf } from '@angular/common';

@Component({
  selector: 'app-child',
  standalone: true,
  imports: [LicitacionesComponent, NgIf],
  templateUrl: './child.component.html',
  styleUrl: './child.component.css'
})
export class ChildComponent {
  nodeName: string = '';

  constructor(private route: ActivatedRoute) {
    const nodeName = this.route.snapshot.paramMap.get('nodeName');
    this.nodeName = nodeName !== null ? nodeName : '';
  }
}