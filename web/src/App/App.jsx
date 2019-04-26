import React from 'react';
import { Router, Route } from 'react-router-dom';
import { connect } from 'react-redux';

import { history } from '../_helpers/history';
import { alertActions } from '../_actions/alert.actions';
import { styleActions } from '../_actions/alert.actions';
import { PrivateRoute } from '../_components/PrivateRoute';
import { HomePage } from '../HomePage/HomePage';
import { AnimalPage } from  '../AnimalPage/AnimalPage';
import { LoginPage } from '../LoginPage/LoginPage';
import { SettingPage } from '../SettingPage/SettingPage'
import { RegisterPage } from '../RegisterPage/RegisterPage';
import { NavBar } from '../AppNavigator/Navbar';
import { library } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faAngleDown, faAngleUp } from '@fortawesome/free-solid-svg-icons';


library.add(faAngleDown, faAngleUp);

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
        if( styleChanged == "home")
                links =
                [
                    { label:"Home", link: "/", active: true},
                    { label:"Animal", link: "/animal"},
                    { label:"Plant", link: "#plant"},
                    { label:"ScheduleTable", link: "#scheduleTable"},
                ]
       
            else if(styleChanged == "animal")
                links =
                [
                    { label:"Home", link: "/"},
                    { label:"Animal", link: "/animal", active: true},
                    { label:"Plant", link: "#plant"},
                    { label:"ScheduleTable", link: "#scheduleTable"},
                ]

                else if(styleChanged == "plant")
                links =
                [
                    { label:"Home", link: "/"},
                    { label:"Animal", link: "/animal"},
                    { label:"Plant", link: "#plant", active: true},
                    { label:"ScheduleTable", link: "#scheduleTable"},
                ]
                    else if(styleChanged == "timetable")
                    links =
                    [
                        { label:"Home", link: "/"},
                        { label:"Animal", link: "/animal"},
                        { label:"Plant", link: "#plant"},
                        { label:"ScheduleTable", link: "#scheduleTable", active: true},
                    ]
                    
                        else if( !loggedIn && styleChanged == "register")
                            links =
                            [
                                { label:"Signin", link: "/login"},
                                { label:"Signup", link: "/register", active: true},
                            ]

                            else if( !loggedIn && styleChanged == "register")
                            links =
                            [
                                { label:"Signin", link: "/login", active: true},
                                { label:"Signup", link: "/register"}
                            ] 
                                else 
                                    links =
                                    [
                                        { label:"Home", link: "/"},
                                        { label:"Animal", link: "/animal"},
                                        { label:"Plant", link: "#plant"},
                                        { label:"ScheduleTable", link: "#scheduleTable"},
                                    ]   

        
       
        return (
            <div className="sea">
                <div className="land">
                    <div className="container center">
                        <NavBar links = {links} />
                    </div >
                        <div className="col-sm-8 col-sm-offset-2">
                            {alert.message &&
                                <div className='alert ${alert.type}'>{alert.message}</div>
                            }
                            <Router history={history}>
                                <div>
                                    <PrivateRoute exact path="/" component={HomePage} />
                                    <PrivateRoute exact path="/animal" component={AnimalPage}/>
                                    {/* <PrivateRoute path="/plant" component={PlantPage}/>
                                    <PrivateRoute path="/TimeTable" component={TimetablePage}/> */}
                                    <PrivateRoute exact path="/setting" component={SettingPage}/>
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
