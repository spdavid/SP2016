import * as React from 'react';
import styles from './MyPics.module.scss';
import { IMyPicsProps } from './IMyPicsProps';
import { escape } from '@microsoft/sp-lodash-subset';
import pnp from "sp-pnp-js";


export interface IMyPicsState {
  isReady: boolean;
}

export interface iPic {
  FileLeafRef: string;
  FileRef: string;
  Title: string;
}
let myPics: iPic[] = [];

export default class MyPics extends React.Component<IMyPicsProps, IMyPicsState> {


  constructor(props) {
    super(props);
    this.state = { isReady: false };
  }

  componentWillMount() {
    pnp.sp.web.lists.getByTitle('MyPics').items.select('FileLeafRef', 'FileRef', 'Title').get().then((data: Array<iPic>) => {
      myPics = data;
      this.setState({ isReady: true });
    });
  }

  public render(): React.ReactElement<IMyPicsProps> {
    return (
      <div className={styles.myPics}>
        {this.state.isReady &&
          <div>
            my pics
          {myPics.map((pic) => {
              return <img className={styles.myImage} src={pic.FileRef} />
            })}


          </div>



        }

        {this.state.isReady == false &&
          <div>
            loading ......
        </div>



        }
      </div>


    );

  }
}
