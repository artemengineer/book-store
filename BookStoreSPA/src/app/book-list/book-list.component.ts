import { Component, OnInit } from '@angular/core';
import { Book } from '../_models/book';
import { BookService } from '../_services/book.service';
import { AlertifyService } from '../_services/alertify.service';
import { AppInitService } from '../_services/app-init.service';


@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  books: Book[];

  constructor(
    private initService: AppInitService,
    private bookService: BookService,
    private alertify: AlertifyService
  ) {
  }

  ngOnInit() {
    this.loadBooks();
  }

  loadBooks() {
    this.bookService.getBooks(this.initService.decodedToken.nameid).subscribe(
      (res: Book[]) => {
        this.books = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
