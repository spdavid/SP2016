import {
 
  WebPartContext
} from '@microsoft/sp-webpart-base';

export interface IShowEmailProps {
  description: string;
  ctx? : WebPartContext;
}
