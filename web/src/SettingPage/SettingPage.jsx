import React, { Component } from 'react';
import { connect} from 'react-redux';
import { userActions } from '../_actions/user.actions'
import { Link } from 'react-router-dom';

class SettingPage extends Component{
	
	render(){
		<div>
		<h1>Setting</h1>
		<form name="form" onSubmit={(e) => this.handleSubmit(e)}>
			<div className={'form-group' + ( submitted && !user.username ? 'has-error':'' )}>
				<label htmlFor="username">Username</label>
				<input type="text" className="form-control" name="username" value={user.username} onChange={(e) => this.handleOnchange(e)}/>
				{ submitted && !user.username && 
					<div className="help-block">Username is required</div>
				}
			</div>
			<div className={'form-group' + ( submitted && !user.password ? 'has-error':'' )}>
				<label htmlFor="password">Password</label>
				<input type="text" className="form-control" name="password" value={user.password} onChange={(e) => this.handleOnchange(e)}/>
				{
					notify1
				}
			</div>
			<div className={'form-group' + ( submitted && !user.email ? 'has-error':'' )}>
				<label htmlFor="email">Email</label>
				<input type="text" className="form-control" name="email" value={user.email} onChange={(e) => this.handleOnchange(e)}/>
				{
					notify2
				}
			</div>
			<div className="form-group">
				<button className="btn btn-primary">Register</button>
				{registering && 
					<img src="data:image/gif;base64,R0lGODlhEAAQAPIAAP///wAAAMLCwkJCQgAAAGJiYoKCgpKSkiH/C05FVFNDQVBFMi4wAwEAAAAh/hpDcmVhdGVkIHdpdGggYWpheGxvYWQuaW5mbwAh+QQJCgAAACwAAAAAEAAQAAADMwi63P4wyklrE2MIOggZnAdOmGYJRbExwroUmcG2LmDEwnHQLVsYOd2mBzkYDAdKa+dIAAAh+QQJCgAAACwAAAAAEAAQAAADNAi63P5OjCEgG4QMu7DmikRxQlFUYDEZIGBMRVsaqHwctXXf7WEYB4Ag1xjihkMZsiUkKhIAIfkECQoAAAAsAAAAABAAEAAAAzYIujIjK8pByJDMlFYvBoVjHA70GU7xSUJhmKtwHPAKzLO9HMaoKwJZ7Rf8AYPDDzKpZBqfvwQAIfkECQoAAAAsAAAAABAAEAAAAzMIumIlK8oyhpHsnFZfhYumCYUhDAQxRIdhHBGqRoKw0R8DYlJd8z0fMDgsGo/IpHI5TAAAIfkECQoAAAAsAAAAABAAEAAAAzIIunInK0rnZBTwGPNMgQwmdsNgXGJUlIWEuR5oWUIpz8pAEAMe6TwfwyYsGo/IpFKSAAAh+QQJCgAAACwAAAAAEAAQAAADMwi6IMKQORfjdOe82p4wGccc4CEuQradylesojEMBgsUc2G7sDX3lQGBMLAJibufbSlKAAAh+QQJCgAAACwAAAAAEAAQAAADMgi63P7wCRHZnFVdmgHu2nFwlWCI3WGc3TSWhUFGxTAUkGCbtgENBMJAEJsxgMLWzpEAACH5BAkKAAAALAAAAAAQABAAAAMyCLrc/jDKSatlQtScKdceCAjDII7HcQ4EMTCpyrCuUBjCYRgHVtqlAiB1YhiCnlsRkAAAOwAAAAAAAAAAAA==" />
				}
				<Link to="/login">Cancel</Link>
			</div>
		</form>
	</div>
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
