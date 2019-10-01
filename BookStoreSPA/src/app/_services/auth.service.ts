import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
import { Observable } from 'rxjs';
import { AppInitService } from './app-init.service';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl + 'auth/';

  constructor(private http: HttpClient, private initService: AppInitService,) {
  }

  // TODO: Почему any?
  // Поменял на User
  login(model: User): Observable<void> {
    return this.http.post(this.baseUrl + 'login', model)
      .pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
            localStorage.setItem('user', JSON.stringify(user.user));
            this.initService.decodedToken = this.initService.jwtHelper.decodeToken(user.token);
            this.initService.currentUser = user.user;
          }
        })
      );
  }

  register(user: User): Observable<Object> {
    return this.http.post(this.baseUrl + 'register', user);
  }

  loggedIn(): boolean {
    const token = localStorage.getItem('token');
    return !this.initService.jwtHelper.isTokenExpired(token);
  }
}
