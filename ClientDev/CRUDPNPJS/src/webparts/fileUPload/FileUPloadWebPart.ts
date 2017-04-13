import { Version } from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-webpart-base';
import { escape } from '@microsoft/sp-lodash-subset';

import styles from './FileUPload.module.scss';
import * as strings from 'fileUPloadStrings';
import { IFileUPloadWebPartProps } from './IFileUPloadWebPartProps';
import pnp from "sp-pnp-js";
export default class FileUPloadWebPart extends BaseClientSideWebPart<IFileUPloadWebPartProps> {

 public onInit(): Promise<void> {


    return super.onInit().then(_ => {

      pnp.setup({
        spfxContext: this.context
      });

    });
  }
  public render(): void {
      this.domElement.innerHTML = `
        <input type='file' id='fileupload' value='upload image'/>
        <input type='button' id='btnuploadfile' value='upload image' />
      
      `;

      var btnupload = document.getElementById('btnuploadfile');
      var fileupload = document.getElementById('fileupload') as any;
      btnupload.addEventListener("click", () => {
       console.log( fileupload.files);
       let file = fileupload.files[0];

        let folderUrl = this.context.pageContext.web.serverRelativeUrl + "/testpiclib";
        // you can adjust this number to control what size files are uploaded in chunks
        if (file.size <= 10485760) {

            // small upload
            pnp.sp.web.getFolderByServerRelativeUrl(folderUrl).files.add(file.name, file, true).then(_ => console.log("done"));
        } else {

            // large upload
             pnp.sp.web.getFolderByServerRelativeUrl(folderUrl).files.addChunked(file.name, file, data => {


            }, true).then(_ => console.log("done!"));
        }


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
