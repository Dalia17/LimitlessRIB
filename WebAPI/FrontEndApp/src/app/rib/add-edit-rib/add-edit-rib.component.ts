import { Component, OnInit,Input, ɵConsole } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-rib',
  templateUrl: './add-edit-rib.component.html',
  styleUrls: ['./add-edit-rib.component.css']
})
export class AddEditRibComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() rib:any;
  Id:string;
  Owner: string;
  Iban: string;
  Bic: string;

  ngOnInit(): void {
    this.Id = this.rib.Id;
    this.Owner = this.rib.Owner;
    this.Iban = this.rib.Iban;
    this.Bic = this.rib.Bic;

  }

  addRib(){
    var val = {Id:this.Id,
      Owner: this.Owner,
      Iban: this.Iban,
      Bic: this.Bic,
    };
    this.service.addRib(val).subscribe(res => {
      console.log(res.toString());
      alert(res.toString());
    });
  }

  updateRib(){
    var val = {
      Id: this.Id,
      Owner: this.Owner,
      Iban: this.Iban,
      Bic: this.Bic,
    };
    this.service.updateRib (val).subscribe(res=>{
      console.log(res.toString());;
    });
  }

}
