import {
    SPHttpClient,
    SPHttpClientResponse
} from '@microsoft/sp-http';

export class ListHelper {
    public static getListData(client: SPHttpClient, weburl: string): Promise<any> {

        // return new Promise((resolve, reject) => {

        //     client.get(weburl + "/_api/web/lists?$filter=Hidden eq false", SPHttpClient.configurations.v1)
        //         .then((response: SPHttpClientResponse) => {
        //             resolve(response.json());
        //         });
        // });

        return client.get(weburl + "/_api/web/lists?$filter=Hidden eq false", SPHttpClient.configurations.v1)
            .then((response: SPHttpClientResponse) => {
                return response.json();
            });
    }
}