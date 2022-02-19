import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
 isLoading:boolean = false;
 form:FormGroup = new FormGroup({
   userName: new FormControl('',[Validators.required]),
   password:new FormControl('',[Validators.required])
 });

  get UserName() {
    return this.form.get("userName");
 } 

 get Password() {
  return this.form.get("password");
} 
  constructor(private Auth:AuthService) { }

  ngOnInit(): void {
  }
  loginUser(){
    this.isLoading = true;
    this.Auth.login({userName:this.UserName?.value , password:this.Password?.value}).subscribe(result =>{
      this.isLoading = false;
    },(error)=>{
    if(error.status == 401){
      alert("UserName or password is wrong");
    }
      this.isLoading = false;
    })
  }

}
