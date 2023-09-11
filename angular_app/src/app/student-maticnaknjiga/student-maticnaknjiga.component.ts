import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-student-maticnaknjiga',
  templateUrl: './student-maticnaknjiga.component.html',
  styleUrls: ['./student-maticnaknjiga.component.css']
})
export class StudentMaticnaknjigaComponent implements OnInit {
  podaciZaUpis: any;
   studentId: number;
   Podaci: any;
  godine: any;

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {}

  ovjeriLjetni(s:any) {

  }

  upisLjetni(s:any) {

  }

  ovjeriZimski(s:any) {

  }

  ngOnInit(): void {
    this.getGodine();
    this.route.params.subscribe(x=>{
      this.studentId=+x['id'];
      this.getMaticna();
    })
  }
  getGodine() {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/AkademskeGodine/GetAll_ForCmb", MojConfig.http_opcije()).subscribe(x=>{

      this.godine = x;
    });
  }

   getMaticna() {
     this.httpKlijent.get(MojConfig.adresa_servera+ "/Maticna/GetById?id="+this.studentId, MojConfig.http_opcije()).subscribe(x=>{

       this.Podaci = x;
     });
  }

  Upisi() {

    this.podaciZaUpis = {
      id: this.studentId,
      datum: new Date(),
      godinaStudija: 1,
      akGodina: 1,
      cijenaSkolarine: 0,
      obnova: false
    }
  }


  Snimi() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Maticna/Upisi?id="+this.studentId, this.podaciZaUpis, MojConfig.http_opcije()).subscribe(x=>{
      porukaSuccess('Uspjesno' );
      this.podaciZaUpis=null;
      this.getMaticna();
    });
  }

  Ovjeri(id:any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Maticna/Ovjeri?id="+id, MojConfig.http_opcije()).subscribe(x=>{
      porukaSuccess('Uspjesno' );
      window.location.reload();
    });
  }
}
