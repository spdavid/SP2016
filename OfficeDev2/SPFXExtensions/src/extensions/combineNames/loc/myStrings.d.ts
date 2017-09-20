declare interface ICombineNamesCommandSetStrings {
  Command1: string;
  Command2: string;
}

declare module 'CombineNamesCommandSetStrings' {
  const strings: ICombineNamesCommandSetStrings;
  export = strings;
}
