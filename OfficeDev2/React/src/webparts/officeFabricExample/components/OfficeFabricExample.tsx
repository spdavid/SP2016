import * as React from 'react';
import styles from './OfficeFabricExample.module.scss';
import { IOfficeFabricExampleProps } from './IOfficeFabricExampleProps';
import { escape } from '@microsoft/sp-lodash-subset';
import { TextField } from 'office-ui-fabric-react/lib/TextField';
import { DefaultButton, IButtonProps } from 'office-ui-fabric-react/lib/Button';
import { Label } from 'office-ui-fabric-react/lib/Label';
import  { YourName , TheirName, Welcome  } from './FunctionalReactComp'


export default class OfficeFabricExample extends React.Component<IOfficeFabricExampleProps, {}> {
 
  textfield : any;
 
  public render(): React.ReactElement<IOfficeFabricExampleProps> {
    return (
      <div className={styles.officeFabricExample}>
        <YourName age="12" name="david" />
        <Welcome name="David" age={12} />
      <TextField ref={TextField => this.textfield = TextField} label='TextField with a placeholder' placeholder='Now I am a Placeholder' ariaLabel='Please enter text here' />
      <div>
        
          <Label>Primary</Label>
          <DefaultButton
            data-automation-id='test'
            disabled={ false }
            checked={ false }
            text='Butjon'
            onClick={ () => alert(this.textfield.value) }
          />
        </div>
      </div>
    );
  }
}
