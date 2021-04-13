import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-show-rib',
  templateUrl: './show-rib.component.html',
  styleUrls: ['./show-rib.component.css']
})
export class ShowRibComponent implements OnInit {

  constructor(private service:SharedService) { }

  RibList:any=[];

  ModalTitle:string;
  ActivateAddEditRibComp:boolean=false;
  rib:any;


  ngOnInit(): void {
    this.refreshRibList();
  }

  addClick(){
    this.rib={
      Id:0,
      Owner: "",
      Iban: "",
      Bic: ""
    }
    this.ModalTitle="Add Rib";
    this.ActivateAddEditRibComp=true;

  }

  editClick(item) {
    this.rib = item;
    this.ModalTitle="Edit Rib";
    this.ActivateAddEditRibComp=true;
  }

  deleteClick(item){
    if(confirm('Are you sure??')){
      this.service.deleteRib(item.Id).subscribe(data=>{
       
        this.refreshRibList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditRibComp=false;
    this.refreshRibList();
  }


  refreshRibList(){
    this.service.getRibList().subscribe(data=>{
      this.RibList=data;
     // this.RibListWithoutFilter=data;
    });
  }



}
