
//Function for getting list of popular titles


define([], () => {

    let getBookmarks = (userId, callback) => {
        fetch("api/bookmarks" + userId)
            .then(response => response.json())
            .then(callback);
    }

    //How to call other functions than get api's

    let getPopular = (callback) => {
        fetch("api/titles/popular")
            .then(response => response.json())
            .then(callback);
    };

    let getTitles = (callback) => {
        fetch("api/titles")
            .then(response => response.json())
            .then(callback);
    }

    let getTitle = (id, callback) => {
        fetch("api/categories" + id)
            .then(response => response.json)
            .then(callback);
    }

    return {
        getBookmarks,
        getPopular,
        getTitles,
        getTitle
    }
});