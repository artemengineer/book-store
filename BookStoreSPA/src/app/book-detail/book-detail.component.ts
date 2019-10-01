import { Component, OnInit } from '@angular/core';
import { Book } from '../_models/book';
import { BookService } from '../_services/book.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { AppInitService } from '../_services/app-init.service';


@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit {
  book: Book;

  constructor(
    private bookService: BookService,
    private initService: AppInitService,
    private route: ActivatedRoute,
    private alertify: AlertifyService
  ) {
  }

  ngOnInit() {
    this.loadBooks();
  }

  loadBooks() {
    this.bookService.getDetailedBook(this.initService.decodedToken.nameid, this.route.snapshot.params['id']).subscribe(
      (res: Book) => {
        this.book = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  toggleBookSelection() {
    this.bookService.toggleBookSelection(this.book);
  }
}
