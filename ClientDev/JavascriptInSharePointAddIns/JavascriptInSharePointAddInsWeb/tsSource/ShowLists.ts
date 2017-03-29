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

        public static DisplayBooks() {
           // var url = _spPageContextInfo.webAbsoluteUrl + "/_api/web/lists/GetByTitle('Books')/items?$select=Title,OD1Category,BookPic,OD1DateBook,OD1BookDesc&$orderby=OD1DateBook";
            //
            var url = _spPageContextInfo.webAbsoluteUrl + "/_api/web/lists/GetByTitle('Books')/items?$select=*,SchoolLookup/Id,SchoolLookup/Title&$expand=SchoolLookup";

            Utilities.getJSON(url).then(
                (data: string) => {
                    var parsed = JSON.parse(data);
                    console.log(parsed);
                   
                    var books: Array<any> = parsed.value;
                    Utilities.ready(() => {
                        var bookResults = document.getElementById("BookResults");
                        books.forEach(
                            (book, idx) => {
                                var bookDate = new Date(book.OD1DateBook);
                                bookResults.innerHTML += `
                                <img src='${book.BookPic.Url}' />
                                <div>
                                    ${book.Title}
                                </div>
                                <div>${book.OD1BookDesc}</div>
                                <div>${book.OD1Category}</div>
                                <div>${bookDate.format("yyyy-MM-dd")}</div>
                            `;
                            }
                        );
                    });

                }
            );
        }
    }
}

console.log("im here");