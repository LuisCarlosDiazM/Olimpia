import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'hinchas-app',
  templateUrl: './hinchas.component.html',
})
export class HinchasComponent {
  public NumID: string;
  public TipoID: string
  public Nombre: string
  public Telefono: number
  public Genero: string
  public EMail: string
  public FechaNacimiento: Date
  private httpclient: HttpClient;
  private baseURL: string;
  public resp: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpclient = http;
    this.baseURL = baseUrl;
  }

  saveContact() {
    const headers = { 'Content-Type': 'application/json' };
    const body = "{numID:" + this.NumID +
      ",tipoID:'" + this.TipoID +
      "',nombre:'" + this.Nombre +
      "',telefono:'" + this.Telefono +
      "',genero:'" + this.Genero +
      "',eMail:'" + this.EMail +
      "',fechaNacimiento:'" + this.FechaNacimiento +
      "'}";
    this.httpclient.post<any>(this.baseURL + 'api/Hinchas', body, { headers }).subscribe(data => {
      this.resp = data;
    }, error => {
      console.error(error);
    });
  }
}

interface Hincha {
  NumID: string;
  TipoID: string
  Nombre: string
  Telefono: number
  Genero: string
  EMail: string
  FechaNacimiento: Date
}
