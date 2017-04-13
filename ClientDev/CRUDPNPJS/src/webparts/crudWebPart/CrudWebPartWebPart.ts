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

import { CarHelper } from "./helpers/CarHelper"

export default class CrudWebPartWebPart extends BaseClientSideWebPart<ICrudWebPartWebPartProps> {

  public onInit(): Promise<void> {


    return super.onInit().then(_ => {

      pnp.setup({
        spfxContext: this.context
      });

    });
  }

  public render(): void {
    this.domElement.innerHTML = "";
    CarHelper.GetCars().then((cars => {
      cars.forEach(car => {
        var carContainer = document.createElement("div");
        carContainer.innerHTML = `
          <div>${car.Title}
            <a href='#' class='editcar'>Edit</a>
            <a href='#' class='deletecar'>Delete</a>
          </div>
        `; 
        
        /// delete car event
        carContainer.getElementsByClassName("deletecar")[0].addEventListener("click", () => {
            CarHelper.DeleteItem(car.Id).then(
              () => {
                this.render();
              }
            );
        });

         /// edit car event
        carContainer.getElementsByClassName("editcar")[0].addEventListener("click", () => {
            CarHelper.EditItem(car.Id);
        });


        this.domElement.appendChild(carContainer);
      })
    })).then(() => {
      this.domElement.appendChild(document.createElement("hr"));
      var form = CarHelper.GetFormElement(this);
      this.domElement.appendChild(form);

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
