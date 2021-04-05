import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http';

@Component({
  selector: "hinchastotal-app",
  templateUrl: "./hinchastotal.component.html"
})

export class hinchastotalComponent {
  public hinchas: Hincha[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    http.get<Hincha[]>(baseUrl + 'api/Hinchas').subscribe(result => {
      this.hinchas = result;
    }, error => console.error(error));
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
