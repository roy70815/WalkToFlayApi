import { Validators } from '@angular/forms';
import { ApiResult } from './../model/api-result';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MenuOutputModelIEnumerableSuccessOutputModel } from '../model/menuOutputModelIEnumerableSuccessOutputModel';
import { MenuOutputModel } from '../model/menuOutputModel';
import { SystemFunctionOutputModelIEnumerableSuccessOutputModel } from '../model/models';
import { ActivatedRoute, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class SystemFunctionService {
  systemFunctionOutputModel: MenuOutputModel[] | any[] = [];
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
  constructor(private httpClient: HttpClient,private router:Router) {
    this.init();
  }
  menuGet(){
    return this.httpClient.get<ApiResult<MenuOutputModel[]>>('/api/v1/Menu/Get')
  }
  getAll(){
    return this.httpClient.get<ApiResult<SystemFunctionOutputModelIEnumerableSuccessOutputModel[]>>('/api/v1/SystemFunction/GetAll')
  }

  create(data:any){
    return this.httpClient.post('/api/v1/SystemFunction/Create',data)
  }


  init(){
   this.menuGet().subscribe(x=>{
      this.systemFunctionOutputModel=x.data;
      // this.systemFunctionOutputModel.find(x=>x.functionId==4).smallMenuDtos[0].url='router/list';
      console.log(this.router.url.split('?')[0])
      this.systemFunctionOutputModel.map(x=>{
        if((x.smallMenuDtos as any[]).find(y=>y.url==this.router.url.split('?')[0].slice(1))){
          x.open=true;
        }
        return x;
      })
    })
  }

}
