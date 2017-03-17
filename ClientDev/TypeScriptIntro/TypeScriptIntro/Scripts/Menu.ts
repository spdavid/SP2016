namespace OD1 {

    export enum FoodCategory {
        Meet,
        Veg,
        Pasta,
        Italian,
        Thai,
        Chinese,
        Breakfast
    }

    export class Menu {
        Title: string;
        PicUrl: string;
        Cost: number;
        Category: FoodCategory
    }

    export class MenuPage {
        MenuItems: Menu[];
        btnAdd: HTMLButtonElement;
        txtDishTitle: HTMLInputElement;
        txtCost: HTMLInputElement;
        txtPicUrl: HTMLInputElement;
        ddlCategory: HTMLSelectElement;

        constructor() {
            this.MenuItems = [];
            // seed ths object

            var mi1: Menu = {
                Title: "Dog Food",
                Category: FoodCategory.Thai,
                Cost: 100,
                PicUrl: "http://cdn.skim.gs/image/upload/v1456338755/msi/isolated-dog-food_jg9rzk.jpg"
            };
            var mi2: Menu = {
                Title: "Dog Food2",
                Category: FoodCategory.Meet,
                Cost: 100,
                PicUrl: "http://cdn.skim.gs/image/upload/v1456338755/msi/isolated-dog-food_jg9rzk.jpg"
            };
            var mi3: Menu = {
                Title: "Dog Food3",
                Category: FoodCategory.Italian,
                Cost: 100,
                PicUrl: "http://cdn.skim.gs/image/upload/v1456338755/msi/isolated-dog-food_jg9rzk.jpg"
            };
            var mi4: Menu = {
                Title: "Dog Food4",
                Category: FoodCategory.Thai,
                Cost: 100,
                PicUrl: "http://cdn.skim.gs/image/upload/v1456338755/msi/isolated-dog-food_jg9rzk.jpg"
            };
            var mi5: Menu = {
                Title: "Dog Food5",
                Category: FoodCategory.Italian,
                Cost: 100,
                PicUrl: "http://cdn.skim.gs/image/upload/v1456338755/msi/isolated-dog-food_jg9rzk.jpg"
            };
            this.MenuItems.push(mi1);
            this.MenuItems.push(mi2);
            this.MenuItems.push(mi3);
            this.MenuItems.push(mi4);
            this.MenuItems.push(mi5);






        }

        public Init() {
            this.btnAdd = document.getElementById("btnAddMenuItem") as HTMLButtonElement;
            this.txtDishTitle = document.getElementById("DishTitle") as HTMLInputElement;
            this.txtCost = document.getElementById("Cost") as HTMLInputElement;
            this.txtPicUrl = document.getElementById("PictureUrl") as HTMLInputElement;
            this.ddlCategory = document.getElementById("Category") as HTMLSelectElement;
            this.btnAdd.addEventListener("click", () => {
                this.AddItem();
            });
            this.AddFoodCategories();
            this.Render();
            // this.btnAdd.addEventListener("click", this.AddItem);
        }

        private AddItem() {

            var mi: Menu = {
                Title: this.txtDishTitle.value,
                Category: FoodCategory[this.ddlCategory.options[this.ddlCategory.selectedIndex].textContent],
                Cost: Number(this.txtCost.value),
                PicUrl: this.txtPicUrl.value
            };
            this.MenuItems.push(mi)

            this.Render();

        } 
         
        private AddFoodCategories() {
            //var objValues = Object.keys(OD1.PlayerPosition).map(k => OD1.PlayerPosition[k]);  
            for (let item in FoodCategory) {
                if (isNaN(Number(item))) {
                    var newOption = document.createElement("option") as HTMLOptionElement;
                    newOption.value = item;
                    newOption.text = item;
                    this.ddlCategory.add(newOption);
                }
            }
        }

        public Render() {
            var result = document.getElementById("result")
            result.innerHTML = "";


            this.SortbyCategory();

            var currentCategory = "nothing";
            this.MenuItems.forEach((item, idx) => {
                if (FoodCategory[item.Category] != currentCategory) {
                    var catElement = document.createElement("div");
                    catElement.innerHTML = "<br style='clear:both' /><h4>" + FoodCategory[item.Category] + "</h4><hr/>";
                    result.appendChild(catElement);
                    currentCategory = FoodCategory[item.Category];
                }
             

                var menuItem = document.createElement("div");
                menuItem.className = 'menuItem';
                menuItem.innerHTML = `
                                <img src=${item.PicUrl} />
                                <div class='title'>${item.Title}</div>
                                <div class='deletebutton' >
                                    <a href='javascript:' id='del${idx}' >delete</a>
                                </div>
                                <div class='cost'>$${item.Cost}</div>
                                <div class='category'>Cat:${FoodCategory[item.Category]}</div>
                            `;
                             

                result.appendChild(menuItem);

                var aDeltag = document.getElementById('del' + idx.toString());
              
                aDeltag.addEventListener("click", () => {
                    console.log("delete clicked");
                    this.DeleteItem(idx);
                })
            });
        }

        private DeleteItem(idx: number) {
            console.log(idx);
            this.MenuItems.splice(idx, 1);
            this.Render();
        }

        private SortbyCategory() {
            this.MenuItems.sort(function (a, b) {
                var nameA = FoodCategory[a.Category].toUpperCase(); // ignore upper and lowercase
                var nameB = FoodCategory[b.Category].toUpperCase(); // ignore upper and lowercase
                if (nameA < nameB) {
                    return -1;
                }
                if (nameA > nameB) {
                    return 1;
                }

                // names must be equal
                return 0;
            });

        }


    }
}