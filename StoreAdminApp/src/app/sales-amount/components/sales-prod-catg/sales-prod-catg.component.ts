import { AuthService } from './../../../auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpService } from 'src/app/http.service';

@Component({
  selector: 'app-sales-prod-catg',
  templateUrl: './sales-prod-catg.component.html',
  styleUrls: ['./sales-prod-catg.component.css']
})
export class SalesProdCatgComponent implements OnInit {

  constructor(private data: HttpService, private formBuilder: FormBuilder, private auth: AuthService) {
    this.salesForm = this.formBuilder.group({
      month: ['', Validators.required],
      category: ['', Validators.required],
      year: ['', Validators.required]
    })
  }

  categories$: Object = this.data.getCategories().subscribe((data) => (this.categories$ = data));
  products$: Object;
  monthSelected: string;
  categorySelected: number;
  yearSelected: string;
  salesForm: FormGroup;
  Months: string[] = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
  Years: string[] = ['2016', '2017', '2018', '2019', '2020'];



  onSubmit() {
    console.log(this.monthSelected)
    console.log(this.categorySelected.toString());
    console.log(this.yearSelected)
    if (this.auth.getStoreID() == '1') {
      this.data.getProdByCatgNY(this.categorySelected.toString(), this.monthSelected, this.yearSelected).subscribe((data) => (this.products$ = data));
    }
    else if (this.auth.getStoreID() == '2') {
      this.data.getProdByCatgCA(this.categorySelected.toString(), this.monthSelected, this.yearSelected).subscribe((data) => (this.products$ = data));
    }
    else {
      this.data.getProdByCatgTX(this.categorySelected.toString(), this.monthSelected, this.yearSelected).subscribe((data) => (this.products$ = data));
    }


  }

  ngOnInit(): void {
  }

}
