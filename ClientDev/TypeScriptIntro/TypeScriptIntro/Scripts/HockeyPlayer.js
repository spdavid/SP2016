var OD1;
(function (OD1) {
    var PlayerPosition;
    (function (PlayerPosition) {
        PlayerPosition[PlayerPosition["RightWing"] = 0] = "RightWing";
        PlayerPosition[PlayerPosition["LeftWing"] = 1] = "LeftWing";
        PlayerPosition[PlayerPosition["Center"] = 2] = "Center";
        PlayerPosition[PlayerPosition["LeftDef"] = 3] = "LeftDef";
        PlayerPosition[PlayerPosition["RightDef"] = 4] = "RightDef";
        PlayerPosition[PlayerPosition["Goalie"] = 5] = "Goalie";
    })(PlayerPosition = OD1.PlayerPosition || (OD1.PlayerPosition = {}));
    var HockeyPlayer = (function () {
        // constructor
        function HockeyPlayer(name, age, position, shirtNumber) {
            if (shirtNumber === void 0) { shirtNumber = 4; }
            this.Name = name;
            this.Age = age;
            this.Position = position;
            this.ShirtNumber = shirtNumber;
        }
        return HockeyPlayer;
    }());
    OD1.HockeyPlayer = HockeyPlayer;
})(OD1 || (OD1 = {}));
//# sourceMappingURL=HockeyPlayer.js.map