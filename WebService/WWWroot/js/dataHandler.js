define([], () => {

    //Unsure if entity framework (bookmarks, comment and like) has all of its functionality.
    //Unsure if casts query is still undefined.

    let getBookmarks = (userId, callback) => {
        fetch("api/bookmarks" + userId)
            .then(response => response.json())
            .then(callback);
    }

    let getCastInfo = (id, callback) => {
        fetch("api/castinfo" + id)
            .then(response => response.json())
            .then(callback);
    }

    let getCastInfos = (callback) => {
        fetch("api/castinfo")
            .then(response => response.json)
            .then(callback);
    }

    let getCasts = (id, callback) => {
        fetch("api/casts" + id)
            .then(response => response.json())
            .then(callback);
    }

    //Comments
    //FlaggedComments

    let getFormat = (id, callback) => {
        fetch("api/formats" + id)
            .then(response => response.json())
            .then(callback);
    }

    let getFormats = (callback) => {
        fetch("api/formats")
            .then(response => response.json())
            .then(callback);
    }

    let getPopular = (callback) => {
        fetch("api/titles/popular")
            .then(response => response.json())
            .then(callback);
    };

    let getTitle = (id, callback) => {
        fetch("api/categories" + id)
            .then(response => response.json)
            .then(callback);
    }

    let getTitles = (callback) => {
        fetch("api/titles")
            .then(response => response.json())
            .then(callback);
    }


    return {
        getBookmarks,
        getCastInfo,
        getCastInfos,
        getCasts,
        getFormat,
        getFormats,
        getPopular,
        getTitle,
        getTitles
    }
});