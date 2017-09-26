import * as React from 'react';
import styles from './MyBooks.module.scss';

import { escape } from '@microsoft/sp-lodash-subset';
import pnp from "sp-pnp-js";

export interface IMyBooksState {
  isReady: boolean;
}

export interface IMyBook{
  Title: string;
  BookAuthor: string;
  BookImage : {
    Url :string;
    Description : string;
  }
}

export interface IMyBooksProps
{
  category: string;
}

let myBooks : IMyBook[] = [];

export default class MyBooks extends React.Component<IMyBooksProps, IMyBooksState> {

  // inital run
  componentWillMount() {
    this.GetData(this.props.category);
  }

  public GetData(category : string)
  {
    console.log("componentWillMount mybook");
    console.log(category);
    pnp.sp.web.lists.getByTitle('MyFavoriteBooks').items
    .filter("BookCategory eq '" + category + "'")
    .select('Title','BookAuthor','BookImage')
    .get()
    .then((data : IMyBook[]) => {
     myBooks = data;
     console.log(myBooks);
      this.setState({ isReady: true });
    });
  }

  // when props update
  componentWillReceiveProps(newprops)
  {
    console.log("componentWillReceiveProps");
    console.log(newprops);
   
    
    this.GetData(newprops.category);

  }
  


  public render(): React.ReactElement<IMyBooksProps> {
    console.log("render mybook");
    console.log(this.props.category);
    return (
      <div className={styles.myBooks}>
        {myBooks.map((book) => {
          return <div>
            <div>{book.Title}</div>
            <div>{book.BookAuthor}</div>
            <div><img style={{maxWidth:'200px'}} src={book.BookImage.Url} /></div>
            
          </div>

        })}
        {/* {myBooks.forEach(book => {
          <div>
            <div>{book.Title}</div>
            <div>{book.BookAuthor}</div>
            <div><img style={{maxWidth:'200px'}} src={book.BookImage.Url} /></div>
            
          </div>
       
        })
        } */}


      </div>
    );
  }
}
