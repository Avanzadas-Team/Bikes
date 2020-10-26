import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpService } from 'src/app/http.service';

@Component({
  selector: 'app-prod-sales',
  templateUrl: './prod-sales.component.html',
  styleUrls: ['./prod-sales.component.css']
})
export class ProdSalesComponent implements OnInit {

  constructor(private data: HttpService, private formBuilder: FormBuilder) {
    this.salesForm = this.formBuilder.group({
      store: ['', Validators.required],
      product: ['', Validators.required],
      fDate: ["", Validators.required],
      tDate: ["", Validators.required],
    })
  }

  salesForm: FormGroup;
  sales$: Object;
  products$: Object = this.data.getProducts().subscribe((data) => (this.products$ = data));
  storeSelected: string;
  productSelected: number;
  fromDate: Date;
  toDate: Date;
  Stores: string[] = ['New York', 'California', 'Texas'];


  ngOnInit(): void {
  }

  onSubmit() {
    let id: string = this.productSelected.toString();
    let date1: string = this.fromDate.toString();
    let date2: string = this.toDate.toString();
    if (this.storeSelected == 'NewYork') {
      this.data.getProdNY(id, date1, date2).subscribe((data) => (this.sales$ = data));
    }
    else if (this.storeSelected == 'California') {
      this.data.getProdCA(id, date1, date2).subscribe((data) => (this.sales$ = data));
    }
    else {
      this.data.getProdTX(id, date1, date2).subscribe((data) => (this.sales$ = data));
    }

  }

}
