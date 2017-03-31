

export class TaxonomyHelper {
    taxonomySession: any;
   

    public GetPositions(siteUrl : string): Promise<SP.Taxonomy.TermCollection> {
        return new Promise((resolve, reject) => {

            this.loadScripts(siteUrl).then(() => { // loading scripts first

                var context = SP.ClientContext.get_current();
                this.taxonomySession = SP.Taxonomy.TaxonomySession.getTaxonomySession(context);
                let termStore = this.taxonomySession.getDefaultSiteCollectionTermStore();

                let group = termStore.getGroup(new SP.Guid("46933810-79f7-41df-a9b9-d2aaf7ba0e3a"));
                let termsets = group.get_termSets();
                let termSet = termsets.getById(new SP.Guid("635b5bca-8c5f-4831-8bf8-a0d9d5eb75e0"));
                let terms = termSet.get_terms();
                context.load(terms);
                context.executeQueryAsync(() => {
                    console.log(terms);
                    resolve(terms);
                });

            });
        });
    }


    private loadScripts(siteUrl : string): Promise<void> {
        return new Promise<void>((resolve) => {
            //
            // constructing path to Layouts folder
            //
            let layoutsUrl: string = siteUrl; //this.context.pageContext.site.absoluteUrl;
            if (layoutsUrl.lastIndexOf('/') === layoutsUrl.length - 1)
                layoutsUrl = layoutsUrl.slice(0, -1);
            layoutsUrl += '/_layouts/15/';

            this.loadScript(layoutsUrl + 'init.js', 'Sod').then(() => { // loading init.js
                return this.loadScript(layoutsUrl + 'sp.runtime.js', 'sp_runtime_initialize'); // loading sp.runtime.js
            }).then(() => {
                return this.loadScript(layoutsUrl + 'sp.js', 'sp_initialize'); // loading sp.js
            }).then(() => {
                return this.loadScript(layoutsUrl + 'sp.taxonomy.js', 'SP.Taxonomy'); // loading sp.taxonomy.js
            }).then(() => {
                resolve();
            });
        });
    }

    private loadScript(url: string, globalObjectName: string): Promise<void> {
        return new Promise<void>((resolve) => {
            let isLoaded = true;
            if (globalObjectName.indexOf('.') !== -1) {
                const props = globalObjectName.split('.');
                let currObj: any = window;

                for (let i = 0, len = props.length; i < len; i++) {
                    if (!currObj[props[i]]) {
                        isLoaded = false;
                        break;
                    }

                    currObj = currObj[props[i]];
                }
            }
            else {
                isLoaded = !!window[globalObjectName];
            }
            // checking if the script was previously added to the page
            if (isLoaded || document.head.querySelector('script[src="' + url + '"]')) {
                resolve();
                return;
            }

            // loading the script
            const script = document.createElement('script');
            script.type = 'text/javascript';
            script.src = url;
            script.onload = () => {
                resolve();
            };
            document.head.appendChild(script);
        });
    }

}