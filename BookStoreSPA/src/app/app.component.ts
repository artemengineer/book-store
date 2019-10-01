import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor() {
  }

  ngOnInit(): void {
    // TODO: Есть более идеоматический способ) Глянь APP_INITIALIZER
    // Answer:
    // Создал класс AppInitService для APP_INITIALIZER
  }
}
