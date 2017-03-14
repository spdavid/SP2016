(function () {
    // wait for page is loaded before running your code. 
    //window.onload = function () {
    //    var mydiv = document.getElementById("myDiv");
    //    console.log(mydiv);
    //    mydiv.innerText = "Hello World";
    //}

    // better way to wait until page loading.
    ready(
        function () {
            var mydiv = document.getElementById("myDiv");
            console.log(mydiv);
            mydiv.innerText = "Hello World";

            var someText = document.getElementById("sometext");
            someText.value = "Hello World";

            var mybutton2 = document.getElementById("mybutton2");
            mybutton2.addEventListener("click",  ButtonClick);

        }
    );

    function ButtonClick() {
        var someText = document.getElementById("sometext");
        someText.value = "Hello From Button";
    }
    window.ButtonClick = ButtonClick;



    function ready(fn) {
        if (document.readyState != 'loading') {
            fn();
        } else {
            document.addEventListener('DOMContentLoaded', fn);
        }
    }


})();