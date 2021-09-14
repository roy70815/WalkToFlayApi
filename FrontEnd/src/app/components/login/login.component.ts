import { MemberService } from './../../services/member.service';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { Component, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { NgbModal, NgbModalConfig, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  @Input() isModal:boolean=false;
  @ViewChild('loginModal') loginModal!: TemplateRef<any>;

  formGroup:FormGroup=new FormGroup({
    memberId:new FormControl(null,Validators.required),
    password:new FormControl(null,Validators.required),
  })

  get memberId(){return this.formGroup.get('memberId') as FormControl}
  get password(){return this.formGroup.get('password') as FormControl}

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

  isInvalid(abstractControl:AbstractControl){
    if(abstractControl.invalid&&abstractControl.touched){
      return true
    }
    return false;
  }

  sumbit(){
    if(this.formGroup.invalid){
      this.formGroup.markAllAsTouched();
      return
    }
    this.memberService.login(this.formGroup.value)
  }

  close(){

  }

}
