import React, { Component } from 'react'
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import App from './App'
import Home from './Home'
import ShowTarget from './TargetItemList'
import AddTarget from './AddTargetPage'

class RouterMap extends Component {
    render() {
        return (
            <BrowserRouter>
                <Switch>
                    <Route exact path={'/'} component={Home}/>
                    <Route exact path={'/addTarget'} component={AddTarget}/>
                    <Route exact path={'/target/:id'} component={ShowTarget}/>
                </Switch>
            </BrowserRouter>
        );
    }
}

export default RouterMap;