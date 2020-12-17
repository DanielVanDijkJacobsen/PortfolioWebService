define(['knockout', 'dataservice', 'store'], (ko, ds, store) => {
    return function (params) {
        let title = ko.observable(store.getState().title);
        let token = ko.observable(store.getState().token);
        store.subscribe(() => title(store.getState().title));
        store.subscribe(() => token(store.getState().token));


        let goToComment = function () {
            store.dispatch(store.actions.currentComponent('comment'));
        }


        let createBookmark = function () {
            ds.createBookmarkTitle({ bookmarkType: 'title', typeId: title().titleId }, token(), function (data) {
                console.log('usera ', data);
                store.dispatch(store.actions.populateToken(data.jwtToken));
                store.dispatch(store.actions.currentComponent('initial-component'));
            });
        }

        return {
            title,
            token,
            createBookmark,
            goToComment
        }
    }
});