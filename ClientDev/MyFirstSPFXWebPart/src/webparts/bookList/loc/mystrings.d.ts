declare interface IBookListStrings {
  PropertyPaneDescription: string;
  BasicGroupName: string;
  DescriptionFieldLabel: string;
}

declare module 'bookListStrings' {
  const strings: IBookListStrings;
  export = strings;
}
