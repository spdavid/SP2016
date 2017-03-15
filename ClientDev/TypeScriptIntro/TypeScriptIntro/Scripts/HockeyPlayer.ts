namespace OD1 {
    export enum PlayerPosition {
        RightWing,
        LeftWing,
        Center,
        LeftDef,
        RightDef,
        Goalie
    }
   export class HockeyPlayer {
        // properties
        Name: string;
        Age: number;
        Position: PlayerPosition;
        ShirtNumber: number

        // constructor
        constructor(name: string, age: number, position: PlayerPosition, shirtNumber = 4) {
            this.Name = name;
            this.Age = age;
            this.Position = position;
            this.ShirtNumber = shirtNumber;
        }

    }
}

