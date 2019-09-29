import { Component, Input, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';
import { Book } from '../_models/book';
import { BookService } from '../_services/book.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-book-card',
  templateUrl: './book-card.component.html',
  styleUrls: ['./book-card.component.css']
})
export class BookCardComponent implements OnInit {
  @Input() book: Book;

  constructor(
    private authService: AuthService,
    private bookService: BookService,
    private router: Router,
    private alertify: AlertifyService
  ) {
  }

  ngOnInit() {
  }

  selectedBook(id: number) { // TODO: Надо бы в сервис это мувнуть. Ну, и selected не то слово, наверное, не глагол потомучто
    this.bookService.selectedBook(this.authService.decodedToken.nameid, id).subscribe(data => { // TODO: хорошее слово для этого toggle (переключить), типа toggleBookSelection или типа того. Чтобы было чуть больше феншуя, можно возвращать тут войд, а статус запросить отдельно.
      this.book.isSelected = !this.book.isSelected;
      if (this.book.isSelected) {
        this.alertify.success('Добавили в избранное: ' + this.book.name);
      } else {
        this.alertify.warning('Удалили из избранного: ' + this.book.name);
      }
    }, error => {
      this.alertify.error(error);
    });
  }

  detail(id: number) { // TODO: не глагол. Плюс, прямо в темплейте можно подобные ссылки мутить
    this.router.navigate(['books/' + id]);
  }
}
