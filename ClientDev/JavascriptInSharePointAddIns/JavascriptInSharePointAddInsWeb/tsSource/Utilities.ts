namespace OD1 {
    export class Utilities {
        static getJSON(url) {
            var prom = new Promise((resolve, reject) => {
                var xhr = new XMLHttpRequest();
                xhr.open('GET', url);
                xhr.setRequestHeader("Accept", "application/json");
                xhr.send();

                xhr.onload = () => {
                    if (xhr.status >= 200 && xhr.status < 300) {
                        resolve(xhr.response);
                    } else {
                        // Performs the function "reject" when this.status is different than 2xx
                        console.log(xhr.statusText);
                        reject(xhr.statusText);
                    }
                };

                xhr.onerror = () => {
                    console.log(xhr.statusText);
                    reject(xhr.statusText);
                };
            });

            return prom;
        }

        static postJSON(url, data) {
            var prom = new Promise((resolve, reject) => {
                console.log("gonna post json");
                var xhr = new XMLHttpRequest();
                xhr.open('POST', url);
                xhr.setRequestHeader("X-RequestDigest", document.getElementById("__REQUESTDIGEST").getAttribute("value"));
                xhr.setRequestHeader("Accept", "application/json");
                xhr.setRequestHeader("content-type", "application/json;odata=verbose");
                xhr.send(JSON.stringify(data));

                xhr.onload = () => {

                    if (xhr.status >= 200 && xhr.status < 300) {
                        resolve(xhr.response);
                    } else {
                        // Performs the function "reject" when this.status is different than 2xx
                        console.log(JSON.parse(xhr.response));
                        reject(xhr.response);
                    }
                };

                xhr.onerror = () => {
                    console.log(JSON.stringify(xhr.response));
                    reject(xhr.response);
                };
            });

            return prom;
        }
        static postJSONwCallBack(url, data, Callback: () => any) {
            console.log("gonna post");
            var xhr = new XMLHttpRequest();
            xhr.open('POST', url);
            //request.setRequestHeader("X-RequestDigest", document.getElementById("__REQUESTDIGEST").getAttribute("value"));
            xhr.setRequestHeader("Accept", "application/json");
            xhr.setRequestHeader("content-type", "application/json;odata=verbose");
            xhr.send(JSON.stringify(data));

            xhr.onload = () => {

                if (xhr.status >= 200 && xhr.status < 300) {
                    Callback();
                } else {
                    // Performs the function "reject" when this.status is different than 2xx
                    console.log(JSON.parse(xhr.response));
                }
            };

            xhr.onerror = () => {
                console.log(JSON.stringify(xhr.response));

            };
        }

        static loadScript(url, callback) {

            var script: any = document.createElement("script")
            script.type = "text/javascript";

            if (script.readyState) {  //IE
                script.onreadystatechange = () => {
                    if (script.readyState === "loaded" || script.readyState === "complete") {
                        script.onreadystatechange = null;
                        callback();
                    }
                };
            } else {  //Others
                script.onload = () => {
                    callback();
                };
            }

            script.src = url;
            document.getElementsByTagName("head")[0].appendChild(script);
        }

        static loadCss(path) {
            let head = document.getElementsByTagName("head");

            let e = document.createElement("link");
            head[0].appendChild(e);
            e.setAttribute("type", "text/css");
            e.setAttribute("rel", "stylesheet");
            e.setAttribute("href", path);

        }

        static ready(fn: () => void) {
            if (document.readyState !== 'loading') {
                fn();
            } else {
                document.addEventListener('DOMContentLoaded', fn);

            }
        }

        static RegisterErrorMessage(Sender: any, args: SP.ClientRequestFailedEventArgs) {
            console.log("Error: " + args.get_message() + '\n' + args.get_stackTrace());
        }


    }
}