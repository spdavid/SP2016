(function () {
    var url = "http://services.odata.org/V4/Northwind/Northwind.svc/Customers";
  
    $.getJSON(url, (returnedJson) => {
        // ASYC
      
        console.log(returnedJson);

        // make sure doc is ready
        $(document).ready(function () {
            var results = document.getElementById("result")

            for (var i = 0; i < returnedJson.value.length; i++) {
                var object = returnedJson.value[i];
                results.innerHTML += `<div style='color:green'>${object.CompanyName}</div>
                                      <div>${object.Country}</div><hr/>`;
            }
        });
    });
})();