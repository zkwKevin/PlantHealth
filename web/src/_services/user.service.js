import config from 'config';
import { authHeader } from '../_helpers';

export const userService = {
    login,
    logout,
    register,
    getAllTarget
};

function login(username, password) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json'},
        body: JSON.stringify({username, password})
    }

    return fetch('https://localhost:5001/api/user/authenticate', requestOptions)
        .then(handleResponse)
        .then(user => {
            localStorage.setItem('user', JSON.stringify(user));
            return user;
        });
}

function logout(){
    localStorage.removeItem('user')
}

function getAllTarget(id){
    const requestOptions = {
        method: 'GET',
        headers: authHeader(),
    }

    return fetch('https://localhost:5001/api/targetItems/${id}', requestOptions)
        .then(handleResponse);
}

function register(user) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json'},
        body: JSON.stringify(user)
    }

    return fetch('https://localhost:5001/api/user/register', requestOptions)
        .then(handleResponse);
}

function handleResponse(response) {
    if (!response.ok) {
        if (response.status === 401) {
            // auto logout if 401 response returned from api
            logout();
            location.reload(true);
        }
        return response.json()
            .catch(() => {
                // Couldn't parse the JSON
                throw new Error(response.status);
            })
            .then(({message}) => {
                // Got valid JSON with error response, use it
                throw new Error(message || response.status);
            });
    }
    return response.json();      
}

