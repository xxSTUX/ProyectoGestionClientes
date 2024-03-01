import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DataTablesModule } from 'angular-datatables';

@Component({
  selector: 'app-licitacionestable',
  standalone: true,
  imports: [DataTablesModule, HttpClientModule, CommonModule],
  templateUrl: './licitacionestable.component.html',
  styleUrl: './licitacionestable.component.css'
})
export class LicitacionestableComponent implements OnInit{
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
  public getJsonValue: any;

}
