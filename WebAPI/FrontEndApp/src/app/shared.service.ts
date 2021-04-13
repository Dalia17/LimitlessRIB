import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl="http://localhost:53535/api";

  constructor(private http:HttpClient) { }

  getRibList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/rib');
  }

  addRib(val:any){
    return this.http.post(this.APIUrl+'/Rib',val);
  }

  updateRib(val:any){
    return this.http.put(this.APIUrl+'/Rib',val);
  }

  deleteRib(val:any){
    return this.http.delete(this.APIUrl+'/Rib/'+val);
  }

}
