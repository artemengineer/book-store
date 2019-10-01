import { Component, Input, OnInit } from '@angular/core';
import { Book } from '../_models/book';
import { BookService } from '../_services/book.service';


@Component({
  selector: 'app-book-card',
  templateUrl: './book-card.component.html',
  styleUrls: ['./book-card.component.css']
})
export class BookCardComponent implements OnInit {
  @Input() book: Book;

  constructor(
    private bookService: BookService
  ) {
  }

  ngOnInit() {
  }


  toggleBookSelection() {
    this.bookService.toggleBookSelection(this.book);
  }
}
