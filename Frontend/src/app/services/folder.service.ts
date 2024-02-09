import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Folder } from '../../models/folder.model';


@Injectable({
  providedIn: 'root'
})
export class FolderService {
  private apiUrl = 'https://65c36e8e39055e7482c0e15e.mockapi.io/folder';

  constructor(private http: HttpClient) { }

  getFolders(): Observable<Folder[]> {
    return this.http.get<Folder[]>(this.apiUrl);
  }
}
