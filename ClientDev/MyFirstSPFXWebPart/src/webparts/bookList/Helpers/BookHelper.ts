import {
    SPHttpClient,
    SPHttpClientResponse
} from '@microsoft/sp-http';

export class BookHelper 
{
    public static GetBooks(client: SPHttpClient, webUrl: string) : Promise<any>
    {

        return client.get(webUrl + "/_api/web/lists/GetByTitle('Books')/items?$select=Title,BookPic,OD1BookDesc,OD1Category,OD1DateBook", SPHttpClient.configurations.v1)
        .then((response)=> {
                if (response.ok)
                {
                    return response.json();
                }else
                {
                    console.log(response.statusText);
                }
        });

    }

}