import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {


  public eventos: any = []; //ele existe como um array []
  public eventosFiltrados: any = [];
  widthImg: number = 100;
  marginImg: number = 2;
  mostrarImagem:boolean = true;
  private _filtroLista: string = '';

  constructor(private http: HttpClient) {

  }

  public get filtroLista() : string{
    return this._filtroLista;
  }

  public set filtroLista(filtro: string){
    this._filtroLista = filtro;
    this.eventosFiltrados = this._filtroLista ? this.filtrarEventos(this.filtroLista) :  this.eventos;
    //se tem valor filtro lista, passo o parametro para a funcao filtrarEventos senão
    //retorna eventos
  }

  filtrarEventos(filtrarPor: string) : any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento : any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1 || evento.dataEvento.toLocaleLowerCase().indexOf(filtrarPor)!==-1
    )
  }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos():void{
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados =  this.eventos;
      },
      error => console.log(error)
    );
  }

  alterarImagem(){
    this.mostrarImagem = !this.mostrarImagem;
  }

}
