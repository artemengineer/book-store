import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { User } from '../_models/user';
import { AppInitService } from '../_services/app-init.service';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  // TODO: Почему any? Как быть, если класс user уже занят?
  model: User = { id: null, username: null, password: null };
  constructor(
    private authService: AuthService,
    private initService: AppInitService,
    private alertify: AlertifyService,
    private router: Router
  ) {
  }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(
      next => {
        this.alertify.success('Вы успешно вошли');
        this.router.navigate(['/books']);
      },
      error => {
        this.alertify.error('Не удалось войти');
      });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.initService.decodedToken = null;
    this.initService.currentUser = null;
    this.alertify.message('Вы вышли');
    this.router.navigate(['']);
  }
}
