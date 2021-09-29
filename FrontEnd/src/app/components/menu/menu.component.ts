import { SystemFunctionService } from './../../services/system-function.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  get currentPath(){
    return this.router.url;
  }

  constructor(
    public systemFunctionService: SystemFunctionService,
    public router:Router
  ) { }

  ngOnInit(): void {
  }
}
