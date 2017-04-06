import { Version } from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField,
  IPropertyPaneDropdownOption,
  PropertyPaneDropdown
} from '@microsoft/sp-webpart-base';
import { escape } from '@microsoft/sp-lodash-subset';

import styles from './CarsPnp.module.scss';
import * as strings from 'carsPnpStrings';
import { ICarsPnpWebPartProps } from './ICarsPnpWebPartProps';
import pnp from "sp-pnp-js";


export interface ICar
{
    Title: string,
    carBrand : string,
    carColor : string,
    carModel : string,
    carYear : number,
    carPicture : {
        Description : string,
        Url: string
    }
}
export default class CarsPnpWebPart extends BaseClientSideWebPart<ICarsPnpWebPartProps> {
  carBrands: IPropertyPaneDropdownOption[];
  public onInit(): Promise<void> {



    return super.onInit().then(_ => {
      pnp.setup({
        spfxContext: this.context
      });
    }).then(() => {
      return pnp.sp.web.lists.getByTitle("Cars")
        .fields
        .getByInternalNameOrTitle("carBrand")
        .select("Choices")
        .get()
        .then(data => {
          var brands : string[] =  data.Choices;

          this.carBrands = [];
          brands.forEach((brand, idx) => {
              this.carBrands.push({
                  index: idx,
                  key: brand,
                  text: brand
              });

          });

          return Promise.resolve(undefined);
        });

    });




  }

  public render(): void {
    this.domElement.innerHTML = "";
    pnp.sp.web.lists.getByTitle("Cars")
    .items.filter(`carBrand eq '${this.properties.CarBrand}'`)
    .get().then((cars : ICar[]) => {
         cars.forEach((car) => {
        this.domElement.innerHTML += `
          <div>${car.Title}</div>
          <div>${car.carBrand}</div>
          <div>${car.carColor}</div>
          <div>${car.carModel}</div>
          <div>${car.carYear.toString()}</div>
          <div><img src='${car.carPicture.Url}' alt='${car.carPicture.Description}' /></div>
        `;
      });


    })
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
                }),
                PropertyPaneDropdown('CarBrand',
                  {
                    label: "Car brand",
                    options: this.carBrands
                  })
              ]
            }
          ]
        }
      ]
    };
  }
}
