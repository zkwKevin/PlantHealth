import { combineReducers } from 'redux';

import { authentication } from './authentication.reducer';
import { registration } from './registration.reducer';
import { items } from './items.reducer';
import { alert } from './alert.reducer';
import {style} from './style.reducer';

const rootReducer = combineReducers({
    authentication,
    registration,
    items,
    alert,
    style,
  });
  
  export default rootReducer;