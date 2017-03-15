var OD1;
(function (OD1) {
    var Main = (function () {
        function Main() {
        }
        Main.prototype.SetUpPage = function () {
            this.NameElement = document.getElementById("Name");
            this.AgeElement = document.getElementById("Age");
            this.PositionElement = document.getElementById("position");
            this.ShirtNumberElement = document.getElementById("ShirtNumber");
            this.Players = [];
            this.AddPositions();
            this.AddEvents();
        };
        Main.prototype.AddPositions = function () {
            //var objValues = Object.keys(OD1.PlayerPosition).map(k => OD1.PlayerPosition[k]);  
            for (var item in OD1.PlayerPosition) {
                if (isNaN(Number(item))) {
                    var newOption = document.createElement("option");
                    newOption.value = item;
                    newOption.text = item;
                    this.PositionElement.add(newOption);
                }
            }
        };
        Main.prototype.AddEvents = function () {
            var button = document.getElementById("btnAddPlayer");
            var me = this;
            // button.addEventListener("click", this.AddPlayer);
            button.addEventListener("click", function () {
                //this = button click
                me.AddPlayer();
            });
        };
        Main.prototype.AddPlayer = function () {
            console.log(this);
            var name = this.NameElement.value;
            var age = Number(this.AgeElement.value);
            var position = this.PositionElement.options[this.PositionElement.selectedIndex].textContent;
            var shirtNumber = Number(this.ShirtNumberElement.value);
            var newPlayer = new OD1.HockeyPlayer(name, age, OD1.PlayerPosition[position], shirtNumber);
            this.Players.push(newPlayer);
            this.Render();
        };
        Main.prototype.Render = function () {
            var result = document.getElementById("result");
            result.innerHTML = "";
            var table = document.createElement("table");
            table.innerHTML = "<tr>\n                                    <td>Name</td>\n                                    <td>Age</td>\n                                    <td>Position</td>\n                                    <td>ShirtNumber</td>\n                               </tr>\n                                    ";
            for (var i = 0; i < this.Players.length; i++) {
                var player = this.Players[i];
                table.innerHTML +=
                    "<tr>\n                        <td>" + player.Name + "</td>\n                        <td>" + player.Age + "</td>\n                        <td>" + player.Position + "</td>\n                        <td>" + player.ShirtNumber + "</td>\n                    </tr>\n                    ";
            }
            result.appendChild(table);
        };
        return Main;
    }());
    OD1.Main = Main;
})(OD1 || (OD1 = {}));
//# sourceMappingURL=Main.js.map