import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-manage',
  templateUrl: './product-manage.component.html',
  styleUrls: ['./product-manage.component.scss']
})
export class ProductManageComponent implements OnInit {
  tabs=[
    {name:'商品查詢',url:'/product/list',active:true},
    {name:'商品明細',url:'/product/add',active:false},
  ]
  constructor() { }

  ngOnInit(): void {
  }

}
