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

    public static GetFormElement(webpart: any): Element {
        var divElement = document.createElement("div");
        divElement.innerHTML = `
        <input type='hidden' id='itemId'></input>
            <div>Title: <input type='text' id='txtTitle'></input></div>
            <div>Year: <input type='number' id='txtYear'></input></div>
             <div>Model: <input type='text' id='txtModel'></input></div>
             <div>Picture: <input type='text' id='txtPicture'></input></div>
             <input id='btnSave' type='Button' class='addnewbutton' value="add New" />
            
            `;

        var button = divElement.getElementsByClassName("addnewbutton")[0] as HTMLInputElement;

        button.addEventListener("click", () => {
            if (button.value != "Update") {
                this.AddNewItem(webpart);

            }
            else {
                this.UpdateItem(webpart);

            }
        })
        return divElement;
    }

     public static UpdateItem(webpart: any) {
        var itemId = document.getElementById("itemId") as HTMLInputElement;
         console.log(itemId);
        var title = document.getElementById("txtTitle") as HTMLInputElement;
        var year = document.getElementById("txtYear") as HTMLInputElement;
        var model = document.getElementById("txtModel") as HTMLInputElement;
        var picture = document.getElementById("txtPicture") as HTMLInputElement;

        pnp.sp.web.lists.getByTitle("Cars").items.getById(Number(itemId.value)).update(
            {
                Title: title.value,
                carYear: year.value,
                carModel: model.value,
                carPicture: {
                    Url: picture.value,
                    Description: "some car"
                }
            }
        ).then(() => {
            webpart.render();
        });


    }

    public static AddNewItem(webpart: any) {
        var title = document.getElementById("txtTitle") as HTMLInputElement;
        var year = document.getElementById("txtYear") as HTMLInputElement;
        var model = document.getElementById("txtModel") as HTMLInputElement;
        var picture = document.getElementById("txtPicture") as HTMLInputElement;

        pnp.sp.web.lists.getByTitle("Cars").items.add(
            {
                Title: title.value,
                carYear: year.value,
                carModel: model.value,
                carPicture: {
                    Url: picture.value,
                    Description: "some car"
                }
            }
        ).then(() => {
            webpart.render();
        });


    }

    public static DeleteItem(id: number): Promise<void> {
        return pnp.sp.web.lists.getByTitle('Cars').items.getById(id).delete();
    }

    public static EditItem(id: number) {
        var title = document.getElementById("txtTitle") as HTMLInputElement;
        var year = document.getElementById("txtYear") as HTMLInputElement;
        var model = document.getElementById("txtModel") as HTMLInputElement;
        var picture = document.getElementById("txtPicture") as HTMLInputElement;
        var itemID = document.getElementById("itemId") as HTMLInputElement;

        var button = document.getElementById("btnSave") as HTMLInputElement;

        return pnp.sp.web.lists.getByTitle('Cars').items.getById(id).get()
            .then(data => {
                title.value = data.Title;
                year.value = data.carYear;
                model.value = data.carModel;
                picture.value = data.carPicture.Url;
                button.value = "Update";
                itemID.value = data.Id;
            });

    }


}