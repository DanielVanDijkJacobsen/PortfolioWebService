define(['knockout', 'store'], (ko, store) => {
    let selectedComponent = ko.observable("initial-component");
    let token = ko.observable(null);
    //let currentParams = ko.observable();

    let goToHome = () => {
        store.dispatch(store.actions.currentComponent('initial-component'));
    }

    store.dispatch(store.actions.currentComponent("initial-component"));
    store.dispatch(store.actions.populateToken(null));
    store.subscribe(() => selectedComponent(store.getState().currentComponent));
    store.subscribe(() => token(store.getState().token));


    return {
        selectedComponent,
        token,
        goToHome
        //currentParams,
        //changeContent
    };
});