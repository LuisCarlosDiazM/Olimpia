import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http';

@Component({
  selector: "aforototal-app",
  templateUrl: "./aforototal.component.html"
})

export class aforototalComponent {
  public visitantes: Visitante[];
  public parametros: Parametro[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    http.get<Visitante[]>(baseUrl + 'api/Aforo').subscribe(result => {
      this.visitantes = result;
    }, error => console.error(error));

    http.options<Parametro[]>(baseUrl + 'api/Aforo').subscribe(result => {
      this.parametros = result;
    }, error => console.error(error));
  }
}

interface Visitante {
  NumID: string;
  Entrada: number;
  FechaIngreso: Date;
}

interface Parametro {
  Nombre: string;
  Valor: string;
}
