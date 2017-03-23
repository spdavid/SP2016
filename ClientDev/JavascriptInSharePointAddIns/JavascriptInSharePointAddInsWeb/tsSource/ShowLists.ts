namespace OD1 {
    export class ListHelper {
        public static ShowLists() {
          
                // _spPageContextInfo is an object that is on every page in sharepoint
                var url = _spPageContextInfo.webAbsoluteUrl + "/_api/web/lists/?$select=Title,Hidden&$filter=Hidden eq false&$OrderBy=Title desc";
                Utilities.getJSON(url).then((data: string) => {
                    var parsedData = JSON.parse(data);

                    Utilities.ready(() => {
                        var results = document.getElementById("results");
                        var listdata: Array<any> = parsedData.value;

                        listdata.forEach((list, idx) => {
                            results.innerHTML += `<div>${list.Title}</div>`;
                        });


                    });
                });
          
        }
    }
}

console.log("im here");