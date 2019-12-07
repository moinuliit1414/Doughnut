import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { ModuleMapLoaderModule } from '@nguniversal/module-map-ngfactory-loader';
import { AppComponent } from './app.component';
import { AppModule } from './app.module';
import { TreeNode } from './doughnut-tree/doughnut-node.component';

@NgModule({
    imports: [AppModule, ServerModule, ModuleMapLoaderModule],
    //declarations: [TreeNode],
    bootstrap: [AppComponent]
})
export class AppServerModule { }
