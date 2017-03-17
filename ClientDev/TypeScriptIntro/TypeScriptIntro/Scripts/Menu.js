var OD1;
(function (OD1) {
    var FoodCategory;
    (function (FoodCategory) {
        FoodCategory[FoodCategory["Meet"] = 0] = "Meet";
        FoodCategory[FoodCategory["Veg"] = 1] = "Veg";
        FoodCategory[FoodCategory["Pasta"] = 2] = "Pasta";
        FoodCategory[FoodCategory["Italian"] = 3] = "Italian";
        FoodCategory[FoodCategory["Thai"] = 4] = "Thai";
        FoodCategory[FoodCategory["Chinese"] = 5] = "Chinese";
        FoodCategory[FoodCategory["Breakfast"] = 6] = "Breakfast";
    })(FoodCategory = OD1.FoodCategory || (OD1.FoodCategory = {}));
    var Menu = (function () {
        function Menu() {
        }
        return Menu;
    }());
    OD1.Menu = Menu;
    var MenuPage = (function () {
        function MenuPage() {
            this.MenuItems = [];
            // seed ths object
            var mi1 = {
                Title: "Dog Food",
                Category: FoodCategory.Thai,
                Cost: 100,
                PicUrl: "http://cdn.skim.gs/image/upload/v1456338755/msi/isolated-dog-food_jg9rzk.jpg"
            };
            var mi2 = {
                Title: "Dog Food2",
                Category: FoodCategory.Meet,
                Cost: 100,
                PicUrl: "http://cdn.skim.gs/image/upload/v1456338755/msi/isolated-dog-food_jg9rzk.jpg"
            };
            var mi3 = {
                Title: "Dog Food3",
                Category: FoodCategory.Italian,
                Cost: 100,
                PicUrl: "http://cdn.skim.gs/image/upload/v1456338755/msi/isolated-dog-food_jg9rzk.jpg"
            };
            var mi4 = {
                Title: "Dog Food4",
                Category: FoodCategory.Thai,
                Cost: 100,
                PicUrl: "http://cdn.skim.gs/image/upload/v1456338755/msi/isolated-dog-food_jg9rzk.jpg"
            };
            var mi5 = {
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
        MenuPage.prototype.Init = function () {
            var _this = this;
            this.btnAdd = document.getElementById("btnAddMenuItem");
            this.txtDishTitle = document.getElementById("DishTitle");
            this.txtCost = document.getElementById("Cost");
            this.txtPicUrl = document.getElementById("PictureUrl");
            this.ddlCategory = document.getElementById("Category");
            this.btnAdd.addEventListener("click", function () {
                _this.AddItem();
            });
            this.AddFoodCategories();
            this.Render();
            // this.btnAdd.addEventListener("click", this.AddItem);
        };
        MenuPage.prototype.AddItem = function () {
            var mi = {
                Title: this.txtDishTitle.value,
                Category: FoodCategory[this.ddlCategory.options[this.ddlCategory.selectedIndex].textContent],
                Cost: Number(this.txtCost.value),
                PicUrl: this.txtPicUrl.value
            };
            this.MenuItems.push(mi);
            this.Render();
        };
        MenuPage.prototype.AddFoodCategories = function () {
            //var objValues = Object.keys(OD1.PlayerPosition).map(k => OD1.PlayerPosition[k]);  
            for (var item in FoodCategory) {
                if (isNaN(Number(item))) {
                    var newOption = document.createElement("option");
                    newOption.value = item;
                    newOption.text = item;
                    this.ddlCategory.add(newOption);
                }
            }
        };
        MenuPage.prototype.Render = function () {
            var _this = this;
            var result = document.getElementById("result");
            result.innerHTML = "";
            this.SortbyCategory();
            var currentCategory = "nothing";
            this.MenuItems.forEach(function (item, idx) {
                if (FoodCategory[item.Category] != currentCategory) {
                    var catElement = document.createElement("div");
                    catElement.innerHTML = "<br style='clear:both' /><h4>" + FoodCategory[item.Category] + "</h4><hr/>";
                    result.appendChild(catElement);
                    currentCategory = FoodCategory[item.Category];
                }
                var menuItem = document.createElement("div");
                menuItem.className = 'menuItem';
                menuItem.innerHTML = "\n                                <img src=" + item.PicUrl + " />\n                                <div class='title'>" + item.Title + "</div>\n                                <div class='deletebutton' >\n                                    <a href='javascript:' id='del" + idx + "' >delete</a>\n                                </div>\n                                <div class='cost'>$" + item.Cost + "</div>\n                                <div class='category'>Cat:" + FoodCategory[item.Category] + "</div>\n                            ";
                result.appendChild(menuItem);
                var aDeltag = document.getElementById('del' + idx.toString());
                aDeltag.addEventListener("click", function () {
                    console.log("delete clicked");
                    _this.DeleteItem(idx);
                });
            });
        };
        MenuPage.prototype.DeleteItem = function (idx) {
            console.log(idx);
            this.MenuItems.splice(idx, 1);
            this.Render();
        };
        MenuPage.prototype.SortbyCategory = function () {
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
        };
        return MenuPage;
    }());
    OD1.MenuPage = MenuPage;
})(OD1 || (OD1 = {}));
//# sourceMappingURL=Menu.js.map