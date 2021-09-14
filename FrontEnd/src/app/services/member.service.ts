import { ApiResult } from './../model/api-result';
import { Result } from './../model/result';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LogginParameter } from '../model/logginParameter';
import { MemberParameter } from '../model/memberParameter';
import { ResultSuccessOutputModel } from '../model/resultSuccessOutputModel';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  get token(){
    return this.cookieService.get('token');
  }

  constructor(
    private httpClient: HttpClient,
    private cookieService:CookieService
  ) {}

  createMember(data:MemberParameter){
    return this.httpClient.post('/api/v1/Member/Create',data)
  }

  login(data:LogginParameter){
    return this.httpClient.post<ResultSuccessOutputModel>('/api/v1/Loggin/Login',data).subscribe(x =>{
      this.cookieService.set('token', (x.data as string));
      location.href='/home';
    })
  }

  logout(){
    this.cookieService.deleteAll();
  }

  getMember(){
    return this.httpClient.post<ApiResult<any>>('/api/v1/Member/Get',{memberId:'test1234',password:'123456'});
  }
}
