import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Category} from "./models/ICategory";
import {NestedTreeControl} from "@angular/cdk/tree";
import {MatTreeNestedDataSource} from "@angular/material/tree";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  constructor(private http: HttpClient) {}

  data: Category[] = [];
  treeControl = new NestedTreeControl<Category>(node => node.subCategories);
  dataSource = new MatTreeNestedDataSource<Category>();
  hasChild = (_: number, node: Category) => !!node.subCategories && node.subCategories.length > 0;

  getData(){
    this.http.get<Category[]>("http://localhost:5027/api/Category/getCategoriesTree")
      .subscribe((response: Category[])=>{
        this.data=response;
        this.dataSource.data = this.data
    })
  }

}
