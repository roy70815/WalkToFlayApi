import { MemberService } from './../../services/member.service';
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { MemberParameter } from 'src/app/model/memberParameter';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  @ViewChild('registerModal') registerModal!: TemplateRef<any>;
  minDate = { year: 1985, month: 1, day: 1 };
  maxDate = { year: new Date().getFullYear(), month: 1, day: 1 }
  formGroup: FormGroup = new FormGroup({
    memberId: new FormControl(),
    firstName: new FormControl(),
    lastName: new FormControl(),
    passWord: new FormControl(),
    email: new FormControl(),
    birthDay: new FormControl(),
    sex: new FormControl(true),
    mobilePhone: new FormControl(),
    telPhone: new FormControl(),
    city: new FormControl(),
    area: new FormControl(),
    address: new FormControl()
  })

  get firstName() { return this.formGroup.get('firstName') as FormControl }
  get lastName() { return this.formGroup.get('lastName') as FormControl }
  get passWord() { return this.formGroup.get('passWord') as FormControl }
  get email() { return this.formGroup.get('email') as FormControl }
  get birthDay() { return this.formGroup.get('birthDay') as FormControl }
  get sex() { return this.formGroup.get('sex') as FormControl }
  get mobilePhone() { return this.formGroup.get('mobilePhone') as FormControl }
  get telPhone() { return this.formGroup.get('telPhone') as FormControl }
  get county() { return this.formGroup.get('county') as FormControl }
  get city() { return this.formGroup.get('city') as FormControl }
  get address() { return this.formGroup.get('address') as FormControl }

  constructor(
    config: NgbModalConfig,
    private modalService: NgbModal,
    public memberService: MemberService
  ) {
    // config.backdrop = 'static';
    // config.keyboard = false;
  }

  ngOnInit(): void {
  }

  open() {
    this.modalService.open(this.registerModal, { centered: true, size: 'lg' });
  }

  submit() {
    let submitData: MemberParameter = this.formGroup.value;
    submitData.birthDay = new Date(`${this.birthDay.value.year}-${this.birthDay.value.month}-${this.birthDay.value.day}`)
    console.log(submitData)
    this.memberService.createMember(submitData).subscribe(x => {
      console.log(x)
    })
  }

  setFackData(){
    this.formGroup.reset(JSON.parse(`{ "memberId": "wei", "firstName": "張", "lastName": "育瑋", "passWord": "1234", "email": "yuwei18963@gmail.com", "birthDay": { "year": 1996, "month": 4, "day": 8 }, "sex": true, "mobilePhone": "0916598536", "telPhone": "02-29743315", "city": 2, "area": 39, "address": "仁化街 66號 五樓" }`))
  }

  close() {

  }
}
