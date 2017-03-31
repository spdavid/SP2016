import { Version } from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField,
  PropertyPaneDropdown,
  IPropertyPaneDropdownOption
} from '@microsoft/sp-webpart-base';
import { escape } from '@microsoft/sp-lodash-subset';
import {
  SPHttpClient,
  SPHttpClientResponse,
  ISPHttpClientOptions
} from '@microsoft/sp-http';
import styles from './HockeyPlayers.module.scss';
import * as strings from 'hockeyPlayersStrings';
import { IHockeyPlayersWebPartProps } from './IHockeyPlayersWebPartProps';
import { TaxonomyHelper } from './Helpers/TaxonomyHelper'

export default class HockeyPlayersWebPart extends BaseClientSideWebPart<IHockeyPlayersWebPartProps> {

  Positions: IPropertyPaneDropdownOption[];

  protected get disableReactivePropertyChanges(): boolean {
    return true;
  }

  protected onInit(): Promise<void> {
    // set stuff in the property pane on the init. 

    // this.Positions   =  [ 
    //                   {index: 1, key:"key1", text:"Center"},
    //                   {index: 2, key:"key2", text:"Right"},
    //                   {index: 3, key:"key3", text:"Left"},
    //                   {index: 4, key:"key4", text:"Def"},

    //                 ];
    //return new Promise((resolve, reject) => {

    this.Positions = [];

    var taxHelper = new TaxonomyHelper();
    return taxHelper.GetPositions(this.context.pageContext.site.absoluteUrl).then(
      (termCollection) => {
        for (var i = 0; i < termCollection.get_count(); i++) {
          var term = termCollection.getItemAtIndex(i);
          var option: IPropertyPaneDropdownOption = {
            index: i,
            key: term.get_name(),
            text: term.get_name()
          }
          console.log(option);
          this.Positions.push(option);

        }
        this.properties.Position = "Goalie";
        return Promise.resolve(undefined);

      }
    );

    //});


  }

  public render(): void {

    var spOpts: ISPHttpClientOptions = {
    };
    var url = `https://zalo.sharepoint.com/sites/OD1/_api/web/lists/GetByTitle('HockeyPlayers')/GetItems(query=@v1)?@v1={"ViewXml":"<View><Query><Where> <Eq> <FieldRef Name='HockeyPosition' /> <Value Type='TaxonomyFieldType'>${this.properties.Position}</Value> </Eq> </Where> </Query></View>"}`;
    console.log(url);
    this.context.spHttpClient.post(url, SPHttpClient.configurations.v1, null).then(
      (response) => {
        response.json().then((data) => {
          var players: Array<any> = data.value;
          console.log(data.value);
          this.domElement.innerHTML = "";
          players.forEach((player) => {
            this.domElement.innerHTML += `<div >
              <img src="${player.HockeyPicture.Url}" />
              <div>${player.Title}</div>
              <div>${player.HockeyShirtNumber}</div>
              <div>${player.HockeyPosition.Label}</div>
            
          </div>`;

          });


        });

      }
    );


  }

  protected get dataVersion(): Version {
    return Version.parse('1.0');
  }

  protected getPropertyPaneConfiguration(): IPropertyPaneConfiguration {
    return {
      pages: [
        {
          header: {
            description: "Select Position to show players"
          },
          groups: [
            {
              groupName: "Hockey Positions",
              groupFields: [
                PropertyPaneTextField('description', {
                  label: strings.DescriptionFieldLabel
                }),
                PropertyPaneDropdown('Position', {
                  label: "Select Position",
                  selectedKey: "Goalie",
                  options: this.Positions
                  // options: [ 
                  //   {index: 1, key:"key1", text:"Center"},
                  //   {index: 2, key:"key2", text:"Right"},
                  //   {index: 3, key:"key3", text:"Left"},
                  //   {index: 4, key:"key4", text:"Def"},

                  // ]


                })
              ]
            }
          ]
        }
      ]
    };
  }
}
