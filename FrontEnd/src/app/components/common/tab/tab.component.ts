import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-tab',
  templateUrl: './tab.component.html',
  styleUrls: ['./tab.component.scss']
})
export class TabComponent implements OnInit {
  @Input() tabs:any[]=[];
  get currentPath(){
    return this.router.url;
  }
  constructor(public router:Router) { }

  ngOnInit(): void {
  }

}
