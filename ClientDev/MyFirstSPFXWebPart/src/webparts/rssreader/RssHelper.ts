import {
    SPHttpClient,
    HttpClient,

    SPHttpClientResponse,
    ISPHttpClientOptions
} from '@microsoft/sp-http';
import {

    IWebPartContext
} from '@microsoft/sp-webpart-base';
export class RssHelper {


public returnRss(data)
{
    console.log(data);
}

    public GetRssFeed(url: string, context: IWebPartContext) {
        // context.spHttpClient.get(url, SPHttpClient.configurations.v1).then(
        //     (response) => {
        //         response.text().then(
        //             (data) => {

        //                 console.log(data);
        //             }

        //         );

        //     }
        // );
window["returnRss"] = this.returnRss;
        var J50Npi = { currentScript: null, getJSON: function (b, d, h) { var g = b + (b.indexOf("?") + 1 ? "&" : "?"); var c = document.getElementsByTagName("head")[0]; var a = document.createElement("script"); var f = []; var e = ""; this.success = h; d.callback = "returnRss"; for (e in d) { f.push(e + "=" + encodeURIComponent(d[e])) } g += f.join("&"); a.type = "text/javascript"; a.src = g; if (this.currentScript) { c.removeChild(this.currentScript) } c.appendChild(a) }, success: null };
        // This is a WorldIP free geo-location database.


        // No specific data need to be sent there
        var data = {};

        // We need a function callback to be executed after the response is received

console.log("json get");
        // And here is the magic:
        J50Npi.getJSON(url, data, (data) => {
            console.log("david");
            console.log(data);

        });

    }

    // success: any;
    // currentScript : any

    // private  getJSON (url, data, callback) {

    //       var src = url + (url.indexOf("?")+1 ? "&" : "?");

    //       var head = document.getElementsByTagName("head")[0];

    //       var newScript = document.createElement("script");

    //       var params = [];

    //       var param_name = ""



    //       this.success = callback;



    //       data["callback"] = "J50Npi.success";

    //       for(param_name in data){  

    //           params.push(param_name + "=" + encodeURIComponent(data[param_name]));  

    //       }

    //       src += params.join("&")



    //       newScript.type = "text/javascript";  

    //       newScript.src = src;



    //       if(this.currentScript) head.removeChild(this.currentScript);

    //       head.appendChild(newScript); 

    //     }

    // Changes XML to JSON
    private xmlToJson(xml) {

        // Create the return object
        var obj = {};

        if (xml.nodeType == 1) { // element
            // do attributes
            if (xml.attributes.length > 0) {
                obj["@attributes"] = {};
                for (var j = 0; j < xml.attributes.length; j++) {
                    var attribute = xml.attributes.item(j);
                    obj["@attributes"][attribute.nodeName] = attribute.nodeValue;
                }
            }
        } else if (xml.nodeType == 3) { // text
            obj = xml.nodeValue;
        }

        // do children
        if (xml.hasChildNodes()) {
            for (var i = 0; i < xml.childNodes.length; i++) {
                var item = xml.childNodes.item(i);
                var nodeName = item.nodeName;
                if (typeof (obj[nodeName]) == "undefined") {
                    obj[nodeName] = this.xmlToJson(item);
                } else {
                    if (typeof (obj[nodeName].push) == "undefined") {
                        var old = obj[nodeName];
                        obj[nodeName] = [];
                        obj[nodeName].push(old);
                    }
                    obj[nodeName].push(this.xmlToJson(item));
                }
            }
        }
        return obj;
    };

}