import {createStore, applyMiddleware} from 'redux';
import thunk from 'redux-thunk';
import { createLogger } from 'redux-logger';
import rootReducer from '../_reducers';

const logger = createLogger();
//middleware is used to change store.dispatch()
const store = createStore(
    reducer,
    applyMiddleware(
        logger,
        thunk
    )
);