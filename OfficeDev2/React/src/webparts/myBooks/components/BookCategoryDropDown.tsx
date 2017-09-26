import * as React from 'react';
import styles from './MyBooks.module.scss';
import { escape } from '@microsoft/sp-lodash-subset';
import pnp from "sp-pnp-js";

export interface IDropDownState {
    isReady: boolean;
  }
  

export interface iDropDownProps
{
    ListName: string;
    FieldName: string;
    ValueCallback: (category : string) => void
}

let choices = [];

export default class MyBooks extends React.Component<iDropDownProps, IDropDownState> {

    componentWillMount() {
        pnp.sp.web.lists.getByTitle(this.props.ListName).fields.getByTitle(this.props.FieldName).get()
        .then((data) => {
            choices = data.Choices;
            this.setState({isReady:true});
        });

    }


    public render(): React.ReactElement<{}> {
        console.log("render");
        return (
          <div className={styles.myBooks}>
          
            <select id="mySelect" onChange={this.selectChanged.bind(this)}>
                {choices.map(choice => {
                  return  <option value={choice}>{choice}</option>
                })}
               
            </select>
    
          </div>
        );
      }

      public selectChanged(e)
      {
        this.props.ValueCallback(e.target.value);
      }


}