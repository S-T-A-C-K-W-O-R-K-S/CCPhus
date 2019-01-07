import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})

export class UserService {
  baseURL = environment.apiURL;

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseURL + 'users');
  }

  getUser(id: number) : Observable<User> {
    return this.http.get<User>(this.baseURL + 'users/' + id);
  }
}

//TODO: use this with Section 9_82-85 for displaying the list of employees in a company