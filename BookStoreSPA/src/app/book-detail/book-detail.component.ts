import { Component, OnInit } from '@angular/core';
import { Book } from '../_models/book';
import { AuthService } from '../_services/auth.service';
import { BookService } from '../_services/book.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';


@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit {
  book: Book;

  constructor(
    private authService: AuthService,
    private bookService: BookService,
    private route: ActivatedRoute,
    private router: Router,
    private alertify: AlertifyService
  ) {
  }

  ngOnInit() {
    this.loadBooks();
  }

  loadBooks() {
    this.bookService.getDetailBook(this.authService.decodedToken.nameid, this.route.snapshot.params['id']).subscribe(
      (res: Book) => {
        this.book = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
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
}
