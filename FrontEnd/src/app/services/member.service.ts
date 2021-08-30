import { Result } from './../model/result';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LogginParameter } from '../model/logginParameter';
import { MemberParameter } from '../model/memberParameter';
import { ResultSuccessOutputModel } from '../model/resultSuccessOutputModel';

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  constructor(
    private httpClient: HttpClient
  ) { }

  createMember(data:MemberParameter){
    return this.httpClient.post('/api/v1/Member/Create',data)
  }

  login(data:LogginParameter){
    return this.httpClient.post<ResultSuccessOutputModel>('/api/v1/Loggin/Login',data)
  }


}
