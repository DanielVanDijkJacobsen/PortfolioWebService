define(['knockout', 'dataservice', 'store'], (ko, ds, store) => {
    return function (params) {
        let user = ko.observable(store.getState().user);
        let userInfoName = ko.observable('');
        let userInfoNickName= ko.observable('');
        let userInfoEmail = ko.observable('');
        let token = ko.observable(store.getState().token);
        let bookmarks = ko.observableArray([]);
        let comments = ko.observableArray([]);
        let searchHistory = ko.observableArray([]);
        let totalPages = ko.observable();

        store.subscribe(() => user(store.getState().user));
        store.subscribe(() => token(store.getState().token));
        ds.getBookmarks(user().userId, null,function (data) {
            totalPages(data.totalPages);
            data.data.forEach((bookmark) => ds.getTitleInfo(bookmark.typeId, function (data) {
                bookmarks.push(data);
            }));
        });

        let nextPage = function (page) {
            bookmarks([]);
            ds.getBookmarks(user().userId, page, function (data) {
                totalPages(data.totalPages);
                data.data.forEach((bookmark) => ds.getTitleInfo(bookmark.typeId, function (data) {
                    bookmarks.push(data);
                }));
            });
        }

        ds.getUser(user().userId, token(), function (data) {
            userInfoName(data.name);
            userInfoNickName(data.nickname);
            userInfoEmail(data.email);

            data.searchHistories.forEach((history) => searchHistory.push({ searchString: history.searchString, searchTime: history.searchTime }));

            data.comments?.forEach((comment) => ds.getTitleInfo(comment.titleId, function (data) {
                comments.push({ title: data.primaryTitle, comment: comment.comment });
            }));
        })


        let update = function () {
            ds.updateUser(user().userId, { name: userInfoName(), nickname: userInfoNickName(), email: userInfoEmail() }, token(), function (data) {
            });
        }

        return {
            user,
            bookmarks,
            comments,
            searchHistory,
            userInfoName,
            userInfoNickName,
            userInfoEmail,
            update,
            nextPage,
            totalPages
        }
    }
});