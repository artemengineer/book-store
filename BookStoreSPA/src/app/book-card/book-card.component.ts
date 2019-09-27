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

  selectedBook(id: number) {
    this.bookService.selectedBook(this.authService.decodedToken.nameid, id).subscribe(data => {
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

  detail(id: number) {
    this.router.navigate(['books/' + id]);
  }
}
