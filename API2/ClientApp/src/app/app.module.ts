import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { FormpageComponent } from './components/formpage/formpage.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { MusiclistComponent } from './components/musiclist/musiclist.component';
import { RouterModule, Routes } from '@angular/router';
import {MusicService} from "./shared/music.service";
import {HttpClient, HttpClientModule, HttpHandler} from "@angular/common/http";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";


@NgModule({
  declarations: [
    AppComponent,
    FormpageComponent,
    MusiclistComponent
  ],
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        BrowserAnimationsModule,
        FormsModule
    ],
  providers: [MusicService],
  bootstrap: [AppComponent]
})
export class AppModule { }
