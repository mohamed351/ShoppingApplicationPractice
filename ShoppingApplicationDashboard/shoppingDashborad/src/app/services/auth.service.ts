import { Injectable } from '@angular/core';
import {AuthModel} from '../models/auth-model';
import {LoginUserModel} from '../models/login-user-model';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import { map, ReplaySubject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  private currentUser = new ReplaySubject<AuthModel|null>(1);
  currentUser$=  this.currentUser.asObservable();
  constructor(private http:HttpClient) { }

   login(loginUser:LoginUserModel){
    return this.http.post<AuthModel>(environment.baseURL+"/auth/Login",loginUser).pipe(
      map((response)=>{
        localStorage.setItem("user",JSON.stringify(response));
        this.currentUser.next(response);
      })
    )
   }
   logOut(){
     localStorage.removeItem("user");
     this.currentUser.next(null);
   }
   isAuthicated(){
     return localStorage.getItem("user") != null;
   }
   token(){
    let tokenUser = localStorage.getItem("user")
    if(tokenUser == null){
      return null;
    }
     return JSON.parse(tokenUser);
   }

  
}
