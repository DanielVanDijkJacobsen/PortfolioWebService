define(['knockout', 'store'], (ko, store) => {
    let selectedComponent = ko.observable('popular-titles');


    return {
        selectedComponent,
        //currentParams,
        //changeContent
    };
});