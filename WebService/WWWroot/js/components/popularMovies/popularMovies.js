define(['knockout', 'dataservice', 'store'], (ko, ds, store) => {
    return function (params) {
        let popularTitles = ko.observableArray([]);
        //let selectedCategory = ko.observable(store.getState().selectedCategory);

        //let selectCategory = category => {
        //    selectedCategory(category);
        //    store.dispatch(store.actions.changeCategory(category));
        //}

        ds.getPopular(function (data) { popularTitles(data) });

        return {
            popularTitles
        }
    }
});