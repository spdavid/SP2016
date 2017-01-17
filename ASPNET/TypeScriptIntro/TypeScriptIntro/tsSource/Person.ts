// tells typescript what foo is. 
declare var foo: any;


namespace TypeScriptIntro {
    // export = public
    export class Person {
        Age: number;
        Name: string;
        FavoriteColor: string;

        constructor(age: number, name: string, favColor: string)
        {
            this.Age = age;
            this.FavoriteColor = favColor;
            this.Name = name;

            foo = this.Name + this.FavoriteColor;

            var me = this;
            document.getElementById("result").addEventListener("click", function () {
                me.clickedEvent();
            });
        }

        clickedEvent()
        {
            alert("clicked");
        }

        Introduce() {
            var introText = this.GetIntroductionText();
            $("#result").html("<div>" + introText + "</div>");
        }

        // string is return type   
        private GetIntroductionText() : string {
        //   return "Hello my name is " + this.Name + " and my favorite color is " + this.FavoriteColor;
            return `"Hello my name is ${this.Name} and my favorite color is ${this.FavoriteColor}`;

        }
    }


}

function init() {
    var person = new TypeScriptIntro.Person(37, "David", "Blue");
    person.Introduce();
}

