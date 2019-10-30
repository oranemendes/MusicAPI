import { Component, OnInit } from '@angular/core';
import { Music } from '../music';
import {MusicService} from "../../shared/music.service";

@Component({
  selector: 'app-musiclist',
  templateUrl: './musiclist.component.html',
  styleUrls: ['./musiclist.component.css']
})
export class MusiclistComponent implements OnInit {
  /*mus = [
    new Music(1, 'Royal Beggars', 'Architects', 2018, 'Youtube',
      'https://www.youtube.com/watch?v=HNpWuwSVyDk',
      'http://img.over-blog-kiwi.com/0/99/50/54/20181003/ob_1be889_architectsholyhellcd.jpg'),
    new Music(2, 'Twenty Letters', 'Dream State', 2019, 'Youtube',
      'https://www.youtube.com/watch?v=kVgzcobF8Ig',
      'https://e-cdns-images.dzcdn.net/images/cover/8b7bf7e2fc7f911dc96441ec528cd3a3/1400x1400-000000-80-0-0.jpg'),
    new Music(3, 'Scars', 'I Prevail', 2016, 'Youtube',
      'https://www.youtube.com/watch?v=tZzL4jI60p4',
      'https://t2.genius.com/unsafe/220x220/https%3A%2F%2Fimages.genius.com%2F9d87abf66835582680a63b5e7939d7b6.960x960x1.png'),
    new Music(4, 'Feeling Low', 'Blessthefall', 2018, 'Youtube',
      'https://www.youtube.com/watch?v=98aXlnl_b8E',
      'https://t2.genius.com/unsafe/220x220/https%3A%2F%2Fimages.genius.com%2F3187840a866fe6acb0b857aef8dff906.960x960x1.jpg')
  ]; */

  constructor(private service: MusicService) { }

  ngOnInit() {
    this.service.refreshList();
  }
  
  populateForm(mus: Music){
    this.service.formData = Object.assign({}, mus);
  }
  
  onDelete(Id){
    if (confirm('Voulez vous vraiment supprimer ce titre ?')){
      this.service.deleteMusic(Id)
          .subscribe(res => {
            this.service.refreshList();
            console.log("Deleted successfully");
          }, err => {
            console.log(err);
          })
    }
  }
  

}
