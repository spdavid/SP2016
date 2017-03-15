(function () {
    Domready(function () {
        // part 1
        var txt1 = document.getElementById("textbox1");
        var txt2 = document.getElementById("textbox2");
        var btn = document.getElementById("button1");

        btn.addEventListener("click", function() {
            txt2.value = txt1.value;
        });

        // part 2
        var select1 = document.getElementById("select1");
        var select2 = document.getElementById("select2");
        var from = document.getElementById("btnFrom");
        var to = document.getElementById("btnTo");

        // load values into first listbox
        console.log(select1);
        var option = document.createElement("option");
        option.text = "Option 1";
        select1.add(option);

        var option2 = document.createElement("option");
        option2.text = "Option 2";
        select1.add(option2);

        var option3 = document.createElement("option");
        option3.text = "Option 3";
        select1.add(option3);

        to.addEventListener("click", function () {
            moveBetweenSelectLists(select1, select2);
        });
        from.addEventListener("click", function () {
            moveBetweenSelectLists(select2, select1);
        });
    });

    function moveBetweenSelectLists(from, to) {
        var idx = from.selectedIndex;
        if (idx !== -1) {
            var option = from.options[idx];
            to.add(option);
        }
    }
    
})();