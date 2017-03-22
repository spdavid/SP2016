namespace OD1 {

    export class GitHubRepos {
        searchButton: HTMLButtonElement;
        searchText: HTMLInputElement;
        results: HTMLDivElement;
        modal: HTMLDivElement;

        constructor() {
            // wait for page to load
            utils.Ready(() => {
                this.searchButton = document.getElementById("btnSearch") as HTMLButtonElement;
                this.searchText = document.getElementById("Search") as HTMLInputElement;
                this.results = document.getElementById("Results") as HTMLDivElement;
                this.modal = document.getElementById('myModal') as HTMLDivElement;

                this.searchButton.addEventListener("click", () => {
                    this.RenderSearchResults();
                });

                

            });
        }

        SetupModalEvents() {
            var span = document.getElementsByClassName("close")[0];
            
                span.addEventListener("click", () => {
                    this.modal.style.display = "none";
                });

                var me = this;
            window.onclick = function (event) {
                if (event.target == me.modal) {
                    me.modal.style.display = "none";
                }
            }
        }

        RenderSearchResults() {
            var text = this.searchText.value;
            var url = `https://api.github.com/search/repositories?q=${text}`;
            // request json from the url
            utils.GetJson(url, (data) => {
                var repos: Array<any> = data.items;
                console.log(repos);
                //for (var i = 0; i < repos.length; i++) {
                //    var value = repos[i];
                //    // code
                //}
                this.results.innerHTML = "";
                repos.forEach((repo, idx) => {
                    var html = `<div class='repoItem'><img src='${repo.owner.avatar_url}' />
                                    <div>
                                        <div class='name'>${repo.name}</div>
                                        <div class='description'>${repo.description}</div>
                                    </div>
                                </div>`;

                    var htmlElement = utils.CreateElement(html);
                    var nameElement = htmlElement.getElementsByClassName("name")[0];
                    nameElement.addEventListener("click", () => {
                        this.RenderIssues(repo.url);
                    });
                    this.results.appendChild(htmlElement);
                });

            });

        }

        RenderIssues(repoUrl : string) {
            var issueUrl = repoUrl + "/issues";
            utils.GetJson(issueUrl, (data : Array<any>) => {
            var resultsdiv = document.getElementById("issueresults") as HTMLDivElement;
            resultsdiv.innerHTML = "";
            data.forEach((issue) => {
                var html = `<div>${issue.number} : ${issue.title}</div>`;
                resultsdiv.innerHTML += html;
            });
           
            this.modal.style.display = "block";

            });
        }


    }



}