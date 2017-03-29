//https://api.github.com/search/repositories?q=tetris+language
define(["require", "exports", "Utilities"], function (require, exports, Utilities_1) {
    "use strict";
    //import ultils2 from 'Utilities';
    Utilities_1.Utilities.GetJson("https://api.github.com/search/repositories?q=tetris+language", function (data) {
        console.log(data);
    });
});
//# sourceMappingURL=Github.js.map