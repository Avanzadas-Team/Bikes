import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Seller } from '../../models/seller';

@Component({
  selector: 'app-sells',
  templateUrl: './sells.component.html',
  styleUrls: ['./sells.component.css']
})
export class SellsComponent implements OnInit {
  public Sellers: Seller[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Seller[]>(baseUrl + 'sellers').subscribe(result => {
      this.Sellers = result;
    }, error => console.error(error));
  }
  ngOnInit() {
  }

}
