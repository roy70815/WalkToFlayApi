import { SystemFunctionService } from './../../services/system-function.service';
import { Component, OnInit } from '@angular/core';
import { SystemFunctionOutputModel } from 'src/app/model/systemFunctionOutputModel';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  get currentPath(){
    return (this.activatedRoute as any).snapshot.routeConfig.path;
  }

  constructor(
    public systemFunctionService: SystemFunctionService,
    public activatedRoute:ActivatedRoute
  ) { }

  ngOnInit(): void {
  }
}
