import { ApiResult } from './../model/api-result';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LogginParameter } from '../model/logginParameter';
import { MemberParameter } from '../model/memberParameter';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  static member:any;
  // get WTFA(){
  //   return this.cookieService.get('WTFA');
  // }

  constructor(
    private httpClient: HttpClient,
    // private cookieService:CookieService
  ) {}

  createMember(data:MemberParameter){
    return this.httpClient.post('/api/v1/Member/Create',data)
  }

  login(data:LogginParameter){
    return this.httpClient.post('/api/v1/Loggin/Login',data).subscribe(x =>{
      // this.cookieService.set('token', (x.data as string));
      location.href='/home';
    })
  }

  logout(){
    return this.httpClient.post('/api/v1/Loggin/Logout',null).subscribe(x =>{
      location.href='/login';
    })
  }

  getMember(){
    return this.httpClient.get<ApiResult<any>>('/api/v1/Member/Get');
  }
}
