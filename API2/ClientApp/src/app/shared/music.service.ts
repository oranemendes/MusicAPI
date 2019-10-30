import {Injectable} from "@angular/core";
import {Music} from "../components/music";
import {HttpClient} from "@angular/common/http";
import {HttpHeaders} from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class MusicService {
    
    optionRequest = {
        headers: new HttpHeaders({
            'Access-Control-Allow-Origin':'*',
            'Access-Control-Allow-Methods':'*',
            'Access-Control-Allow-Headers':'*'
        })
    };
    formData : Music;
    readonly rootUrl="https://localhost:5001/api";
    list : Music[];
    
    constructor(private http: HttpClient) {}
    
    postMusic(){
        return this.http.post(this.rootUrl+'/music', this.formData, this.optionRequest)
    }
    
    refreshList(){
        this.http.get(this.rootUrl+'/music')
            .toPromise()
            .then(res => this.list = res as Music[])
    }
    
    putMusic(){
        return this.http.put(this.rootUrl+'/music/'+this.formData.Id, this.formData, this.optionRequest)
    }
    
    deleteMusic(id: string){
        return this.http.delete(this.rootUrl+'/music/'+id);
    }
}