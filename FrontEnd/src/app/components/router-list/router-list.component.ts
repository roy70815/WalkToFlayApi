import { GridOptions, ColDef } from 'ag-grid-community';
import { SystemFunctionService } from './../../services/system-function.service';
import { AfterViewInit, Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MenuOutputModel } from 'src/app/model/menuOutputModel';
import { TemplateRendererComponent } from '../common/ag-grid/template-renderer/template-renderer.component';
import { SystemFunctionOutputModelIEnumerableSuccessOutputModel } from 'src/app/model/models';

@Component({
  selector: 'app-router-list',
  templateUrl: './router-list.component.html',
  styleUrls: ['./router-list.component.scss']
})
export class RouterListComponent implements OnInit,AfterViewInit {
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

	rowData:SystemFunctionOutputModelIEnumerableSuccessOutputModel[]=[];


  constructor(
    public systemFunctionService:SystemFunctionService
  ) { }

  ngOnInit(): void {

  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.createColumnDefs();
      this.systemFunctionService.getAll().subscribe(x=>{
        this.rowData=x.data;
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
      {headerName: '大功能Id', field: 'functionId' ,resizable:true,cellClass:['text-center']},
      {headerName: '大功能名稱', field: 'functionName',resizable:true ,cellClass:['text-center']},
      {headerName: '大功能中文名稱', field: 'functionChineseName',resizable:true,cellClass:['text-center']},
      {headerName: 'Url', field: 'url',resizable:true,cellClass:['text-center']},
      {headerName: '是否啟用', field: 'enableFlag',resizable:true,cellClass:['text-center']},
      {headerName: '備註', field: 'remark',resizable:true,cellClass:['text-center']},
      {headerName: '排序', field: 'sort',resizable:true,cellClass:['text-center']},
      {headerName: '操作', field: 'functionId',resizable:true,headerClass:['text-center'],cellClass:['text-center'],cellRendererFramework:TemplateRendererComponent,cellRendererParams:{ngTemplate:this.functionTemplate}},

    ]
  }

  onModelUpdated(){
    // this.autoSizeAll();
    this.gridApi.sizeColumnsToFit();
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

  submit(){

  }

}
