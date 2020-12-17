define(['knockout', 'store'], (ko, store) => {
    let selectedComponent = ko.observable("initial-component");
    let token = ko.observable(null);
    //let currentParams = ko.observable();

    //let changeContent = () => {
    //    if (selectedComponent() === "search-result") {
    //        store.dispatch(store.actions.currentComponent('search-result'));
    //    } else {
    //        store.dispatch(store.actions.currentComponent('popular-titles'));
    //    }
    //}

    store.dispatch(store.actions.currentComponent("initial-component"));
    store.dispatch(store.actions.populateToken(null));
    store.subscribe(() => selectedComponent(store.getState().currentComponent));
    store.subscribe(() => token(store.getState().token));


    return {
        selectedComponent,
        token
        //currentParams,
        //changeContent
    };
});