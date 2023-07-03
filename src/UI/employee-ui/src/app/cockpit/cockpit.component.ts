import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-cockpit',
  templateUrl: './cockpit.component.html',
  styleUrls: ['./cockpit.component.css']
})
export class CockpitComponent implements OnInit {

 @Output() serverCreated=new EventEmitter<{serverName:string,servercontent:string}>();
 @Output() blueprintCreated=new EventEmitter<{serverName:string,servercontent:string}>();

  newServerName = '';
  newServerContent = '';

  constructor(){

  }
  onAddServer(){
   this.serverCreated.emit(
    {
      serverName:this.newServerName,
      servercontent:this.newServerContent}
    );
    }
      onAddBlueprint(){
        this.blueprintCreated.emit(
          {
            serverName:this.newServerName,
            servercontent:this.newServerContent}
          );
      }

ngOnInit(){

}
  }



