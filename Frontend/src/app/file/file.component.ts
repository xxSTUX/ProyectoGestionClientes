import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Folder } from '../../models/folder.model';

@Component({
  selector: 'app-file',
  standalone: true,
  imports: [],
  templateUrl: './file.component.html',
  styleUrl: './file.component.css'
})
export class FileComponent {
  path!: string;
  content!: Observable<any>;
  treeData!: any;

  constructor(private route: ActivatedRoute, private http: HttpClient, private router: Router) {
    this.route.params.subscribe(params => {
      this.path = params['path'];
      this.loadContent();
    });
  }

  loadTreeData() {
    const apiUrl = `https://localhost:7075/api/Cliente`;
    this.http.get(apiUrl).subscribe(data => {
      this.treeData = data;
    });
  }

  loadContent() {
    this.content = this.treeData.find((item: any) => item.path === this.path);
  }
}