import React from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';

import { store } from './_helpers/store';
import { App } from './App/App';
import "./index.css";
import 'semantic-ui-css/semantic.min.css';


// setup fake backend
// import { configureFakeBackend } from './_helpers/fake-backend';
// configureFakeBackend();

render(
    <Provider store={store}>
        <App />
    </Provider>,
    document.getElementById('app')
);