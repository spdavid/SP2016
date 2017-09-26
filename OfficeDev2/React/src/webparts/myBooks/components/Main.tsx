import * as React from 'react';
import styles from './MyBooks.module.scss';
import { IMyBooksProps } from './IMyBooksProps';
import { escape } from '@microsoft/sp-lodash-subset';
import MyBooks from './MyBooks'
import BookCategoryDropDown from './BookCategoryDropDown'


import pnp from "sp-pnp-js";

export interface IMainState
{
  CurrentCategory : string;
}


export default class Main extends React.Component<IMyBooksProps, IMainState> {

constructor()
{
  super();
  this.myFunc = this.myFunc.bind(this);
  this.state = { CurrentCategory: "Fantasy"}
}

  public render(): React.ReactElement<IMyBooksProps> {
    return (
      <div className={styles.myBooks}>
        <BookCategoryDropDown ValueCallback={this.myFunc} FieldName="BookCategory" ListName="MyFavoriteBooks" />
        <MyBooks category={this.state.CurrentCategory} />
      </div>
    );
  }

  public myFunc (newCategory :string)
  {
      console.log(newCategory);
      this.setState({CurrentCategory: newCategory});
  }
}
