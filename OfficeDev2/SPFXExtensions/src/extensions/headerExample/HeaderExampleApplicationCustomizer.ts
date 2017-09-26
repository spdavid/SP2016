import { override } from '@microsoft/decorators';
import { Log } from '@microsoft/sp-core-library';
import {
  BaseApplicationCustomizer,
  PlaceholderContent,
  PlaceholderName
} from '@microsoft/sp-application-base';

import * as strings from   'HeaderExampleApplicationCustomizerStrings';

import pnp from "sp-pnp-js";
import { escape } from '@microsoft/sp-lodash-subset';





export interface LinksResult
{
  URL : {
    Description: string;
    Url : string;
  }
}

const LOG_SOURCE: string = 'HeaderExampleApplicationCustomizer';

/**
 * If your command set uses the ClientSideComponentProperties JSON input,
 * it will be deserialized into the BaseExtension.properties object.
 * You can define an interface to describe it.
 */
export interface IHeaderExampleApplicationCustomizerProperties {
  // This is an example; replace with your own property
  testMessage: string;
}

/** A Custom Action which can be run during execution of a Client Side Application */
export default class HeaderExampleApplicationCustomizer
  extends BaseApplicationCustomizer<IHeaderExampleApplicationCustomizerProperties> {

  // These have been added
  private _topPlaceholder: PlaceholderContent | undefined;
  private _bottomPlaceholder: PlaceholderContent | undefined;

  @override
  public onInit(): Promise<void> {
    Log.info(LOG_SOURCE, `Initialized ${strings.Title}`);
    pnp.setup({
      spfxContext: this.context
    });
    let message: string = this.properties.testMessage;
    if (!message) {
      message = '(No properties were provided.)';
    }

    //alert(`Hello from ${strings.Title}:\n\n${message}`);
    this._renderPlaceHolders()
    return Promise.resolve<void>();
  }


  private _renderPlaceHolders(): void {

    console.log('HelloWorldApplicationCustomizer._renderPlaceHolders()');
    console.log('Available placeholders: ',
      this.context.placeholderProvider.placeholderNames.map(name => PlaceholderName[name]).join(', '));

    // Handling the top placeholder
    if (!this._topPlaceholder) {
      this._topPlaceholder =
        this.context.placeholderProvider.tryCreateContent(
          PlaceholderName.Top,
          { onDispose: this._onDispose });

      // The extension should not assume that the expected placeholder is available.
      if (!this._topPlaceholder) {
        console.error('The expected placeholder (Top) was not found.');
        return;
      }


      if (this._topPlaceholder.domElement) {
       var html = "<ul style='list-style-type: none; margin: 0;padding: 0;'>";

       pnp.sp.web.lists.getByTitle("NavigationLinks").items
       .select('URL')
       .get()
       .then((data : LinksResult[]) => {
        data.forEach((link) => {
            html += `<li style='display: inline;'><a href='${link.URL.Url}'>${link.URL.Description}</a> </li>`

        });
        html += "</ul>"
        this._topPlaceholder.domElement.innerHTML = html;
       });;


        // pnp.sp.web.lists.get().then((data : Array<any>) => {
        //   console.log(data);
        //   data.forEach((list) => {
        //     console.log(list);
        //     html += `<div>${list.Title}</div>`;
        //   });

        //   this._topPlaceholder.domElement.innerHTML = html;
        // });

        
      }
    }
  }

  private _onDispose(): void {
  console.log('[HelloWorldApplicationCustomizer._onDispose] Disposed custom top and bottom placeholders.');
}
}
