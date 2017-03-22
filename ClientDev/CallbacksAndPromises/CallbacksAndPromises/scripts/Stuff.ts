



class CallBacks {
    public static CallBackExample() {
        this.FunctionThatHasDelay((retvalue) => {
            console.log("timeout done")
            console.log(retvalue)
        });

        this.FunctionThatHasDelay(this.SomeFunc);

    }

    static FunctionThatHasDelay(callback : (returnvalue : string) => any) {
        // simulate a async event
        window.setTimeout(() => {
            console.log("timeout");
            var a = "sometext";
            callback(a);
        }, 5000);
    }

    static SomeFunc(data: string) {
        console.log("timeout done 2")
        console.log(data + "2")
    }

}


//CallBacks.CallBackExample();

class PromisesFun {

    public static PromiseExample() {
        this.FunctionThatHasDelay().then((stringvalue) => {
            console.log(stringvalue);
        }).catch((error) => {
            console.log(error);
        });
    }

    // equivalent to c# "public string FunctionThatHasDelay()"
    static FunctionThatHasDelay(): Promise<string> {
        return new Promise((resolve, reject) => { 
        // simulate a async event
        window.setTimeout(() => {
            console.log("timeout promise");
            var a = "sometext promise";
            resolve(a);
            }, 5000);

        });
    }

}

PromisesFun.PromiseExample();