declare var _spBodyOnLoadFunctionNames :any;

class Branding
{
        
    public static MakePageGreen() {
        document.body.setAttribute("style", "background-color:green");
    }     

    static loadCss(path) {
        let head = document.getElementsByTagName("head");
        let e = document.createElement("link");
        head[0].appendChild(e);
        e.setAttribute("type", "text/css");
        e.setAttribute("rel", "stylesheet");
        e.setAttribute("href", path);
    } 
}          
 
_spBodyOnLoadFunctionNames.push("Branding.MakePageGreen");