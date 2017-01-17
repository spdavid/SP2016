var TypeScriptIntro;
(function (TypeScriptIntro) {
    // export = public
    var Person = (function () {
        function Person(age, name, favColor) {
            this.Age = age;
            this.FavoriteColor = favColor;
            this.Name = name;
            foo = this.Name + this.FavoriteColor;
            var me = this;
            document.getElementById("result").addEventListener("click", function () {
                me.clickedEvent();
            });
        }
        Person.prototype.clickedEvent = function () {
            alert("clicked");
        };
        Person.prototype.Introduce = function () {
            var introText = this.GetIntroductionText();
            $("#result").html("<div>" + introText + "</div>");
        };
        // string is return type   
        Person.prototype.GetIntroductionText = function () {
            //   return "Hello my name is " + this.Name + " and my favorite color is " + this.FavoriteColor;
            return "\"Hello my name is " + this.Name + " and my favorite color is " + this.FavoriteColor;
        };
        return Person;
    }());
    TypeScriptIntro.Person = Person;
})(TypeScriptIntro || (TypeScriptIntro = {}));
function init() {
    var person = new TypeScriptIntro.Person(37, "David", "Blue");
    person.Introduce();
}
