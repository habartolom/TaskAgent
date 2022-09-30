import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  private changeDashboardEvent = new BehaviorSubject(null);

  constructor() { }

  emitChangeDashboardEvent(){
    this.changeDashboardEvent.next(null)
  }

  changeDashboardEventListener(){
    return this.changeDashboardEvent.asObservable();
  }
}
