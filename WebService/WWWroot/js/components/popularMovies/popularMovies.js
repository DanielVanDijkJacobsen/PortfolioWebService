define(['knockout', 'dataservice', 'store'], (ko, ds, store) => {
    return function (params) {
        let popularTitles = ko.observableArray([]);
        //let selectedCategory = ko.observable(store.getState().selectedCategory);

        //let selectCategory = category => {
        //    selectedCategory(category);
        //    store.dispatch(store.actions.changeCategory(category));
        //}

        ds.getPopular(function (data) { popularTitles(data) });

        let goToTitle = function (title) {

            //ds.getSimilarTitles(title.titleId, function (data) {
            //    console.log('vutre', data);
            //    store.dispatch(store.actions.populateSimilarTItles(data));
            //});
            ds.getTitle(title.titleId, function (data) {
                console.log('vutre', data);
                store.dispatch(store.actions.populateTitle(data));
                store.dispatch(store.actions.currentComponent('title'));
            });
        }

        return {
            popularTitles,
            goToTitle,
        }
    }
});