import React, { Component } from 'react';
import { connect} from 'react-redux';
import { userActions } from '../_actions/user.actions'
import { Link } from 'react-router-dom';

class SettingPage extends Component{
	
	render(){
		return (
		<div>
		<h1>Setting</h1>
		</div>
		)
	}
}

function mapStateToProps(state) {
	const { authentication} = state;
	const { user } = authentication;
	return {
		user,
	};
}

const connectedSettingPage = connect(mapStateToProps)(SettingPage);
export { connectedSettingPage as SettingPage };
