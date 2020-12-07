define([], () => {

    //
    // Unsure of how to correctly interact with the Framework, will look through the class sessions and make modifications.
    // -Daniel 07-12-2020
    //

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
    let getComment = (id, callback) => {
        fetch("api/comments" + id)
            .then(response => response.json())
            .then(callback);
    };
    let getComments; //Unsure of how to call.
    let createComment = (comment, callback) => {
        let headers = new Headers();
        headers.append("Content-Type", "application/json");
        fetch("api/comments", { method: "POST", body: JSON.stringify(comment), headers })
            .then(response => response.json)
            .then(data => callback(data));
    };
    let deleteComment = url => fetch(url, { method: "DELETE" });
    let updateComment; //Unsure of how to call

    //FlaggedComments
    let flagComment = (id, callback) => {
        let headers = new Headers();
        headers.append("Content-Type", "application/json");
        fetch("api/flaggedComments", { method: "POST", body: JSON.stringify(id), headers })
            .then(response => response.json)
            .then(data => callback(data));
    }
    let deleteFlagOnComment = url => fetch(url, { method: "DELETE" });

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
    //Unsure of how to resolve the url path, how do we url the combined key's?

    //Roles
    let getRole = (id, callback) => {
        fetch("api/roles" + id)
            .then(response => response.json)
            .then(callback);
    }
    let deleteRole = url => fetch(url, { method: "DELETE" });
    let giveRole; //Unsure of how to resolve.
    let modifyRole; //Unsure of how to resolve.

    //SearchHistory
    let getSearchHistory = (id, callback) => {
        fetch("api/searchhistory" + id)
            .then(respone => respone.json)
            .then(callback);
    }

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
    let getUsers = (callback) => {
        fetch("api/users")
            .then(response => response.json)
            .then(callback);
    };
    let getUser = (íd, callback) => {
        fetch("api/users" + id)
            .then(response => response.json)
            .then(callback);
    };
    let createUser = (callback) => {

    };//Unsure of how to handle.
    let userLogin;//Unsure.
    let updateUser;//Unsure.
    let deleteUser = url => fetch(url, { method: "DELETE" });

    return {
        getBookmarks,
        createBookmarkTitle,
        deleteBookmark,
        getCastInfo,
        getCastInfos,
        getCasts,
        getComment,
        getComments,
        createComment,
        deleteComment,
        updateComment,
        flagComment,
        deleteFlagOnComment,
        getFormat,
        getFormats,
        getGenre,
        getGenres,
        getKnownFor,
        getNameRatings,
        getPopular,
        getProfessions,
        getRole,
        deleteRole,
        giveRole,
        modifyRole,
        getSearchHistory,
        getTitleAlias,
        getTitleInfo,
        getTitle,
        getTitles,
        getUsers,
        getUser,
        createUser,
        userLogin,
        updateUser,
        deleteUser
    }
});