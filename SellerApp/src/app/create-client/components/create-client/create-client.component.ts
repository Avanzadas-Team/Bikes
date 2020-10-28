import { AuthService } from './../../../auth.service';
import { Component, OnInit, Inject, ViewEncapsulation} from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import {MatCalendarCellClassFunction} from '@angular/material/datepicker';

@Component({
  selector: 'app-create-client',
  templateUrl: './create-client.component.html',
  styleUrls: ['./create-client.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class CreateClientComponent implements OnInit {

  name : string = "";
  lname : string = "";
  city : string = "";
  street : string = "";
  postalCode : string = "";
  email : string = "";
  state : string = "";
  create: number = -1;

  constructor(private http: HttpClient,
    private auth: AuthService) { 

    }

  ngOnInit(): void {
  }

  createSell(event){
    this.http.post('https://localhost:5001/' + 'createclient',{
        nombre : this.name,
        apellido : this.lname, 
        email: this.email, 
        ciudad: this.city, 
        calle: this.street, 
        estado: this.state, 
        codPostal: this.postalCode}).subscribe(
      res=> {
        console.log(res);
        this.create = res["create"];
      }
    )
    }

}
