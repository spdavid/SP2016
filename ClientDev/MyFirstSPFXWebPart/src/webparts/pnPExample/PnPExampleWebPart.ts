import { Version } from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-webpart-base';
import { escape } from '@microsoft/sp-lodash-subset';

import styles from './PnPExample.module.scss';
import * as strings from 'pnPExampleStrings';
import { IPnPExampleWebPartProps } from './IPnPExampleWebPartProps';
import pnp from "sp-pnp-js";

export default class PnPExampleWebPart extends BaseClientSideWebPart<IPnPExampleWebPartProps> {

  public onInit(): Promise<void> {

    return super.onInit().then(_ => {
      pnp.setup({
        spfxContext: this.context
      });
    });
  }

  public render(): void {
    pnp.sp.web.lists.get().then((data) => {
      //  console.log(data);
    });

    pnp.sp.web.lists.getByTitle("Cars").items.filter("carBrand eq 'Volvo'").get().then(data => {
      // console.log(data);
    })

    pnp.sp.web.update({
      Title: "New PNP JS Title For Web"
    }).then(r => {
      console.log(r);
    });

    pnp.sp.web.lists.getByTitle("Cars").items.getById(1).update({
      carColor: "Pink"
    }).then(r => {
      console.log(r);
    });;

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
