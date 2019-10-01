import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from '../_models/user';


@Injectable()
export class AppInitService {
  decodedToken: any;
  currentUser: User;
  jwtHelper = new JwtHelperService();

  constructor() {
  }

  Init() {
    return new Promise<void>((resolve, reject) => {
      const token = localStorage.getItem('token');
      const user: User = JSON.parse(localStorage.getItem('user'));
      if (token) {
        this.decodedToken = this.jwtHelper.decodeToken(token);
      }
      if (user) {
        this.currentUser = user;
      }
      resolve();
    });
  }
}
