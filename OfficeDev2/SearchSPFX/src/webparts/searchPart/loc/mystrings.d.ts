declare interface ISearchPartStrings {
  PropertyPaneDescription: string;
  BasicGroupName: string;
  DescriptionFieldLabel: string;
}

declare module 'searchPartStrings' {
  const strings: ISearchPartStrings;
  export = strings;
}
