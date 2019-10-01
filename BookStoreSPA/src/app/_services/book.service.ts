import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Book } from '../_models/book';
import { AuthService } from './auth.service';
import { AlertifyService } from './alertify.service';
import { Observable } from 'rxjs';
import { AppInitService } from './app-init.service';


@Injectable({
  providedIn: 'root'
})
export class BookService {
  baseUrl = environment.apiUrl + 'book/';

  constructor(
    private http: HttpClient,
    private initService: AppInitService,
    private authService: AuthService,
    private alertify: AlertifyService
  ) {
  }

  getBooks(userId: number): Observable<Book[]> {
    return this.http.get<Book[]>(this.baseUrl + userId);
  }

  getSelectedBooks(userId: number): Observable<Book[]> {
    return this.http.get<Book[]>(this.baseUrl + 'selected/' + userId);
  }

  getDetailedBook(userId: number, bookId: number): Observable<Book> {
    return this.http.get<Book>(this.baseUrl + 'detailed/' + userId + '/' + bookId);
  }


  toggleBookSelection(book: Book): void {
    this.http.post(this.baseUrl + 'toggle-book-selection', {
      userId: this.initService.decodedToken.nameid,
      bookId: book.id
    }).subscribe(data => {
      book.isSelected = !book.isSelected;
      if (book.isSelected) {
        this.alertify.success('Добавили в избранное: ' + book.name);
      } else {
        this.alertify.warning('Удалили из избранного: ' + book.name);
      }
    }, error => {
      this.alertify.error(error);
    });
  }
}
