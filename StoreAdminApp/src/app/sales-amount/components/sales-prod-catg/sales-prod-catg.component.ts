import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpService } from 'src/app/http.service';

@Component({
  selector: 'app-sales-prod-catg',
  templateUrl: './sales-prod-catg.component.html',
  styleUrls: ['./sales-prod-catg.component.css']
})
export class SalesProdCatgComponent implements OnInit {

  constructor(private data: HttpService, private formBuilder: FormBuilder) {
    this.salesForm = this.formBuilder.group({
      month: ['', Validators.required],
      category: ['', Validators.required],
      year: ['', Validators.required]
    })
  }

  users$: Object;
  categories$: Object = this.data.getCategories().subscribe((data) => (this.categories$ = data));
  products$: Object;
  monthSelected: String;
  categorySelected: number;
  yearSelected: String;
  salesForm: FormGroup;
  Months: string[] = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'Agust', 'September', 'October', 'November', 'December'];
  Years: string[] = ['2016', '2017', '2018', '2019', '2020'];



  onSubmit() {
    console.log(this.monthSelected)
    console.log(this.categorySelected.toString());
    console.log(this.yearSelected)
    this.data.getUsers().subscribe((data) => (this.users$ = data));

  }

  ngOnInit(): void {
  }

}
