define([], () => {

    const getPopularTitles = "GET_POPULAR_TITLES";
    const getPopularShows = "GET_POPULAR_SHOWS";
    const populateSearchResult = "populateSearchResult";
    const populateTitle = "populateTitle";
    const populateToken = "populateToken";
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
            case getPopularShows:
                return Object.assign({}, state, { popularShows: action.popularShows });
            case populateSearchResult:
                return Object.assign({}, state, { searchResult: action.searchResult });
            case populateTitle:
                return Object.assign({}, state, { title: action.title });
            case populateToken:
                return Object.assign({}, state, { token: action.token });
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
        getPopularShows: shows => ({ type: getPopularShows, popularShows: shows }),
        populateSearchResult: searchResult => ({ type: populateSearchResult, searchResult }),
        populateTitle: title => ({ type: populateTitle, title }),
        populateToken: token => ({ type: populateToken, token }),
        currentComponent: name => ({ type: currentComponent, currentComponent: name })
    };

    return {
        getState,
        dispatch,
        subscribe,
        actions
    }

});