define(['knockout', 'dataservice', 'store'], (ko, ds, store) => {
    return function (params) {
        let email = ko.observable('');
        let password = ko.observable('');

        let logIn = function () {
            ds.userLogin({ email: email(), password: password() }, function (data) {
                console.log('usera ', data);
                store.dispatch(store.actions.populateToken(data.jwtToken));
                store.dispatch(store.actions.populateUser(data));
                store.dispatch(store.actions.currentComponent('initial-component'));
            });
        }


        return {
            email,
            password,
            logIn,
        }
    }
});