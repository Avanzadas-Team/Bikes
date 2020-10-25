import { AuthService } from 'src/app/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { HttpService } from 'src/app/http.service';


@Component({
  selector: 'app-client-average',
  templateUrl: './client-average.component.html',
  styleUrls: ['./client-average.component.css']
})
export class ClientAverageComponent implements OnInit {

  constructor(private data: HttpService, private formBuilder: FormBuilder, private auth: AuthService) {
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
    console.log(this.fromDate.toString());
    console.log(this.toDate.toString());
    if (this.auth.getStoreID() == '1') {
      this.data.getAvgPbyCltNY(this.fromDate.toString(), this.toDate.toString()).subscribe((data) => (this.users$ = data));
    }
    else if (this.auth.getStoreID() == '2') {
      this.data.getAvgPbyCltCA(this.fromDate.toString(), this.toDate.toString()).subscribe((data) => (this.users$ = data));
    }
    else {
      this.data.getAvgPbyCltTX(this.fromDate.toString(), this.toDate.toString()).subscribe((data) => (this.users$ = data));
    }


  }

  ngOnInit(): void {
  }

}
