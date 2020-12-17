define([], () => {

    const getPopularTitles = "GET_POPULAR_TITLES";
    const getPopularShows = "GET_POPULAR_SHOWS";
    const populateSearchResult = "populateSearchResult";
    const populateTitle = "populateTitle";
    const populateCastInfo = "populateCastInfo";
    const populateToken = "populateToken";
    const populateUser= "populateUser";
    const populateSimilarTitles = "populateSimilarTitles";
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
            case populateCastInfo:
                return Object.assign({}, state, { castinfo: action.castinfo });
            case populateToken:
                return Object.assign({}, state, { token: action.token });
            case populateSimilarTitles:
                return Object.assign({}, state, { similarTitles: action.titles });
            case populateUser:
                return Object.assign({}, state, { user: action.user});
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
        populateCastInfo: castinfo => ({ type: populateCastInfo, castinfo }),
        populateToken: token => ({ type: populateToken, token }),
        populateUser: user => ({ type: populateUser, user }),
        populateSimilarTitles: titles => ({ type: populateSimilarTitles, titles }),
        currentComponent: name => ({ type: currentComponent, currentComponent: name })
    };

    return {
        getState,
        dispatch,
        subscribe,
        actions
    }

});