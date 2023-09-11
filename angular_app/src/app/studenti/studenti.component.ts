import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit {

  title:string = 'angularFIT2';
  ime_prezime:string = '';
  opstina: string = '';
  studentPodaci: any;
  filter_ime_prezime: boolean;
  filter_opstina: boolean;
   opstinePodaci: any;
  odabraniStudent: any;
   lastOpstina: any;


  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  getStudenti() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetAll", MojConfig.http_opcije()).subscribe(x=>{
      this.studentPodaci = x;
    });
  }
  getOpstine() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Opstina/GetByAll", MojConfig.http_opcije()).subscribe(x=>{
      this.opstinePodaci = x;
    });
  }
  ngOnInit(): void {
    this.getStudenti();
    this.getOpstine();

  }

  filter() {
    if(this.studentPodaci==null)
      return [];
    return this.studentPodaci.filter((x:any)=>
      (!this.filter_ime_prezime ||
        (x.ime + " " + x.prezime).startsWith(this.ime_prezime) ||
        (x.prezime + " " + x.ime).startsWith(this.ime_prezime))
      &&
      (!this.filter_opstina ||
        (x.opstina_rodjenja.description).startsWith(this.opstina))
    )

  }

  Obrisi(s: any) {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Student/Obrisi", s, MojConfig.http_opcije()).subscribe(x=>{
      this.getStudenti();
    });
  }

  Uredi(s: any) {
  this.odabraniStudent=s;
  }

  Novi() {
  this.lastOpstina=this.studentPodaci[0].opstina_rodjenja_id;
  this.odabraniStudent={
    id:0,
    ime:this.ime_prezime,
    prezime:'',
    opstina_rodjenja_id:this.lastOpstina
  };
  }

  Snimi() {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Student/Snimi", this.odabraniStudent, MojConfig.http_opcije()).subscribe(x=>{
      this.getStudenti();
      this.odabraniStudent=null;
    });
  }
}
