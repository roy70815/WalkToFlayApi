import { ActivatedRoute } from '@angular/router';
import { PageDirective } from './../../directive/page.directive';
import { MemberService } from './../../services/member.service';
import { Component, ComponentFactoryResolver, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-basic-layout',
  templateUrl: './basic-layout.component.html',
  styleUrls: ['./basic-layout.component.scss']
})
export class BasicLayoutComponent implements OnInit {
  @ViewChild(PageDirective,{static:true}) content?: PageDirective;
  get member(){return MemberService.member;}
  constructor(public memberService:MemberService,public activatedRoute:ActivatedRoute,public componenFactoryResolver: ComponentFactoryResolver) { }

  ngOnInit(): void {
    this.activatedRoute.data.subscribe(data=>{
      const componentFactory = this.componenFactoryResolver.resolveComponentFactory(data.Component);
      this.content?.viewContainerRef.createComponent(componentFactory)
    })
  }

  logout(){
    this.memberService.logout();
  }

}
