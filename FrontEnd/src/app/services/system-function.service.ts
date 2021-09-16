import { ApiResult } from './../model/api-result';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MenuOutputModelIEnumerableSuccessOutputModel } from '../model/menuOutputModelIEnumerableSuccessOutputModel';
import { MenuOutputModel } from '../model/menuOutputModel';

@Injectable({
  providedIn: 'root'
})
export class SystemFunctionService {
  systemFunctionOutputModel: MenuOutputModel[] = [];
  systemFunctionData = [
    {
      functionName: '會員管理',
      open:false,
      url:null,
      children: [
        { functionName: '會員一覽',url:'member/list' },
        { functionName: '電子積分管理',url:'ecash/list' },
      ]
    },
    {
      functionName: '商品管理',
      open:false,
      url:null,
      children: [
        { functionName: '產品基本資料',url:'product/list' },
        { functionName: '庫存管理作業',url:'store/list' },
      ]
    },
    {
      functionName: '訂單管理',
      open:false,
      url:null,
      children: [
        { functionName: '訂單一覽',url:'order/list' },
      ]
    },
  ]
  constructor(private httpClient: HttpClient) {
    this.getAll();
  }
  getAll(){
    return this.httpClient.get<ApiResult<MenuOutputModel[]>>('/api/v1/Menu/Get').subscribe(x=>{
      this.systemFunctionOutputModel=x.data;
    })
  }

}
