import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-router-manage',
  templateUrl: './router-manage.component.html',
  styleUrls: ['./router-manage.component.scss']
})
export class RouterManageComponent implements OnInit {
  tabs=[
    {name:'路由查詢',url:'/router/list',active:true},
    {name:'路由明細',url:'/router/add',active:false},
  ]
  constructor() { }

  ngOnInit(): void {
  }

}
