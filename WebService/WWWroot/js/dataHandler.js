
//Function for getting list of popular titles


define([], () => {

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
        getPopular,
        getTitles,
        getTitle
    }
});