import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { map } from 'rxjs/operators';

@Component({
  selector: 'app-property',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.css']
})
export class PropertyComponent implements OnInit {

  columnDefs = [
      {headerName: 'market', field: 'market' },
      {headerName: 'daysOnMarket', field: 'daysOnMarket' },
      {headerName: 'status', field: 'status'}
    ];

rowData: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
      this.getData().subscribe(t => console.log(t));
  }

  getData() {
    // const headers =  {headers: new  HttpHeaders({ 'Content-Type': 'application/json',
    // 'Access-Control-Allow-Origin': '*'})};
    // return this.http.get('/properties.json')
    // .pipe(map((res: Response) => {
    //   console.log(res.json());
    //     return { 'res': res.json() };
    // }));
    return this.http.get('https://dev1-sample.azurewebsites.net/properties.json')
       .pipe(map((results: any) =>  console.log(results)));
  }

}
