import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  apiValues: string[] = [];
  constructor(private _service: HttpClient) {
  }

  ngOnInit() {
    //this._service.get("http://localhost:61634/api/values").subscribe(result => {
    //  this.apiValues = result as string[];

   // });
  }
  title = 'AdysCarOrdering';
}
