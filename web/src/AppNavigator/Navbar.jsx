import React, {Component} from 'react';
import './Navbar.css';
import {DropDown} from './DropDown';
import { connect } from 'react-redux';


class NavBar extends Component {
    constructor(){
        super();
        this.state = {
            Droplists: [
                {
                    id: 0,
                    title: 'Settings',
                    link: "#settings"
                },
                {
                    id: 1,
                    title: 'Log Out',
                    link: "/login"
                }
            ]
        } 
    }

    render(){
        const {loggedIn, links} = this.props;
        let linksMarkUp = links.map((link, index) => {
            let linkMarkUp = link.active?(
                <a className="menu__link menu__link--active" href={link.link} >{link.label}</a>
            ):(
                <a className="menu__link" href={link.link} >{link.label}</a>
            );

            return (
                <li key={index} className="menu__list-item">
                    {linkMarkUp}
                </li>
            );
        })

        const { Droplists } = this.state;
        return(
            <nav className="menu">
                <div className="menu__right">
                    <ul className="menu__list">
                        {linksMarkUp}
                    </ul>
                {loggedIn && <DropDown Droplists={Droplists}/>}
                </div>
            </nav>
        );
    }
}

function mapStateToProps(state) {
    const { authentication} = state;
    const { loggedIn } = authentication;
    return { loggedIn};
};

const connectedNavBar = connect(mapStateToProps)(NavBar);
export  { connectedNavBar as  NavBar };
// export { NavBar };


