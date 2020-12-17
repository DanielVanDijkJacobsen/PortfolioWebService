define(['knockout', 'dataservice', 'store'], (ko, ds, store) => {
    return function (params) {
        let token = ko.observable(store.getState().token);

        let goToLogin = function (title) {
            store.dispatch(store.actions.currentComponent('log-in'));
        }

        let goToProfile = function (title) {
            store.dispatch(store.actions.currentComponent('profile'));
        }

        let logOut = function (title) {
            store.dispatch(store.actions.populateToken(null));
            store.dispatch(store.actions.currentComponent('initial-component'));
        }

        store.subscribe(() => token(store.getState().token));
        return {
            goToLogin,
            goToProfile,
            logOut,
            token
        }
    }
});