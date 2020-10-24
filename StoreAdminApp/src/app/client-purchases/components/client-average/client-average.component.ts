import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { HttpService } from 'src/app/http.service';


@Component({
  selector: 'app-client-average',
  templateUrl: './client-average.component.html',
  styleUrls: ['./client-average.component.css']
})
export class ClientAverageComponent implements OnInit {

  constructor(private data: HttpService, private formBuilder: FormBuilder) {
    this.dateForm = this.formBuilder.group({
      fDate: ["", Validators.required],
      tDate: ["", Validators.required],
    });
  }

  users$: Object;
  fromDate: Date;
  toDate: Date;
  dateForm: FormGroup;

  submit() {
    console.log(this.fromDate);
    console.log(this.toDate);
    this.data.getUsers().subscribe((data) => (this.users$ = data));

  }

  ngOnInit(): void {
  }

}
