import React, { Component } from 'react';
import { connect} from 'react-redux';
import { userActions } from '../_actions/user.actions';
import { styleActions } from '../_actions/style.actions';
import { Link } from 'react-router-dom';

class AnimalPage extends Component{
	constructor(props){
		super(props);
		this.props.dispatch(styleActions.changeLinkStyleToAnimal());
	}
	
	render(){
		
		return(
			
			<div className="col-me-6 col-md-offset-3">
				<h1>Animal</h1>
				{/* add button to switch to Live mode */}
				
				<p>
					<Link to="/login">Logout</Link>
				</p>
			</div>
		);
	}
}

function mapStateToProps(state) {
	const { authentication} = state;
	const { user } = authentication;
	return {
		user,
	};
}

const connectedAnimalPage = connect(mapStateToProps)(AnimalPage);
export { connectedAnimalPage as AnimalPage };
