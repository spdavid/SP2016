declare interface ITaskSearchStrings {
  PropertyPaneDescription: string;
  BasicGroupName: string;
  DescriptionFieldLabel: string;
}

declare module 'taskSearchStrings' {
  const strings: ITaskSearchStrings;
  export = strings;
}
