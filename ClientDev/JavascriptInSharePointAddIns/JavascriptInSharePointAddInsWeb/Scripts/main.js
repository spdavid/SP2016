var OD1;
(function (OD1) {
    var Utilities = (function () {
        function Utilities() {
        }
        Utilities.getJSON = function (url) {
            var prom = new Promise(function (resolve, reject) {
                var xhr = new XMLHttpRequest();
                xhr.open('GET', url);
                xhr.setRequestHeader("Accept", "application/json");
                xhr.send();
                xhr.onload = function () {
                    if (xhr.status >= 200 && xhr.status < 300) {
                        resolve(xhr.response);
                    }
                    else {
                        // Performs the function "reject" when this.status is different than 2xx
                        console.log(xhr.statusText);
                        reject(xhr.statusText);
                    }
                };
                xhr.onerror = function () {
                    console.log(xhr.statusText);
                    reject(xhr.statusText);
                };
            });
            return prom;
        };
        Utilities.postJSON = function (url, data) {
            var prom = new Promise(function (resolve, reject) {
                console.log("gonna post json");
                var xhr = new XMLHttpRequest();
                xhr.open('POST', url);
                xhr.setRequestHeader("X-RequestDigest", document.getElementById("__REQUESTDIGEST").getAttribute("value"));
                xhr.setRequestHeader("Accept", "application/json");
                xhr.setRequestHeader("content-type", "application/json;odata=verbose");
                xhr.send(JSON.stringify(data));
                xhr.onload = function () {
                    if (xhr.status >= 200 && xhr.status < 300) {
                        resolve(xhr.response);
                    }
                    else {
                        // Performs the function "reject" when this.status is different than 2xx
                        console.log(JSON.parse(xhr.response));
                        reject(xhr.response);
                    }
                };
                xhr.onerror = function () {
                    console.log(JSON.stringify(xhr.response));
                    reject(xhr.response);
                };
            });
            return prom;
        };
        Utilities.postJSONwCallBack = function (url, data, Callback) {
            console.log("gonna post");
            var xhr = new XMLHttpRequest();
            xhr.open('POST', url);
            //request.setRequestHeader("X-RequestDigest", document.getElementById("__REQUESTDIGEST").getAttribute("value"));
            xhr.setRequestHeader("Accept", "application/json");
            xhr.setRequestHeader("content-type", "application/json;odata=verbose");
            xhr.send(JSON.stringify(data));
            xhr.onload = function () {
                if (xhr.status >= 200 && xhr.status < 300) {
                    Callback();
                }
                else {
                    // Performs the function "reject" when this.status is different than 2xx
                    console.log(JSON.parse(xhr.response));
                }
            };
            xhr.onerror = function () {
                console.log(JSON.stringify(xhr.response));
            };
        };
        Utilities.loadScript = function (url, callback) {
            var script = document.createElement("script");
            script.type = "text/javascript";
            if (script.readyState) {
                script.onreadystatechange = function () {
                    if (script.readyState === "loaded" || script.readyState === "complete") {
                        script.onreadystatechange = null;
                        callback();
                    }
                };
            }
            else {
                script.onload = function () {
                    callback();
                };
            }
            script.src = url;
            document.getElementsByTagName("head")[0].appendChild(script);
        };
        Utilities.loadCss = function (path) {
            var head = document.getElementsByTagName("head");
            var e = document.createElement("link");
            head[0].appendChild(e);
            e.setAttribute("type", "text/css");
            e.setAttribute("rel", "stylesheet");
            e.setAttribute("href", path);
        };
        Utilities.ready = function (fn) {
            if (document.readyState !== 'loading') {
                fn();
            }
            else {
                document.addEventListener('DOMContentLoaded', fn);
            }
        };
        Utilities.RegisterErrorMessage = function (Sender, args) {
            console.log("Error: " + args.get_message() + '\n' + args.get_stackTrace());
        };
        return Utilities;
    }());
    OD1.Utilities = Utilities;
})(OD1 || (OD1 = {}));
var OD1;
(function (OD1) {
    var ListHelper = (function () {
        function ListHelper() {
        }
        ListHelper.ShowLists = function () {
            // _spPageContextInfo is an object that is on every page in sharepoint
            var url = _spPageContextInfo.webAbsoluteUrl + "/_api/web/lists/?$select=Title,Hidden&$filter=Hidden eq false&$OrderBy=Title desc";
            OD1.Utilities.getJSON(url).then(function (data) {
                var parsedData = JSON.parse(data);
                OD1.Utilities.ready(function () {
                    var results = document.getElementById("results");
                    var listdata = parsedData.value;
                    listdata.forEach(function (list, idx) {
                        results.innerHTML += "<div>" + list.Title + "</div>";
                    });
                });
            });
        };
        return ListHelper;
    }());
    OD1.ListHelper = ListHelper;
})(OD1 || (OD1 = {}));
console.log("im here");
//# sourceMappingURL=main.js.map