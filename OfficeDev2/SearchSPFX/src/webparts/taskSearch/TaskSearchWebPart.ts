import { Version } from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-webpart-base';
import { escape } from '@microsoft/sp-lodash-subset';

import styles from './TaskSearch.module.scss';
import * as strings from 'taskSearchStrings';
import { ITaskSearchWebPartProps } from './ITaskSearchWebPartProps';
import pnp, { SearchQueryBuilder, SearchResults, Sort, SortDirection } from "sp-pnp-js";

export default class TaskSearchWebPart extends BaseClientSideWebPart<ITaskSearchWebPartProps> {

  public onInit(): Promise<void> {
    return super.onInit().then(_ => {
      pnp.setup({
        spfxContext: this.context
      });
    });
  }

  public render(): void {

    var html = "";
    var query = SearchQueryBuilder.create("ContentTypeId:0x0108* StatusOWSCHCS:'Not Started'"); // keyword search
    query.selectProperties("Path", "Title", "Url", "Author", "RefinableDate01", "StatusOWSCHCS");
    query.rowLimit(30);
    //var a : Sort = {Property:"RefinableDate01", Direction: 0}
    query.sortList({Property:"RefinableDate01", Direction: 0});



    pnp.sp.search(query).then(
      (searchResults) => {
        searchResults.PrimarySearchResults.forEach(
          (resultItem) => {
            console.log(resultItem);
            var dueDate: any = new Date(resultItem["RefinableDate01"]);
            var style = "color:Blue; text-decoration:none";
            if (dueDate < new Date()) {
              style = "color:Red; text-decoration:none";
            }
            html += `<div><a href='${resultItem.Path}'><span style='${style}'>${resultItem.Title}</span> </a> : ${dueDate.format("yyyy-MM-dd")}</div>`;
          });

        this.domElement.innerHTML = html;
      });


  }

  protected get dataVersion(): Version {
    return Version.parse('1.0');
  }

  protected getPropertyPaneConfiguration(): IPropertyPaneConfiguration {
    return {
      pages: [
        {
          header: {
            description: strings.PropertyPaneDescription
          },
          groups: [
            {
              groupName: strings.BasicGroupName,
              groupFields: [
                PropertyPaneTextField('description', {
                  label: strings.DescriptionFieldLabel
                })
              ]
            }
          ]
        }
      ]
    };
  }
}
