import React, { Component } from 'react';
import { connect} from 'react-redux';
import { userActions } from '../_actions/user.actions'
import { Link } from 'react-router-dom';

class HomePage extends Component{
	componentDidMount() {
		this.props.dispatch(userActions.getAllTarget(user.Id))
	}
	render(){
		const { user, items} = this.props;
		return(
			<div className="col-me-6 col-md-offset-3">
				<div>Welcome {user.Name}!</div>
				{/* add button to switch to Live mode */}
				<h3>All target items:</h3> 
				{items.loading && <em>Loading items...</em>}
				{items && 
					<ul>
						{items.map((item, index) =>
							<li key={item.Id}>
								{item.Name + "("+ item.Type + ")"}
								{/* delete */}
								{/* details */}
							</li>
						)}
					</ul>
				}
				<p>
					<Link to="/login">Logout</Link>
				</p>
			</div>
		);
	}
}

function mapStateToProps(state) {
	const { authentication, items} = state;
	const { user } = authentication;
	return {
		user,
		items
	};
}

const connectedHomePage = connect(mapStateToProps)(HomePage);
export { connectedHomePage as HomePage };
