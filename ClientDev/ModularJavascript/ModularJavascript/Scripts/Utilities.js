define(["require", "exports"], function (require, exports) {
    "use strict";
    var Utilities = (function () {
        function Utilities() {
        }
        Utilities.GetJson = function (url, Callback) {
            var request = new XMLHttpRequest();
            request.open('GET', url, true);
            request.onload = function () {
                if (request.status >= 200 && request.status < 400) {
                    // Success!
                    var data = JSON.parse(request.response);
                    Callback(data);
                }
                else {
                    // We reached our target server, but it returned an error
                    console.log("error");
                }
            };
            request.onerror = function () {
                console.log("error");
            };
            request.send();
        };
        Utilities.Ready = function (callback) {
            if (document.readyState != 'loading') {
                callback();
            }
            else {
                document.addEventListener('DOMContentLoaded', callback);
            }
        };
        return Utilities;
    }());
    exports.Utilities = Utilities;
    var Somethingelse = (function () {
        function Somethingelse() {
        }
        return Somethingelse;
    }());
    exports.Somethingelse = Somethingelse;
});
//# sourceMappingURL=Utilities.js.map