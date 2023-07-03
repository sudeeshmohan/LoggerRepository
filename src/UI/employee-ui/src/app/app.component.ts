import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Employee';
  serverElements = [
    {type: 'server', name: 'Testserver', content: 'Just a test!'},
    {type: 'blueprint', name: 'Testserver1', content: 'Just a test!'}
];

onAddServer(ServerData:{serverName:string,servercontent:string}){
  this.serverElements.push(
    {
      type:'server',
      name:ServerData.serverName,
      content:ServerData.servercontent
    });
  }
    onAddBlueprint(ServerData:{serverName:string,servercontent:string}){
      this.serverElements.push(
        {
          type:'blueprint',
          name:ServerData.serverName,
          content:ServerData.servercontent
        });
    }

onFetchPosts(): void{
  
}
  ngOnInit() {
   
  }
}
