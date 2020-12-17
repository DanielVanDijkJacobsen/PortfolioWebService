define(['knockout', 'dataservice', 'store'], (ko, ds, store) => {
    return function (params) {
        let name = ko.observable('');
        let email = ko.observable('');
        let username = ko.observable('');
        let password = ko.observable('');

        let signUp = function () {
            ds.createUser({ name: name(), email: email(), nickname: username(), password: password() }, function (data) {
                console.log('usera ', data);
                store.dispatch(store.actions.populateToken(data.token));
                store.dispatch(store.actions.populateUser(data));
                //store.dispatch(store.actions.currentComponent('search-result'));
            });
        }

        return {
            name,
            email,
            username,
            password,
            signUp
        }
    }
});