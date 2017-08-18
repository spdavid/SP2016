import { Version } from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-webpart-base';
import { escape } from '@microsoft/sp-lodash-subset';

import styles from './SearchPart.module.scss';
import * as strings from 'searchPartStrings';
import { ISearchPartWebPartProps } from './ISearchPartWebPartProps';
import pnp, { SearchQueryBuilder, SearchResults } from "sp-pnp-js";

interface myinterface{
  Title : string;
}

export default class SearchPartWebPart extends BaseClientSideWebPart<ISearchPartWebPartProps> {

  public onInit(): Promise<void> {
      return super.onInit().then(_ => {
        pnp.setup({
          spfxContext: this.context
        });
      });
    }

  public render(): void {

var html = "";
    var query = SearchQueryBuilder.create("contenttype:themepark"); // keyword search
    query.selectProperties("OD2DescriptionOWSTEXT","Title","OD2ThemParkPicOWSURLH","RefinableString101", "Path");

      pnp.sp.search(query).then(
        (searchResults) => { 
          searchResults.PrimarySearchResults.forEach(
            ( resultItem )=> {
             console.log(resultItem);
            //  html += `${resultItem.Title}`;

             var url : string = resultItem["OD2ThemParkPicOWSURLH"];

             url = url.substr(0, url.lastIndexOf(","));
             html +=  `   <div>
                            <img style="max-width:100px" alt="${resultItem["Title"]}" src="${url}" />
                            <a href="${resultItem["Path"]}"> ${resultItem.Title} </a>
                          <div> 
                              Description : ${resultItem["OD2DescriptionOWSTEXT"]}
                          </div>
                          <div>
                            Type : ${resultItem["RefinableString101"]}
                        </div>
                         </div>`;
            });
            this.domElement.innerHTML = html;

        }
      );

      
      

   
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
