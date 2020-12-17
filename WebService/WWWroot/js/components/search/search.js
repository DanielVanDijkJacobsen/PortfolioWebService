define(['knockout', 'dataservice', 'store'], (ko, ds, store) => {
    return function (params) {
        let searchQuery = ko.observable('');
        let token = ko.observable(store.getState().token);

        store.subscribe(() => token(store.getState().token));
        //let selectedCategory = ko.observable(store.getState().selectedCategory);

        //let selectCategory = category => {
        //    selectedCategory(category);
        //    store.dispatch(store.actions.changeCategory(category));
        //}

        let search = function () {
            ds.search(searchQuery(), token(), function (data) {
                store.dispatch(store.actions.populateSearchResult(data));
                store.dispatch(store.actions.currentComponent('search-result'));
            });
        }
       

        return {
            searchQuery,
            search,
        }
    }
});