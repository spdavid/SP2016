declare interface IMyBooksWebPartStrings {
  PropertyPaneDescription: string;
  BasicGroupName: string;
  DescriptionFieldLabel: string;
}

declare module 'MyBooksWebPartStrings' {
  const strings: IMyBooksWebPartStrings;
  export = strings;
}
