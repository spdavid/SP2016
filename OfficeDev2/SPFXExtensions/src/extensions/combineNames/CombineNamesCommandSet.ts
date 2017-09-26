import { override } from '@microsoft/decorators';
import { Log } from '@microsoft/sp-core-library';
import {
  BaseListViewCommandSet,
  Command,
  IListViewCommandSetListViewUpdatedParameters,
  IListViewCommandSetExecuteEventParameters
} from '@microsoft/sp-listview-extensibility';

import * as strings from 'CombineNamesCommandSetStrings';
import pnp from "sp-pnp-js";

declare var _spPageContextInfo : any;

/**
 * If your command set uses the ClientSideComponentProperties JSON input,
 * it will be deserialized into the BaseExtension.properties object.
 * You can define an interface to describe it.
 */
export interface ICombineNamesCommandSetProperties {
  // This is an example; replace with your own property
  disabledCommandIds: string[] | undefined;
}

const LOG_SOURCE: string = 'CombineNamesCommandSet';

export default class CombineNamesCommandSet
  extends BaseListViewCommandSet<ICombineNamesCommandSetProperties> {

  @override
  public onInit(): Promise<void> {
    Log.info(LOG_SOURCE, 'Initialized CombineNamesCommandSet');
    pnp.setup({
      spfxContext: this.context
    });
    this.properties.disabledCommandIds = [];
    this.properties.disabledCommandIds.push("COMMAND_1");
    return Promise.resolve<void>();
  }

  @override
  public onListViewUpdated(event: IListViewCommandSetListViewUpdatedParameters): void {
    console.log("is updated");
    if (this.context.pageContext.list.title == "Names") {

      console.log(event);
      if (event.selectedRows.length > 0) {
        console.log("should be visible");
        const command: Command | undefined = this.tryGetCommand("COMMAND_1");
        if (command && command.visible == false) {
          command.visible = true;
        }
      }
      else {
        console.log("should be invisible");

        const command: Command | undefined = this.tryGetCommand("COMMAND_1");
        if (command && command.visible) {
          command.visible = false;
        }
      }
    }
    else {
      this.context._commands.forEach((command) => {
        command.visible = false;
      });
    }
    // if (this.properties.disabledCommandIds) {
    //   for (const commandId of this.properties.disabledCommandIds) {
    //     const command: Command | undefined = this.tryGetCommand(commandId);
    //     if (command && command.visible) {
    //       Log.info(LOG_SOURCE, `Hiding command ${commandId}`);
    //       command.visible = false;
    //     }
    //   }
    // }
  }

  @override
  public onExecute(event: IListViewCommandSetExecuteEventParameters): void {
    switch (event.commandId) {
      case 'COMMAND_1':
        var alertText = "";
        event.selectedRows.forEach((row) => {
          console.log(row);
          var id = row.getValueByName("ID");
          var Title = row.getValueByName("Title");
          alertText += "id : " + id + " Title " + Title + "\n";


          var list = pnp.sp.web.lists.getByTitle(_spPageContextInfo.listTitle);
           list.items.getById(id).select('Title', 'LastName').get().then((item) => {
           console.log(item);
            list.items.getById(id).update({
                  FullName: item.Title +  " " + item.LastName
              });


           });


           

        //   item.update();


        });
 window.setTimeout(() => {
              location.reload();
            }, 2000);
      


        break;
      case 'COMMAND_2':
        alert(`Clicked ${strings.Command2}`);
        break;
      default:
        throw new Error('Unknown command');
    }
  }
}
