import { ApiResult } from './../model/api-result';
import { ResultSuccessOutputModel } from './../model/resultSuccessOutputModel';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SystemFunctionOutputModel } from '../model/systemFunctionOutputModel';

@Injectable({
  providedIn: 'root'
})
export class SystemFunctionService {

  constructor(private httpClient: HttpClient) { }


  getAll(){
    return this.httpClient.get<ApiResult<SystemFunctionOutputModel[]>>('/api/v1/SystemFunction/GetAll')
  }
}
