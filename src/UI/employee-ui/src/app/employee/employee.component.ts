import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {map} from 'rxjs/operators';
import {employee} from './employee.model';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export default class EmployeeComponent implements OnInit {
  employeeList:employee[]=[];
  constructor(private http:HttpClient){

  }
  private fetchPosts(){
    this.http
    .get<{[key:string]:employee}>('https://localhost:44397/api/Employee/GetAll')
    .pipe(map((responseData)=>{
      const empArray:employee[]=[];
      for(const item in responseData)
      {
        if(responseData.hasOwnProperty(item))
        {
          empArray.push({...responseData[item]})
        }
      }
      return empArray;
    }))
    .subscribe(res=>{
      this.employeeList=res;
      console.log(this.employeeList);
    })
  }
ngOnInit() {
  this.fetchPosts();
}
}
