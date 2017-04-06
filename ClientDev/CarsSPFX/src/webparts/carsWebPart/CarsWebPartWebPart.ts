import { Version } from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField,
  IPropertyPaneDropdownOption,
  PropertyPaneDropdown,
  IWebPartContext
} from '@microsoft/sp-webpart-base';
import { escape } from '@microsoft/sp-lodash-subset';

import { CarHelper } from './Helpers/CarHelper'
import styles from './CarsWebPart.module.scss';
import * as strings from 'carsWebPartStrings';
import { ICarsWebPartWebPartProps } from './ICarsWebPartWebPartProps';

export default class CarsWebPartWebPart extends BaseClientSideWebPart<ICarsWebPartWebPartProps> {

  CarBrandOptions: IPropertyPaneDropdownOption[];

  protected onInit(): Promise<void> {
    return CarHelper.GetCarBrands(this.context).then(
      (brands => {
        this.CarBrandOptions = [];
        this.CarBrandOptions.push({
          index: 0,
          key: "All",
          text: "All"
        });
        brands.forEach((brand, idx) => {
          this.CarBrandOptions.push({
            index: idx + 1,
            key: brand,
            text: brand
          });
        })
        return Promise.resolve(undefined);
      })
    );
  }
  public render(): void {
      this.domElement.innerHTML  = "";
   CarHelper.GetCars(this.context, this.properties.CarBrand).then(cars => {
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
                }),
                PropertyPaneDropdown("CarBrand", {
                  label: "Car Brand",
                  options: this.CarBrandOptions
                  // options: [{
                  //   index: 1,
                  //   key: "All",
                  //   text: "All"
                  // },
                  // {
                  //   index: 2,
                  //   key: "Volvo",
                  //   text: "Volvo"
                  // }
                  // ]
                })
                //new stuff
              ]
            }
          ]
        }
      ]
    };
  }
}
