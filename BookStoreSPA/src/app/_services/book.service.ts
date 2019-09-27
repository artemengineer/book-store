import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Book } from '../_models/book';


@Injectable({
  providedIn: 'root'
})
export class BookService {
  baseUrl = environment.apiUrl + 'book/';

  constructor(private http: HttpClient) {
  }

  getBooks(id: number) {
    return this.http.get<Book[]>(this.baseUrl + id);
  }

  getSelectedBooks(id: number) {
    return this.http.get<Book[]>(this.baseUrl + 'select/' + id);
  }

  getDetailBook(userId: number, bookId: number) {
    return this.http.get<Book>(this.baseUrl + 'detail/' + userId + '/' + bookId);
  }

  selectedBook(userId: number, bookId: number) {
    return this.http.post(this.baseUrl + 'select/', { userId: userId, bookId: bookId });
  }
}
