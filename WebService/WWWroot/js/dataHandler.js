
//Function for getting list of popular titles
let getPopular = function (callback) {
    fetch("api/titles/popular")
        .then(function(response) {
            return response.json();
        })
        .then(function(data) {
            callback(data);
        });
};