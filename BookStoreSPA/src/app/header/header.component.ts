import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  model: any = {}; // TODO: Почему any? Как быть, если класс user уже занят?

  constructor(private authService: AuthService, private alertify: AlertifyService, private router: Router) {
  }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(
      next => {
        this.alertify.success('Вы успешно вошли');
      },
      error => {
        this.alertify.error('Не удалось войти');
      },
      () => { // TODO: Это же finaly? Зачем мы куда-то переходим, если не знаем точно, что вошли?
        this.router.navigate(['/books']);
      }
    );
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.authService.decodedToken = null;
    this.authService.currentUser = null;
    this.alertify.message('Вы вышли');
    this.router.navigate(['']);
  }
}
