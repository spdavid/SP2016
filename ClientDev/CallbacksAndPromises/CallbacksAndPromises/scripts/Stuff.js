var CallBacks = (function () {
    function CallBacks() {
    }
    CallBacks.CallBackExample = function () {
        this.FunctionThatHasDelay(function (retvalue) {
            console.log("timeout done");
            console.log(retvalue);
        });
        this.FunctionThatHasDelay(this.SomeFunc);
    };
    CallBacks.FunctionThatHasDelay = function (callback) {
        // simulate a async event
        window.setTimeout(function () {
            console.log("timeout");
            var a = "sometext";
            callback(a);
        }, 5000);
    };
    CallBacks.SomeFunc = function (data) {
        console.log("timeout done 2");
        console.log(data + "2");
    };
    return CallBacks;
}());
//CallBacks.CallBackExample();
var PromisesFun = (function () {
    function PromisesFun() {
    }
    PromisesFun.PromiseExample = function () {
        this.FunctionThatHasDelay().then(function (stringvalue) {
            console.log(stringvalue);
        }).catch(function (error) {
            console.log(error);
        });
    };
    // equivalent to c# "public string FunctionThatHasDelay()"
    PromisesFun.FunctionThatHasDelay = function () {
        return new Promise(function (resolve, reject) {
            // simulate a async event
            window.setTimeout(function () {
                console.log("timeout promise");
                var a = "sometext promise";
                resolve(a);
            }, 5000);
        });
    };
    return PromisesFun;
}());
PromisesFun.PromiseExample();
//# sourceMappingURL=Stuff.js.map