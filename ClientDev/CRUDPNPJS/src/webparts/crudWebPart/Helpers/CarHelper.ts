import pnp from "sp-pnp-js";

export class CarHelper {
    public static GetCars(): Promise<Array<any>> {
        return new Promise((resolve, reject) => {
            console.log("GetCars");
            return pnp.sp.web.lists.getByTitle("Cars").items.get()
                .then(data => {
                    resolve(data);
                })
                .catch(error => {
                    reject(error);

                });
        });
    }

    public static GetFormElement() : Element
    {
        var divElement = document.createElement("div");
            divElement.innerHTML = `
            <div>Title: <input type='text' id='txtTitle'></input></div>
            <div>Year: <input type='number' id='txtYear'></input></div>
             <div>Model: <input type='text' id='txtModel'></input></div>
             <div>Picture: <input type='text' id='txtPicture'></input></div>
             <input type='Button' value="add New" />
            
            `;

        return divElement;
    }


}