import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-menu-top',
  templateUrl: './nav-menu-top.component.html',
  styleUrls: ['./nav-menu-top.component.css']
})
export class NavMenuTopComponent implements OnInit {
  isExpanded = false;
  constructor() { }

  ngOnInit(): void {
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

}
