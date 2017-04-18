var Branding = (function () {
    function Branding() {
    }
    Branding.MakePageGreen = function () {
        // document.body.setAttribute("style", "background-color:green");
    };
    Branding.loadCss = function (path) {
        var head = document.getElementsByTagName("head");
        var e = document.createElement("link");
        head[0].appendChild(e);
        e.setAttribute("type", "text/css");
        e.setAttribute("rel", "stylesheet");
        e.setAttribute("href", path);
    };
    return Branding;
}());
_spBodyOnLoadFunctionNames.push("Branding.MakePageGreen");
//# sourceMappingURL=Main.js.map