import { Component, OnInit } from '@angular/core';
import { Book } from '../_models/book';
import { AuthService } from '../_services/auth.service';
import { BookService } from '../_services/book.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';


@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  books: Book[];

  constructor(
    private authService: AuthService,
    private bookService: BookService,
    private route: ActivatedRoute,
    private alertify: AlertifyService
  ) {
  }

  ngOnInit() {
    this.loadBooks();
  }

  loadBooks() {
    this.bookService.getBooks(this.authService.decodedToken.nameid).subscribe(
      (res: Book[]) => {
        this.books = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
