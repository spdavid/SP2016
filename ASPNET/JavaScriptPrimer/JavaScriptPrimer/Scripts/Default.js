
// wait for document to be fully loaded
$(document).ready(
    // this function runs when the page is loaded. 
    function () {
        document.getElementById("result").innerHTML = "Hello World";
        DisplayPhotos();
    }
);

// function for my onclick event. 
function myFunction()
{
    document.getElementById("result").innerHTML = "You Clicked me at " + (new Date()).toString();
}


function CheckifBiggerThen10(value)
{
    console.log(value);
    if (value.length > 10) {
        var errorElement = $('#errortext');
        errorElement.css("color", "red");
        document.getElementById("errortext").innerHTML = "you canot have bigger then 10";
        $("#coolbutton").attr("disabled", "true");
    }
    else
    {
        var errorElement = $('#errortext');
        errorElement.css("color", "green");
        errorElement.text("good you are under 10");
        $("#coolbutton").removeAttr("disabled");

    }

}

function onlyNumbers(e)
{
   
    if (e.keyCode >= 48 && e.keyCode <= 57)
    {
        return true;
    }
    else
    {
        return false

    }
}

function DisplayPhotos() {

    $.getJSON("https://jsonplaceholder.typicode.com/photos?albumId=1",
        //success
        function (data, status) {
            for (var i = 0; i < data.length; i++) {
                var photo = data[i];
                console.log(photo);

                $("#result2").append("<div>" + photo.title + "</div>");
                $("#result2").append("<img width='20px' src=" + photo.url + " />");

            }
       
        }
       
    );

}





