import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'entradas-app',
  templateUrl: './entradas.component.html'
})
export class EntradasComponent {
  public NumeroID: number;
  public NumeroEntrada: string;
  private httpclient: HttpClient;
  private baseURL: string;
  public resp: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpclient = http;
    this.baseURL = baseUrl;
  }

  saveContact() {
    
    const headers = { 'Content-Type': 'application/json' };
    const body = this.NumeroID.toString();
    this.httpclient.post<any>(this.baseURL + 'api/Aforo/' + this.NumeroEntrada, body, { headers }).subscribe(data => {
      this.resp = data;
    }, error => {
      console.error(error);
    });
  }
}
