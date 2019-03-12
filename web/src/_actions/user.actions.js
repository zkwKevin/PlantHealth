import {alertActions} from './';
import {userConstants} from '../_constants';
import {userService} from '../_services';
import {history} from '../_helpers';

export const userActions = {
    login,
    logout,
    register,
    getAll,
}; 

function login (username, password){
    return dispatch => {
        dispatch(request(username));

        userService.login(username, password)
            .then(
                user => {
                    dispatch(success(user));
                    history.push('/');
                },
                error => {
                    dispatch(failure(error.toString()));
                    dispatch(alertActions.error(error.toString()));
                }                
            );
    };

    function request(user){
        return { type: userConstants.LOGIN_REQUEST, user}
    }
    function success(user){
        return { type: userConstants.LOGIN_SUCCESS, user}
    }
    function failure(error){
        return { type: userConstants.LOGIN_FAILURE, error}
    }
}

function logout(){
    userService.logout();
    return { type:userConstants.LOGOUT};
}

function register(user) {
    return dispatch => {
        dispatch(request(user));

        userService.register(user)
            .then(
                user => {
                    dispatch(success(user));
                    history.push('/login');
                    dispatch(alertActions.success('Registration successful'));
                },
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.failure(error.toString()));
                }
            )
    };
    function request(user){
        return { type: userConstants.REGISTER_REQUEST, user}
    }
    function success(user){
        return { type: userConstants.REGISTER_SUCCESS, user}
    }
    function failure(error){
        return { type: userConstants.REGISTER_FAILURE, error}
    }

function getAllTarget(id){
    return dispatch => {
        dispatch(request(id));

        userService.getAll(id)
            .then(
                items => dispatch(success(items)),
                error => dispatch(failure(error.toString()))
            )
    }

    function request(id){
        return { type: userConstants.GETALL_REQUEST}
    }
    function success(items){
        return { type: userConstants.GETALL_SUCCESS, items}
    }
    function failure(error){
        return { type: userConstants.GETALL_FAILURE, error}
    }
}

}



