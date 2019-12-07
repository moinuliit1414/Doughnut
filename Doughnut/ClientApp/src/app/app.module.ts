import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { DoughnutComponent } from './doughnut-tree/doughnut-tree.component';
import { TreeNode } from './doughnut-tree/doughnut-node.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
        HomeComponent,
        TreeNode,
    DoughnutComponent,
    CounterComponent,
    FetchDataComponent
    ],

  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    //TreeNode,
    RouterModule.forRoot([
      { path: '', component: DoughnutComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'doughnut', component: DoughnutComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
    providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
