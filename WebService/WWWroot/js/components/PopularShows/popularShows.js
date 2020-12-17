define(['knockout', 'dataservice', 'store'], (ko, ds, store) => {
    return function (params) {
        let popularShows = ko.observableArray([]);


        ds.getPopularShows(function (data) { popularShows(data) });

        let goToTitle = function (title) {

            ds.getTitle(title.titleId, function (data) {
                console.log('vutre', data);
                store.dispatch(store.actions.populateTitle(data));
                store.dispatch(store.actions.currentComponent('title'));
            });
        }

        return {
            popularShows,
            goToTitle
        }
    }
});