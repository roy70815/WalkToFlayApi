import { SystemFunctionService } from './../../services/system-function.service';
import { Component, OnInit } from '@angular/core';
import { SystemFunctionOutputModel } from 'src/app/model/systemFunctionOutputModel';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  systemFunctionOutputModel:SystemFunctionOutputModel[]=[];
  constructor(
    private systemFunctionService:SystemFunctionService
  ) { }

  ngOnInit(): void {
    this.getAllSystemFunction();
  }

  getAllSystemFunction(){
    this.systemFunctionService.getAll().subscribe(x=>{
      this.systemFunctionOutputModel=x.data;
    })
  }
}
