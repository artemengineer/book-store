import { Component, OnInit } from '@angular/core';
import { Book } from '../_models/book';
import { BookService } from '../_services/book.service';
import { AlertifyService } from '../_services/alertify.service';
import { AppInitService } from '../_services/app-init.service';


@Component({
  selector: 'app-book-selected-list',
  templateUrl: './book-selected-list.component.html',
  styleUrls: ['./book-selected-list.component.css']
})
export class BookSelectedListComponent implements OnInit {
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
    this.bookService.getSelectedBooks(this.initService.decodedToken.nameid).subscribe(
      (res: Book[]) => {
        this.books = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
