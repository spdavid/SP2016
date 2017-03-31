import { Version } from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-webpart-base';
import { escape } from '@microsoft/sp-lodash-subset';
import {
  SPHttpClient,
  SPHttpClientResponse,
  ISPHttpClientOptions
} from '@microsoft/sp-http';
import styles from './ChangeWebTitle.module.scss';
import * as strings from 'changeWebTitleStrings';
import { IChangeWebTitleWebPartProps } from './IChangeWebTitleWebPartProps';

export default class ChangeWebTitleWebPart extends BaseClientSideWebPart<IChangeWebTitleWebPartProps> {

  buttonElement: HTMLInputElement;
  inputElemment: HTMLInputElement;

  public render(): void {

    this.buttonElement = document.createElement("input") as HTMLInputElement;
    this.buttonElement.type = "button";
    this.buttonElement.value = "Change Title";
    this.inputElemment = document.createElement("input");
    this.inputElemment.type = "text";
    this.buttonElement.addEventListener("click", () => {
      this.ChangeTitle()
    })
    this.domElement.appendChild(this.inputElemment);
    this.domElement.appendChild(this.buttonElement);

  }

  public ChangeTitle() {
    var client = this.context.spHttpClient;
    //  var spOpts: ISPHttpClientOptions = {
    //    Content-Type: {'odata-version':'3.0'},
    //     body: `{ Title: 'Developer Workbench' }`
    //   };


    var spOpts: ISPHttpClientOptions = {
      headers: {
        'X-HTTP-Method': 'MERGE'
      },
      body: JSON.stringify({ Title: this.inputElemment.value })
    };


    client.post(this.context.pageContext.web.absoluteUrl + "/_api/web", SPHttpClient.configurations.v1, spOpts)
      .then((response: SPHttpClientResponse) => {
        console.log(`Status code: ${response.status}`);
        console.log(`Status text: ${response.statusText}`);

        response.json().then((responseJSON: JSON) => {
          console.log(responseJSON);
        });

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
