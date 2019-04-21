import React, { Component } from 'react';
import { connect} from 'react-redux';
import { userActions } from '../_actions/user.actions'
import { Link } from 'react-router-dom';

class HomePage extends Component{
	
	render(){
		const { user} = this.props;
		

		return(
			
			<div className="col-me-6 col-md-offset-3">
				<h1>Welcome {user.username}!</h1>
				{/* add button to switch to Live mode */}
				<h3>All target items:</h3> 
				
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

const connectedHomePage = connect(mapStateToProps)(HomePage);
export { connectedHomePage as HomePage };
