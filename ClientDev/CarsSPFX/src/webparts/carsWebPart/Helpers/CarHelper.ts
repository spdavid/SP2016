import {
    BaseClientSideWebPart,
    IPropertyPaneDropdownOption,
    IWebPartContext
} from '@microsoft/sp-webpart-base';
import {
    SPHttpClient,
    SPHttpClientResponse,
    ISPHttpClientOptions
} from '@microsoft/sp-http';


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

export class CarHelper {

    public static GetCarBrands(context: IWebPartContext): Promise<Array<string>> {
        return new Promise((resolve, reject) => {
            context.spHttpClient.get(context.pageContext.web.absoluteUrl + "/_api/web/lists/getByTitle('Cars')/Fields?$filter=InternalName eq 'carBrand'&$select=Choices", SPHttpClient.configurations.v1)
                .then(response => {
                    if (response.ok) {
                        response.json().then(data => {
                            resolve(data.value[0].Choices);
                        });
                    }
                    else {
                        // errorhandling
                        reject(response.statusText);
                    }

                });

        })



    }

    public static GetCars(context: IWebPartContext, carBrand: string) : Promise<ICar[]> {
        var url = "";
        if (carBrand == "All") {
            url = context.pageContext.web.absoluteUrl + "/_api/web/lists/getByTitle('Cars')/items?$select=Title,carBrand,carColor,carYear,carModel,carPicture";

        }
        else {
            url = context.pageContext.web.absoluteUrl + `/_api/web/lists/getByTitle('Cars')/items?$filter=carBrand eq '${carBrand}'&$select=Title,carBrand,carColor,carYear,carModel,carPicture`;
        }

        console.log(url);
        return new Promise((resolve, reject) => {


      
        context.spHttpClient.get(url, SPHttpClient.configurations.v1)
            .then(response => {
                if (response.ok) {
                    response.json().then(data => {
                           resolve(data.value);
                    });
                }
                else {
                    // errorhandling
                     reject(response.statusText);
                }

            });
  });

    }

}