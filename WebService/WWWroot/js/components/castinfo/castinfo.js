define(['knockout', 'dataservice', 'store'], (ko, ds, store) => {
    return function (params) {
        let castinfo = ko.observable(store.getState().castinfo);
        let token = ko.observable(store.getState().token);
        store.subscribe(() => title(store.getState().castinfo));
        store.subscribe(() => token(store.getState().token));

        return {
            castinfo,
            token,
        }
    }
});