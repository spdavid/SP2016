var OD1;
(function (OD1) {
    var GitHubRepos = (function () {
        function GitHubRepos() {
            var _this = this;
            // wait for page to load
            OD1.utils.Ready(function () {
                _this.searchButton = document.getElementById("btnSearch");
                _this.searchText = document.getElementById("Search");
                _this.results = document.getElementById("Results");
                _this.modal = document.getElementById('myModal');
                _this.searchButton.addEventListener("click", function () {
                    _this.RenderSearchResults();
                });
            });
        }
        GitHubRepos.prototype.SetupModalEvents = function () {
            var _this = this;
            var span = document.getElementsByClassName("close")[0];
            span.addEventListener("click", function () {
                _this.modal.style.display = "none";
            });
            var me = this;
            window.onclick = function (event) {
                if (event.target == me.modal) {
                    me.modal.style.display = "none";
                }
            };
        };
        GitHubRepos.prototype.RenderSearchResults = function () {
            var _this = this;
            var text = this.searchText.value;
            var url = "https://api.github.com/search/repositories?q=" + text;
            // request json from the url
            OD1.utils.GetJson(url, function (data) {
                var repos = data.items;
                console.log(repos);
                //for (var i = 0; i < repos.length; i++) {
                //    var value = repos[i];
                //    // code
                //}
                _this.results.innerHTML = "";
                repos.forEach(function (repo, idx) {
                    var html = "<div class='repoItem'><img src='" + repo.owner.avatar_url + "' />\n                                    <div>\n                                        <div class='name'>" + repo.name + "</div>\n                                        <div class='description'>" + repo.description + "</div>\n                                    </div>\n                                </div>";
                    var htmlElement = OD1.utils.CreateElement(html);
                    var nameElement = htmlElement.getElementsByClassName("name")[0];
                    nameElement.addEventListener("click", function () {
                        _this.RenderIssues(repo.url);
                    });
                    _this.results.appendChild(htmlElement);
                });
            });
        };
        GitHubRepos.prototype.RenderIssues = function (repoUrl) {
            var _this = this;
            var issueUrl = repoUrl + "/issues";
            OD1.utils.GetJson(issueUrl, function (data) {
                var resultsdiv = document.getElementById("issueresults");
                resultsdiv.innerHTML = "";
                data.forEach(function (issue) {
                    var html = "<div>" + issue.number + " : " + issue.title + "</div>";
                    resultsdiv.innerHTML += html;
                });
                _this.modal.style.display = "block";
            });
        };
        return GitHubRepos;
    }());
    OD1.GitHubRepos = GitHubRepos;
})(OD1 || (OD1 = {}));
var OD1;
(function (OD1) {
    var utils = (function () {
        function utils() {
        }
        utils.GetJson = function (url, Callback) {
            var request = new XMLHttpRequest();
            request.open('GET', url, true);
            request.onload = function () {
                if (request.status >= 200 && request.status < 400) {
                    // Success!
                    var data = JSON.parse(request.response);
                    Callback(data);
                }
                else {
                    // We reached our target server, but it returned an error
                    console.log("error");
                }
            };
            request.onerror = function () {
                console.log("error");
            };
            request.send();
        };
        utils.Ready = function (callback) {
            if (document.readyState != 'loading') {
                callback();
            }
            else {
                document.addEventListener('DOMContentLoaded', callback);
            }
        };
        utils.CreateElement = function (html) {
            var div = document.createElement('div');
            div.innerHTML = html;
            return div.firstChild;
        };
        return utils;
    }());
    OD1.utils = utils;
})(OD1 || (OD1 = {}));
//# sourceMappingURL=main.js.map