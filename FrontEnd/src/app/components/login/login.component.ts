import { MemberService } from './../../services/member.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { NgbModal, NgbModalConfig, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  @ViewChild('loginModal') loginModal!: TemplateRef<any>;

  formGroup:FormGroup=new FormGroup({
    memberId:new FormControl(null,Validators.required),
    password:new FormControl(null,Validators.required),
  })

  constructor(
    config: NgbModalConfig,
    private modalService: NgbModal,
    public memberService:MemberService
    ) {
    // config.backdrop = 'static';
    // config.keyboard = false;
  }

  ngOnInit(): void {
  }

  open(){
    this.modalService.open(this.loginModal, { centered: true });
  }

  sumbit(){
    if(this.formGroup.invalid){
      this.formGroup.markAllAsTouched();
      return
    }
    this.memberService.login(this.formGroup.value).subscribe(x=>{
      alert(x.data)
    })
  }

  close(){

  }

}
