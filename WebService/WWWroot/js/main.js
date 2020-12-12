require.config({
    baseUrl: "js",
    paths: {
        knockout: "lib/knockout/knockout-latest.debug",
        text: "lib/require-text/text.min",
        dataservice: "services/dataHandler",
        store: "services/store"
    }
});

require(['knockout', 'text'], (ko) => {
    //ko.components.register("my", {
    //    viewModel: { require: "components/my/my" },
    //    template: { require: "text!components/my/my.html" }
    //});

    //ko.components.register("category-list",
    //    {
    //        viewModel: { require: "components/categoryList/categoryList" },
    //        template: { require: "text!components/categoryList/categoryList.html" }
    //    });

    //ko.components.register("category-details",
    //    {
    //        viewModel: { require: "components/categoryDetails/categoryDetails" },
    //        template: { require: "text!components/categoryDetails/categoryDetails.html" }
    //    });



    ko.components.register("popular-titles",
        {
            viewModel: { require: "components/popularMovies/popularMovies"},
            template: { require: "text!components/popularMovies/popularMovies.html"}
        });


});

require(['knockout', 'text'], (ko) => {

    ko.components.register("popular-shows",
        {
            viewModel: { require: "components/popularShows/popularShows" },
            template: { require: "text!components/popularShows/popularShows.html" }
        });
});


require(['knockout', 'viewModel', 'store'], (ko, vm, store) => {
    store.subscribe(() => console.log(JSON.stringify(store.getState())));
    ko.applyBindings(vm);
});