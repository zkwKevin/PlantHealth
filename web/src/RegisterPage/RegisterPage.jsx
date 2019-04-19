import React, { Component } from 'react';
import { connect} from 'react-redux';
import { userActions } from '../_actions/user.actions'
import Link from 'react-router-dom/Link';


class RegisterPage extends Component{
	constructor(props){
        super(props);

        this.state = {
            user: {
                name: "",
                password: "",
                email: "",
            },  
            emailValid: false,
            passwordValid: false,  
            submitted: false
        };
    }

    handleOnchange(e) {
        const { name, value} = e.target;
        const {user} = this.state;
        this.setState(
            {
                user: {
                ...user,
                [name] : value
                }
            },
            () => {this.validateField(name, value)}
        );
    }

    validateField(fieldName, value) {
        let {emailValid,passwordValid} = this.state;
       
        switch(fieldName) {
            case 'email':
              emailValid = value.match(/^([\w.%+-]+)@([\w-]+\.)+([\w]{2,})$/i);
              break;
            case 'password':
              passwordValid = value.length >= 6;
              break;
            default:
              break;
          }
          this.setState(
              {
                emailValid: emailValid,
                passwordValid: passwordValid
              });
    }

    handleSubmit(e) {
        e.preventDefault();

        this.setState( {submitted: true});
        const { user, emailValid, passwordValid} = this.state;
        const { dispatch } = this.props;
        
        if( user.name && user.password && user.email && passwordValid && emailValid){
            dispatch(userActions.register(user));
        }
    }

    render() {
        const { user, submitted, emailValid, passwordValid } = this.state;
        const { registering } = this.props;
        let notify1, notify2;
        if(submitted && !user.password)
            notify1 = <div className="help-block">Password is required</div>;
        else if(submitted && !passwordValid)
            notify1 = <div className="help-block">Password is too short</div>;

        if(submitted && !user.email)
            notify2 = <div className="help-block">Email is required</div>;
        else if(submitted && !emailValid)
            notify2 = <div className="help-block">Email type is wrong</div>;
        // if(!passwordValid)
        //     notify1 = <div className="help-block">Password is too short</div>
        return(
            <div>
                <h1>Register</h1>
                <form name="form" onSubmit={(e) => this.handleSubmit(e)}>
                    <div className={'form-group' + ( submitted && !user.name ? 'has-error':'' )}>
                        <label htmlFor="name">Username</label>
                        <input type="text" className="form-control" name="name" value={user.rname} onChange={(e) => this.handleOnchange(e)}/>
                        { submitted && !user.name && 
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
