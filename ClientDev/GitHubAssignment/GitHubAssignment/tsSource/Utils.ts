namespace OD1 {
    export class utils {
        public static GetJson(url: string, Callback: (data) => any) {
            var request = new XMLHttpRequest();
            request.open('GET', url, true);

            request.onload = function () {
                if (request.status >= 200 && request.status < 400) {
                    // Success!
                    var data = JSON.parse(request.response);
                    Callback(data);
                } else {
                    // We reached our target server, but it returned an error
                    console.log("error");
                }
            };

            request.onerror = () => {
                console.log("error");
            };

            request.send();
        }

        public static Ready(callback: () => any) {
            if (document.readyState != 'loading') {
                callback();
            } else {
                document.addEventListener('DOMContentLoaded', callback);
            }
        }

        public static CreateElement(html: string): HTMLElement {
            var div = document.createElement('div');
            div.innerHTML = html;
            return div.firstChild as HTMLElement;
        }
    }


}