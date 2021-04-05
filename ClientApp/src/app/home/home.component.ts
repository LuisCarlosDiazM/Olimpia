import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgxChartsModule } from '@swimlane/ngx-charts';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public visitantes: Visitante[];
  public parametros: Parametro[];
  public single: any[];
  public view: any[] = [500, 400];

  // options
  showLegend: boolean = true;
  showLabels: boolean = true;

  colorScheme = {
    domain: ['#5AA454', '#E44D25', '#CFC0BB', '#7aa3e5', '#a8385d', '#aae3f5']
  };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Visitante[]>(baseUrl + 'api/Aforo').subscribe(result => {
      this.visitantes = result;
      http.options<Parametro[]>(baseUrl + 'api/Aforo').subscribe(result => {
        this.parametros = result;
        this.single = [
          {
            "name": "Ocupadas",
            "value": Number(this.visitantes.length)
          },
          {
            "name": "Disponibles",
            "value": Number(this.parametros["sillasdisponibles"])
          },
          {
            "name": "No admitida",
            "value": Number(this.parametros["sillasbloqueadas"])
          }          
        ];
      }, error => console.error(error));
    }, error => console.error(error));
  }

  onSelect(event) {
    console.log(event);
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
