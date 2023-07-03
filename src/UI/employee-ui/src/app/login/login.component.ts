import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export default class LoginComponent implements OnInit {
  @ViewChild ('f') loginPage:NgForm;

  constructor(){

  }
  ngOnInit(): void {
    
  }
 
  OnSubmit(){
    console.log(this.loginPage.value);
  }
}
