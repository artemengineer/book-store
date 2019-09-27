import { Component, OnInit } from '@angular/core';
import { Book } from '../_models/book';
import { AuthService } from '../_services/auth.service';
import { BookService } from '../_services/book.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';


@Component({
  selector: 'app-book-selected-list',
  templateUrl: './book-selected-list.component.html',
  styleUrls: ['./book-selected-list.component.css']
})
export class BookSelectedListComponent implements OnInit {
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
    this.bookService.getSelectedBooks(this.authService.decodedToken.nameid).subscribe(
      (res: Book[]) => {
        this.books = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
