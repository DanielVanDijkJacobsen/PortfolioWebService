define(['knockout', 'store'], (ko, store) => {
    let selectedComponent = ko.observable('popular-titles');
    //let currentParams = ko.observable();

    //let changeContent = () => {
    //    if (selectedComponent() === "category-list") {
    //        store.dispatch(store.actions.currentComponent('category-details'));
    //    } else {
    //        store.dispatch(store.actions.currentComponent('category-list'));
    //    }
    //}

    //store.dispatch(store.actions.currentComponent("category-list"));
    //store.subscribe(() => selectedComponent(store.getState().currentComponent));


    return {
        selectedComponent,
        //currentParams,
        //changeContent
    };
});