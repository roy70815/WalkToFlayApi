import { SystemFunctionService } from './../../../services/system-function.service';
import { FormGroup, FormControl } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-router-detail',
  templateUrl: './router-detail.component.html',
  styleUrls: ['./router-detail.component.scss']
})
export class RouterDetailComponent implements OnInit {
  formGroup:FormGroup=new FormGroup({
    functionId:new FormControl(),
    functionName:new FormControl(),
    functionChineseName:new FormControl(),
    url:new FormControl(),
    enableFlag:new FormControl(),
    remark:new FormControl(),
    sort:new FormControl(),
  })
  constructor(public systemFunctionService:SystemFunctionService) { }

  ngOnInit(): void {
  }

  create(){
    this.systemFunctionService.create(this.formGroup.value).subscribe(x=>{
      alert('新增成功')
    })
  }


}
