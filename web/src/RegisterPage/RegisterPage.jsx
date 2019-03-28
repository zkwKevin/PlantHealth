import React, { Component } from 'react';
import { connect} from 'react-redux';
import { userActions } from '../_actions/user.actions'
import Link from 'react-router-dom/Link';


class LoginPage extends Component{
	constructor(props){
        super(props);

        this.state = {
            user: {
                username: '',
                password: '',
                email: '',
            },    
            submitted: false
        };
    }

    handleOnchange(e) {
        const { name, value} = e.target;
        const {user} = this.state;
        this.setState({
            user: {
                ...user,
                [name] : value
            }
        });
    }

    handleSubmit(e) {
        e.preventDefault();

        this.setState( {submitted: true});
        const { user } = this.state;
        const { dispatch } = this.props;
        
        if( user.username && user.password && user.email){
            dispatch(userActions.register(user));
        }
    }

    render() {
        const { user, submitted } = this.state;
        const { registering } = this.props;
        return(
            <div>
                <h1>Register</h1>
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
                        { submitted && !user.password && 
                            <div className="help-block">Password is required</div>
                        }
                    </div>
                    <div className={'form-group' + ( submitted && !user.email ? 'has-error':'' )}>
                        <label htmlFor="password">Email</label>
                        <input type="text" className="form-control" name="password" value={user.email} onChange={(e) => this.handleOnchange(e)}/>
                        { submitted && !user.email && 
                            <div className="help-block">Email is required</div>
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
        );
    }
}

function mapStateToProps(state) {
	const { registration } = state;
	const { registering } = registration;
	return {
		registering
	};
}

const connectedRegisterPage = connect(mapStateToProps)(RegisterPage);
export { connectedRegisterPage as RegisterPage };
