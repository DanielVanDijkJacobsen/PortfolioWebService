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

    ko.components.register("search",
        {
            viewModel: { require: "components/search/search" },
            template: { require: "text!components/search/search.html" }
        });

    ko.components.register("search-result",
        {
            viewModel: { require: "components/searchResult/searchResult" },
            template: { require: "text!components/searchResult/searchResult.html" }
        });


    ko.components.register("title",
        {
            viewModel: { require: "components/title/title" },
            template: { require: "text!components/title/title.html" }
        });

    ko.components.register("sign-up",
        {
            viewModel: { require: "components/signUp/signUp" },
            template: { require: "text!components/signUp/signUp.html" }
        });

    ko.components.register("log-in",
        {
            viewModel: { require: "components/logIn/logIn" },
            template: { require: "text!components/logIn/logIn.html" }
        });

    ko.components.register("menu",
        {
            viewModel: { require: "components/menu/menu" },
            template: { require: "text!components/menu/menu.html" }
        });

    ko.components.register("profile",
        {
            viewModel: { require: "components/profile/profile" },
            template: { require: "text!components/profile/profile.html" }
        });

    ko.components.register("comment",
        {
            viewModel: { require: "components/comment/comment" },
            template: { require: "text!components/comment/comment.html" }
        });
    ko.components.register("initial-component",
        {
            viewModel: { require: "components/initialComponent/initialComponent" },
            template: { require: "text!components/initialComponent/initialComponent.html" }
        });

    ko.components.register("popular-titles",
        {
            viewModel: { require: "components/popularMovies/popularMovies"},
            template: { require: "text!components/popularMovies/popularMovies.html"}
        });

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