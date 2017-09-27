import * as React from 'react';
import * as ReactDom from 'react-dom';
import { Version } from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-webpart-base';


import * as strings from 'OfficeFabricExampleWebPartStrings';
import OfficeFabricExample from './components/OfficeFabricExample';
import { IOfficeFabricExampleProps } from './components/IOfficeFabricExampleProps';

export interface IOfficeFabricExampleWebPartProps {
  description: string;
}

export default class OfficeFabricExampleWebPart extends BaseClientSideWebPart<IOfficeFabricExampleWebPartProps> {

  public render(): void {
    const element: React.ReactElement<IOfficeFabricExampleProps > = React.createElement(
      OfficeFabricExample,
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
