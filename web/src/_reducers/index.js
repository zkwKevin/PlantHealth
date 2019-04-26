import { combineReducers } from 'redux';

import { authentication } from './authentication.reducer';
import { registration } from './registration.reducer';
import { target } from './target.reducer';
import { alert } from './alert.reducer';
import {style} from './style.reducer';

const rootReducer = combineReducers({
    authentication,
    registration,
    alert,
    style,
    target
  });
  
  export default rootReducer;