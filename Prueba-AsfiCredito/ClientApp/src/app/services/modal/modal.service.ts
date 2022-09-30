import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ModalService {

  private emitModalEvent = new BehaviorSubject<boolean>(false);

  constructor() { }

  emitShowModalEvent(msg: boolean){
    this.emitModalEvent.next(msg)
  }

  showModalEventListener(){
    return this.emitModalEvent.asObservable();
  }
}
