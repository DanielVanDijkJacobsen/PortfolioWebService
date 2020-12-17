define(['knockout', 'dataservice', 'store'], (ko, ds, store) => {
    return function (params) {
        let comment = ko.observable('');

        let createComment = function () {
            ds.createComment({
                comment: comment(), titleId: store.getState().title.titleId
            }, store.getState().token, function (data) {
                console.log('usera ', data);
                store.dispatch(store.actions.currentComponent('title'));
            });
        }

        return {
            comment,
            createComment,
        }
    }
});