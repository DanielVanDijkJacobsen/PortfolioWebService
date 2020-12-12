define(['knockout', 'dataservice', 'store'], (ko, ds, store) => {
    return function (params) {
        let popularShows = ko.observableArray([]);


        ds.getPopularShows(function (data) { popularShows(data) });

        return {
            popularShows
        }
    }
});