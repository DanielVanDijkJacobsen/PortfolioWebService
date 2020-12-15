define(['knockout', 'dataservice', 'store'], (ko, ds, store) => {
    return function (params) {
        let searchQuery = ko.observable('');

        //let selectedCategory = ko.observable(store.getState().selectedCategory);

        //let selectCategory = category => {
        //    selectedCategory(category);
        //    store.dispatch(store.actions.changeCategory(category));
        //}

        let search = function () {
            ds.search(searchQuery(), function (data) {
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