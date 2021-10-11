import { ProductService } from './../../../services/product.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {
  formGroup: FormGroup = new FormGroup({
    name: new FormControl(),
    description: new FormControl(),
    price: new FormControl(),
    status: new FormControl(),
  })
  constructor(
    public productService: ProductService
  ) { }

  ngOnInit(): void {
  }

  create() {
    let formValue =this.formGroup.value;
    let param = {
      description: formValue.description,
      name: formValue.name,
      price: formValue.price,
      status: formValue.description?1:0
    }
    this.productService.create(param).subscribe(x => {
      alert('新增成功')
    })
  }

}
