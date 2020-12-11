define([], () => {

    const getPopularTitles = "GET_POPULAR_TITLES";
    const currentComponent = "CURRENT_COMPONENT";

    let currentState = {};
    let subscribers = [];

    let getState = () => currentState;

    let subscribe = callback => {
        subscribers.push(callback);

        return () => {
            subscribers = subscribers.filter(x => x !== callback);
        }

    };

    let reducer = (state, action) => {
        switch (action.type) {
            case getPopularTitles:
                return Object.assign({}, state, { popularTitles: action.popularTitles });
            case currentComponent:
                return Object.assign({}, state, { currentComponent: action.currentComponent });
            default:
                return state;
        }
    }

    let dispatch = action => {
        currentState = reducer(currentState, action);

        subscribers.forEach(callback => callback());
    }


    let actions = {
        getPopularTitles: titles => ({ type: getPopularTitles, popularTitles: titles }),
        currentComponent: name => ({ type: currentComponent, currentComponent: name })

    };

    return {
        getState,
        dispatch,
        subscribe,
        actions
    }

});