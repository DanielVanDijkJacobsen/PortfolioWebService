define([], () => {

    //Bookmarks
    let getBookmarks = (userId, callback) => {
        fetch("api/bookmarks" + userId)
            .then(response => response.json())
            .then(callback);
    }
    let createBookmarkTitle = (userId, callback, titleId) => {
        let headers = new Headers();
        headers.append("Content-Type", "application/json");
        fetch("api/bookmarks" + userId, { method: "POST", body: JSON.stringify(titleId), headers })
            .then(response => response.json)
            .then(data => callback(data));
    }
    let deleteBookmark = url => fetch(url, { method: "DELETE" });

    //Cast information
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
    let getComment;
    let getComments;
    let createComment;
    let deleteComment;
    let updateComment;

    //FlaggedComments

    //Title formats and genres
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
    let getGenre = (id, callback) => {
        fetch("api/genre" + id)
            .then(response => response.json())
            .then(callback);
    }
    let getGenres = (callback) => {
        fetch("api/genre")
            .then(response => response.json())
            .then(callback);
    }

    //Cast known for, ratings and professions
    let getKnownFor = (id, callback) => {
        fetch("api/knownfor" + id)
            .then(response => response.json)
            .then(callback);
    }
    let getNameRatings = (id, callback) => {
        fetch("api/nameratings" + id)
            .then(response => response.json)
            .then(callback);
    }
    let getProfessions = (id, callback) => {
        fetch("api/professions" + id)
            .then(response => response.json)
            .then(callback);
    }

    //Ratings

    //Roles

    //SearchHistory

    //Title information
    let getTitleAlias = (id, callback) => {
        fetch("api/titlealias" + id)
            .then(response => response.json)
            .then(callback);
    }
    let getTitleInfo = (id, callback) => {
        fetch("api/titleinfo" + id)
            .then(response => response.json)
            .then(callback);
    }
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
    let getPopular = (callback) => {
        fetch("api/titles/popular")
            .then(response => response.json())
            .then(callback);
    };

    //Users

    return {
        getBookmarks,
        createBookmarkTitle,
        deleteBookmark,
        getCastInfo,
        getCastInfos,
        getCasts,
        getFormat,
        getFormats,
        getGenre,
        getGenres,
        getKnownFor,
        getNameRatings,
        getPopular,
        getProfessions,
        getTitleAlias,
        getTitleInfo,
        getTitle,
        getTitles
    }
});