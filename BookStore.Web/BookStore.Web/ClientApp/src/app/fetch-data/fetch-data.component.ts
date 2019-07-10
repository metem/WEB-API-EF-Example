import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public books: Book[];

  constructor(http: HttpClient) {
    http.get<Book[]>('http://localhost:63242/api/book').subscribe(result => {
      this.books = result;
    }, error => console.error(error));
  }
}

interface Book {
  id: number;
  title: string;
  author: string;
  quantity: number;
}
