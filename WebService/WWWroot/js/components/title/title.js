define(['knockout', 'dataservice', 'store'], (ko, ds, store) => {
    return function (params) {
        let title = ko.observable(store.getState().title);
        store.subscribe(() => title(store.getState().title));
        console.log('title', title());
        return {
            title
        }
    }
});