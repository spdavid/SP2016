namespace OD1 {
    export class Main {
        Players: HockeyPlayer[]
        NameElement: HTMLInputElement;
        AgeElement: HTMLInputElement;
        PositionElement: HTMLSelectElement;
        ShirtNumberElement: HTMLInputElement;

        public SetUpPage() {
            this.NameElement = document.getElementById("Name") as HTMLInputElement;
            this.AgeElement = document.getElementById("Age") as HTMLInputElement;
            this.PositionElement = document.getElementById("position") as HTMLSelectElement;
            this.ShirtNumberElement = document.getElementById("ShirtNumber") as HTMLInputElement;
            this.Players = [];
            this.AddPositions();
            this.AddEvents();
        }

        private AddPositions() {
            //var objValues = Object.keys(OD1.PlayerPosition).map(k => OD1.PlayerPosition[k]);  
            for (let item in OD1.PlayerPosition) {
                if (isNaN(Number(item))) {
                    var newOption = document.createElement("option") as HTMLOptionElement;
                    newOption.value = item;
                    newOption.text = item;
                    this.PositionElement.add(newOption);
                }
            }
        }

        private AddEvents() {
            var button = document.getElementById("btnAddPlayer");
            var me = this;
           // button.addEventListener("click", this.AddPlayer);
            button.addEventListener("click", function () {
                //this = button click
                me.AddPlayer();
            });
        }

        private AddPlayer() {
            console.log(this);
            var name = this.NameElement.value;
            var age = Number(this.AgeElement.value);
            var position = this.PositionElement.options[this.PositionElement.selectedIndex].textContent;
            var shirtNumber = Number(this.ShirtNumberElement.value);
            
            var newPlayer = new HockeyPlayer(name, age, PlayerPosition[position], shirtNumber);

            this.Players.push(newPlayer);
            this.Render();
        }

        private Render() {
            var result = document.getElementById("result");
            result.innerHTML = "";
            var table = document.createElement("table");
            table.innerHTML = `<tr>
                                    <td>Name</td>
                                    <td>Age</td>
                                    <td>Position</td>
                                    <td>ShirtNumber</td>
                               </tr>
                                    `;
            for (var i = 0; i < this.Players.length; i++) {
                var player = this.Players[i];
                table.innerHTML += 
                    `<tr>
                        <td>${player.Name}</td>
                        <td>${player.Age}</td>
                        <td>${player.Position}</td>
                        <td>${player.ShirtNumber}</td>
                    </tr>
                    `;
            }

            result.appendChild(table);

        }


    }
}