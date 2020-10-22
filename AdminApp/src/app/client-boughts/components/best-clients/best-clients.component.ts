import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ClientBought } from '../../models/clientBought';

@Component({
  selector: 'app-best-clients',
  templateUrl: './best-clients.component.html',
  styleUrls: ['./best-clients.component.css']
})
export class BestClientsComponent implements OnInit {
  public clientBoughts: ClientBought[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ClientBought[]>(baseUrl + 'clients').subscribe(result => {
      this.clientBoughts = result;
    }, error => console.error(error));
  }
  ngOnInit(): void {

  }
}
