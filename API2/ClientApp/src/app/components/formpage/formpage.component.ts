import { Component, OnInit } from '@angular/core';
import {Form, FormBuilder, FormControl, FormGroup, NgForm, Validators} from '@angular/forms';
import {MusicService} from "../../shared/music.service";

@Component({
  selector: 'app-formpage',
  templateUrl: './formpage.component.html',
  styleUrls: ['./formpage.component.css']
})
export class FormpageComponent implements OnInit {

  /*public newMusicForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
              private service: MusicService) { }

  ngOnInit() {
    this.createForm();
  }

  private createForm() {
    this.newMusicForm = this.formBuilder.group({
      title: ['', Validators.required],
      group: ['', Validators.required],
      year: ['', Validators.required],
      platform: ['', Validators.required],
      link: ['', Validators.required],
      image: ['', Validators.required]
    });
  }

  private addMusic(formData) {
    this.service.postMusic().subscribe(res => {
      this.service.refreshList();
    })
  }

  public onSubmit(formData) {
    const title = this.newMusicForm.get('title').value;
    const group = this.newMusicForm.get('group').value;
    const year = this.newMusicForm.get('year').value;
    const platform = this.newMusicForm.get('platform').value;
    const link = this.newMusicForm.get('link').value;
    const image = this.newMusicForm.get('image').value;
    this.addMusic(formData);
    
  }*/
  
  constructor(private service: MusicService){}
  
  ngOnInit(){
    this.resetForm();
  }
  
  resetForm(form?: NgForm){
    if (form != null)
      form.form.reset();
    this.service.formData = {
      Id: '',
      Title: '',
      Group: '',
      Year: '',
      Platform: '',
      Link: '',
      Image: ''
    }
  }
  
  onSubmit(form: NgForm){
    if(this.service.formData.Id == '')
      this.insertRecord(form);
    else this.updateRecord(form);
  }
  
  insertRecord(form: NgForm){
    this.service.postMusic().subscribe(
        res => {
          //debugger;
          this.resetForm(form);
          console.log("success");
          this.service.refreshList();
        },
        err => {
          //debugger;
          console.log(err);
        }
    )
  }
  
  updateRecord(form: NgForm){
    this.service.putMusic().subscribe(
        res => {
          this.resetForm(form);
          console.log("Update success");
          this.service.refreshList();
        },
        err => {
          console.log(err);
        }
    )
  }

}
