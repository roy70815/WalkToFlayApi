import { ProductService } from './../../../services/product.service';
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ColDef, GridOptions } from 'ag-grid-community';
import { TemplateRendererComponent } from '../../common/ag-grid/template-renderer/template-renderer.component';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  @ViewChild('functionTemplate') functionTemplate:TemplateRef<any> | undefined;
  gridApi:any;
  gridColumnApi:any;
	columnDefs:ColDef[] = [];
  gridOptions:GridOptions={
    domLayout:'autoHeight',
    suppressAutoSize:true,
    // rowSelection: 'multiple',
    groupSelectsChildren: true
  }

	rowData:any[]=[];

  constructor(
    public productService:ProductService
  ) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.createColumnDefs();
      this.productService.getAll().subscribe(x=>{
        this.rowData=(x.data as any).productOutputModel;
      })
    }, 0);
  }

  createColumnDefs(){
    this.columnDefs=[
      // {
      //   headerName: '',
      //   field: 'athlete',
      //   maxWidth: 40,
      //   headerCheckboxSelection: true,
      //   headerCheckboxSelectionFilteredOnly: true,
      //   checkboxSelection: true,
      // },
      {headerName: 'id', field: 'id' ,resizable:true,cellClass:['text-center']},
      {headerName: 'name', field: 'name',resizable:true ,cellClass:['text-center']},
      {headerName: 'description', field: 'description',resizable:true,cellClass:['text-center']},
      {headerName: 'price', field: 'price',resizable:true,cellClass:['text-center']},
      {headerName: 'status', field: 'status',resizable:true,cellClass:['text-center']},
      {headerName: 'createTime', field: 'createTime',resizable:true,cellClass:['text-center']},
      {headerName: 'updateTime', field: 'updateTime',resizable:true,cellClass:['text-center']},
      {headerName: 'createUser', field: 'createUser',resizable:true,cellClass:['text-center']},
      {headerName: 'imagesCoverPath', field: 'imagesCoverPath',resizable:true,cellClass:['text-center']},
      {headerName: '操作', field: 'functionId',resizable:true,headerClass:['text-center'],cellClass:['text-center'],cellRendererFramework:TemplateRendererComponent,cellRendererParams:{ngTemplate:this.functionTemplate}},

    ]
  }



  onModelUpdated(){
    this.gridApi?.sizeColumnsToFit();
  }

  autoSizeAll(skipHeader?:boolean) {
    let allColumnIds:any = [];
    if(this.gridColumnApi){
      this.gridColumnApi.getAllColumns().forEach((x: any)=>{
        allColumnIds.push(x.colId);
      });
      this.gridColumnApi.autoSizeColumns(allColumnIds, skipHeader);
    }
  }

  onGridReady(params:any) {
    this.gridApi = params.api;
    this.gridColumnApi = params.columnApi;
    this.autoSizeAll();
  }

}
