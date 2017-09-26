import * as React from 'react';
import * as ReactDom from 'react-dom';
import { Version } from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-webpart-base';

import * as strings from 'MyPicsWebPartStrings';
import MyPics from './components/MyPics';
import { IMyPicsProps } from './components/IMyPicsProps';
import pnp from "sp-pnp-js";



export interface IMyPicsWebPartProps {
  description: string;
}

export default class MyPicsWebPart extends BaseClientSideWebPart<IMyPicsWebPartProps> {

  public onInit(): Promise<void> {
      return super.onInit().then(_ => {
        pnp.setup({
          spfxContext: this.context
        });
        
      });
    }


  public render(): void {
    const element: React.ReactElement<IMyPicsProps > = React.createElement(
      MyPics,
      {
        description: this.properties.description
      }
    );

    ReactDom.render(element, this.domElement);
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
