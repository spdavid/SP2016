import { override } from '@microsoft/decorators';
import { Log } from '@microsoft/sp-core-library';
import {
  BaseListViewCommandSet,
  Command,
  IListViewCommandSetListViewUpdatedParameters,
  IListViewCommandSetExecuteEventParameters
} from '@microsoft/sp-listview-extensibility';

import * as strings from 'CombineNamesCommandSetStrings';

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

    this.properties.disabledCommandIds = [];
    this.properties.disabledCommandIds.push("COMMAND_1");
    return Promise.resolve<void>();
  }

  @override
  public onListViewUpdated(event: IListViewCommandSetListViewUpdatedParameters): void {
    
    if (this.context.pageContext.list.title == "Webbplatsmallar") {

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



        });

        alert(alertText);
        break;
      case 'COMMAND_2':
        alert(`Clicked ${strings.Command2}`);
        break;
      default:
        throw new Error('Unknown command');
    }
  }
}
