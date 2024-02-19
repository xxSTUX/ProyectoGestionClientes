import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Folder } from '../../models/folder.model';


@Injectable({
  providedIn: 'root'
})
export class FolderService {
  private apiUrl = 'https://localhost:7075/api/Cliente';

  constructor(private http: HttpClient) { }

  getFolders(): Observable<Folder[]> {
    return this.http.get<Folder[]>(this.apiUrl);
  }
}
