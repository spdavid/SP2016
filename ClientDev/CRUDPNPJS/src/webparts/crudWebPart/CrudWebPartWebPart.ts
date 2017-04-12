import { Version } from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-webpart-base';
import { escape } from '@microsoft/sp-lodash-subset';

import styles from './CrudWebPart.module.scss';
import * as strings from 'crudWebPartStrings';
import { ICrudWebPartWebPartProps } from './ICrudWebPartWebPartProps';
import pnp from "sp-pnp-js";

import { CarHelper} from "./helpers/CarHelper"

export default class CrudWebPartWebPart extends BaseClientSideWebPart<ICrudWebPartWebPartProps> {

public onInit(): Promise<void> {

  return super.onInit().then(_ => {

    pnp.setup({
      spfxContext: this.context
    });
    
  });
}

  public render(): void {
    CarHelper.GetCars().then((cars => {
        cars.forEach(car => {
            this.domElement.innerHTML += `<div>${car.Title}</div>`;
        })
    }));



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
