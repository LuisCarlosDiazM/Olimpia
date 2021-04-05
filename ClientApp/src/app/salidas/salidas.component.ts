import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'salidas-app',
  templateUrl: './salidas.component.html'
})
export class SalidasComponent {
  public NumeroID: number;
  public visitantes: Visitante[];
  private httpclient: HttpClient;
  private baseURL: string;
  public resp: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpclient = http;
    this.baseURL = baseUrl;
    http.get<Visitante[]>(baseUrl + 'api/Aforo').subscribe(result => {
      this.visitantes = result;
    }, error => console.error(error));
  }

  saveContact() {
    this.httpclient.delete<any>(this.baseURL + 'api/Aforo/' + this.NumeroID.toString()).subscribe(data => {
      this.resp = data;
      this.httpclient.get<Visitante[]>(this.baseURL + 'api/Aforo').subscribe(result => {
        this.visitantes = result;
      }, error => console.error(error));
    }, error => {
      console.error(error);
    });
  }
}

interface Visitante {
  NumID: string;
  Entrada: number;
  FechaIngreso: Date;
}
