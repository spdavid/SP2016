import { Version } from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-webpart-base';
import { escape } from '@microsoft/sp-lodash-subset';

import styles from './BookList.module.scss';
import * as strings from 'bookListStrings';
import { IBookListWebPartProps } from './IBookListWebPartProps';
import { BookHelper } from './Helpers/BookHelper';
import { IBook } from './Models/Interfaces';

export default class BookListWebPart extends BaseClientSideWebPart<IBookListWebPartProps> {

  public render(): void {

    BookHelper.GetBooks(this.context.spHttpClient, this.context.pageContext.web.absoluteUrl)
      .then((data) => {
        var bookList: Array<IBook> = data.value;

        bookList.forEach((book) => {
          var bookDate : Date = new Date(book.OD1DateBook);
          this.domElement.innerHTML += 
          `<div class=${styles.books}>
              <img src="${book.BookPic.Url}" alt="${book.BookPic.Description}" />
              <div>${book.Title}</div>
              <div>${book.OD1BookDesc}</div>
              <div>${book.OD1Category}</div>
              <div>${bookDate.toLocaleDateString()}</div>
          </div>`;

        });
      });;



  }

  protected get dataVersion(): Version {
    return Version.parse('1.0');
  }

  protected getPropertyPaneConfiguration(): IPropertyPaneConfiguration {
    return {
      pages: [
        {
          header: {
            description: strings.PropertyPaneDescription
          },
          groups: [
            {
              groupName: strings.BasicGroupName,
              groupFields: [
                PropertyPaneTextField('description', {
                  label: strings.DescriptionFieldLabel
                })
              ]
            }
          ]
        }
      ]
    };
  }
}
