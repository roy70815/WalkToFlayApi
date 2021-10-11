import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiResult } from '../model/api-result';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClient: HttpClient) { }


  poductGet(){
    return this.httpClient.get<ApiResult<any[]>>('/api/v1/Product/Get')
  }
  getAll(){
    return this.httpClient.get<ApiResult<any[]>>('/api/v1/Product/GetAll')
  }
  create(data:any){
    return this.httpClient.post('/api/v1/Product/Create',data)
  }

}
