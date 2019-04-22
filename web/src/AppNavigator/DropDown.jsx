import React, {Component} from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import userIcon from '../Img/userIcon.png';
import './Navbar.css';
import './DropDown.css';

class DropDown extends Component {
    constructor(){
        super();
        this.state = (
            {
                listOpen:false
            }
        )
     
    }

    toggleList(){
        const{listOpen} = this.state;
        this.setState({listOpen:!listOpen});
    }



    render(){
        const { listOpen } = this.state;
        let dropDownList = this.props.Droplists.map((item) => {
            return(
                <li className="dropdown-list-item" key={item.id} >
                    <a className="dropdown-list-item" href={item.link} >{item.title}</a>
                </li>
            );
        })
        return(
            <div className="dropdown-wrapper">
                 <div className="dropdown-header" onClick={() => this.toggleList()}>
                    <img src={userIcon} className= "menu__userIcon"/>
                    {listOpen
                    ? <FontAwesomeIcon icon="angle-up"  />
                    : <FontAwesomeIcon icon="angle-down"/>
                    }
            </div>
                
                    {
                        listOpen && 
                        <div className="dp">
                            <div className="arrow-up"/>
                            <ul className="dropdown-list">
                                { dropDownList }
                            </ul>
                        </div>
                    }
            </div>
        );
    }
}

export { DropDown };


