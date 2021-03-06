import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
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

  updateUser(id: number, user: User) {
    return this.http.put(this.baseURL + 'users/' + id, user);
  }
}
