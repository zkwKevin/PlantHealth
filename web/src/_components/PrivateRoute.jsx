import React, { Component } from 'react';
import {Route, Redirect} from 'react-router-dom';

//Param means rename Homepage to Component
export const PrivateRoute = ({component: Component, ...rest}) => {
//Create the components element:
    <Route {...rest} render = {props => (
        localStorage.getItem(user)
            ? <Component {...props} />
            : <Redirect 
                to={{
                    pathname: "/login",
                    state: { from: props.location }
                }}
              />
    )} />
}