import React from 'react';
import { Router, Route } from 'react-router-dom';
import { connect } from 'react-redux';

import { history } from '../_helpers/history';
import { alertActions } from '../_actions/alert.actions';
import { styleActions } from '../_actions/alert.actions';
import { PrivateRoute } from '../_components/PrivateRoute';
import { HomePage } from '../HomePage/HomePage';
import { LoginPage } from '../LoginPage/LoginPage';
import { RegisterPage } from '../RegisterPage/RegisterPage';
import { NavBar } from '../AppNavigator/Navbar';
// import logo from '../Img/logo.jpg';

class App extends React.Component {
    constructor(props) {
        super(props);
        //initial alert state equals to null
        const { dispatch } = this.props;
        history.listen((loaction, action) => {
            dispatch(alertActions.clear());
        });
    }

    render() {
      
        const { styleChanged, alert, loggedIn } = this.props;
        let links;
        if(loggedIn)
            links =
            [
                { label:"Animal", link: "#animal", active: true},
                { label:"Plant", link: "#plant"},
                { label:"ScheduleTable", link: "#scheduleTable"},
            ]
        else if ( !loggedIn && styleChanged)
            links =
            [
                { label:"Signin", link: "/login"},
                { label:"Signup", link: "/register", active: true},
            ] 
            else 
                links =
                [
                    { label:"Signin", link: "/login", active: true},
                    { label:"Signup", link: "/register"},
                ]

        return (
            <div className="sea">
                <div className="land">
                    <div className="container center">
                        <NavBar links = {links} />
                    </div >
                        <div className="col-sm-8 col-sm-offset-2">
                            {/* {alert.message &&
                                <div className='alert ${alert.type}'>{alert.message}</div>
                            } */}
                            <Router history={history}>
                                <div>
                                    <PrivateRoute exact path="/" component={HomePage} />
                                    <Route path="/login" component={LoginPage}/>
                                    <Route path="/register" component={RegisterPage}/>
                                </div>
                            </Router>
                        </div>
                </div>
            </div>
        );
    }
}


function mapStateToProps(state) {
    const { alert, authentication, style} = state;
    const { styleChanged } = style;
    const { loggedIn } = authentication;
    return { alert, loggedIn, styleChanged};
};




const connectedApp = connect(mapStateToProps)(App);
export  { connectedApp as App };
