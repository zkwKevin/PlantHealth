import React, {Component} from 'react';
import './Navbar.css';

class NavBar extends Component {
    constructor(){
        super();
     
    }

    render(){
        let linksMarkUp = this.props.links.map(((link, index) => {
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
        }))
        return(
            <nav className="menu">
                <div className="menu_right">
                    <ul className="menu_right">
                        {linksMarkUp}
                    </ul>
                </div>
            </nav>
        );
    }
}

export { NavBar };


