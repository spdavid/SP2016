import * as React from 'react';
import styles from './ShowEmail.module.scss';
import { IShowEmailProps } from './IShowEmailProps';
import { escape } from '@microsoft/sp-lodash-subset';
import {
  HttpClientConfiguration,
  HttpClient
} from '@microsoft/sp-http';


export interface IShowEmailState {
  isready?: boolean
}


let emailData: Array<any> = [];

export default class ShowEmail extends React.Component<IShowEmailProps, IShowEmailState> {

constructor() {
  super();

  this.state= { isready : false};


}

  componentWillMount() {

    this.props.ctx.httpClient.get("https://graphfunctions.azurewebsites.net/api/ShowEmail?code=nF6MzmHFwaGPWNrGUCaKJ4HQV8MV81QndyVDZ2fGZengLWLegsAMSg==", HttpClient.configurations.v1)
      .then(response => {
        if (response.ok) {
          response.json().then(data => {
            console.log(data);
            emailData = data.value;
            this.setState({ isready: true });
          });
        }
        else {
          console.log(response.status);
        }
      })

  }

  public render(): React.ReactElement<IShowEmailProps> {
    console.log("isready");
    console.log(emailData);
    return (

      <div className={styles.showEmail}>
        {this.state.isready &&
          emailData.map(email => {
            return <div>{email.subject}</div>
          })
        }
      </div>

    );
  }
}
