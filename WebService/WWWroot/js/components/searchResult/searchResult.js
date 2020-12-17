define(['knockout', 'dataservice', 'store'], (ko, ds, store) => {
    return function (params) {
        let casts = ko.observableArray(store.getState().searchResult.casts.slice(0, 5));
        let titles = ko.observableArray(store.getState().searchResult.titles.slice(0, 5));
        store.subscribe(() => casts(store.getState().searchResult.casts.slice(0, 5)));
        store.subscribe(() => titles(store.getState().searchResult.titles.slice(0, 5)));

        let goToTitle = function (title) {

            ds.getTitle(title.titleId, function (data) {
                console.log('vutre', data);
                store.dispatch(store.actions.populateTitle(data));
                store.dispatch(store.actions.currentComponent('title'));
            });
        }

        return {
            casts,
            titles,
            goToTitle,
        }
    }
});