define(['knockout', 'dataservice', 'store'], (ko, ds, store) => {
    return function (params) {
        let casts = ko.observableArray(store.getState().searchResult.casts.slice(0, 5));
        let titles = ko.observableArray(store.getState().searchResult.titles.slice(0, 5));
        let countTitles = ko.observable(store.getState().searchResult.titles.length);
        let totalPages = ko.observable(Math.round(countTitles() / 5));

        let countCast = ko.observable(store.getState().searchResult.casts.length);
        let totalPagesCast = ko.observable(Math.round(countCast() / 5));
        let currentPage = ko.observable(1);
        store.subscribe(() => casts(store.getState().searchResult.casts.slice(0, 5)));
        store.subscribe(() => titles(store.getState().searchResult.titles.slice(0, 5)));
        store.subscribe(() => countTitles(store.getState().searchResult.titles.length));
        store.subscribe(() => totalPages(Math.round(store.getState().searchResult.titles.length / 5)));
        store.subscribe(() => countCast(store.getState().searchResult.casts.length));
        store.subscribe(() => totalPagesCast(Math.round(store.getState().searchResult.casts.length / 5)));

        console.log('countTitles', countTitles());
        console.log('totalPages', totalPages());
        let goToTitle = function (title) {

            ds.getTitle(title.titleId, function (data) {
                console.log('vutre', data);
                store.dispatch(store.actions.populateTitle(data));
                store.dispatch(store.actions.currentComponent('title'));
            });
        }

        let nextPage = function (title) {
            console.log('stranica', title);
            titles(store.getState().searchResult.titles.slice((title - 1) * 5, (title -1) * 5 + 5));
        }

        let nextPageCast = function (title) {
            console.log('stranica', title);
            casts(store.getState().searchResult.casts.slice((title) * 5, (title) * 5 + 5));
        }

        return {
            casts,
            titles,
            goToTitle,
            totalPages,
            totalPagesCast,
            currentPage,
            nextPage,
            nextPageCast
        }
    }
});