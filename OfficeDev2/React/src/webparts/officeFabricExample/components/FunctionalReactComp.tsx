import * as React from 'react';

export const YourName : React.SFC<any> = ({ name, age }) => <p>Hi My Name is: {name} and i am {age} years old</p>
export const TheirName = ({ name: string }) => <p>Hi there name is: {name}</p>

export interface IYourName2 {
    name: string,
    age: number
}
export const Welcome: React.SFC<IYourName2> = (props) => {
    return <h1>Hello, {props.name} you are {props.age} old</h1>;
}