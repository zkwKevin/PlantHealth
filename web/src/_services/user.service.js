import config from 'config';
import { authHeader } from '../_helpers/auth-header';

export const userService = {
    login,
    logout,
    register,
    getById,
  
};

function login(username, password) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password })
    };

    return fetch('https://localhost:5001/api/user/authenticate', requestOptions)
            .then(response =>  response.json())
            .then(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('user', JSON.stringify(user));
                user;
            })
            .catch(error => console.log(error));
}

function logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('user');
}

// function getAll() {
//     const requestOptions = {
//         method: 'GET',
//         headers: authHeader()
//     };

//     return fetch(`${config.apiUrl}/users`, requestOptions).then(handleResponse);
// }

function getById(id) {
    const requestOptions = {
        method: 'GET',
        headers: authHeader()
    };

    return fetch('https://localhost:5001/api/user/${id}', requestOptions)
            .then(
                response => {
                    if (!response.ok) {
                        if (response.status === 401) {
                            // auto logout if 401 response returned from api
                            logout();
                            location.reload(true);
                        }
                    }
                    response.json();
                }
            )
            .then(user => {
                return user;
            })
            .catch(error => console.log(error));
}

function register(user) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(user)
    };

    return fetch('https://localhost:5001/api/user/register', requestOptions)
        .then(handleResponse)
                  
};

function update(user) {
    const requestOptions = {
        method: 'PUT',
        headers: { ...authHeader(), 'Content-Type': 'application/json' },
        body: JSON.stringify(user)
    };

    return fetch(`${config.apiUrl}/users/${user.id}`, requestOptions).then(handleResponse);
}

// prefixed function name with underscore because delete is a reserved word in javascript

function handleResponse(response) {
    return response.text().then(text => {
        const data = text && JSON.parse(text);
        if (response.ok)
        {
            return data;
        }
        else {
            if (response.status === 401) {
                // auto logout if 401 response returned from api
                logout();
                location.reload(true);
            }
            const error = (data && data.message) || response.statusText;
            return Promise.reject(error);
        }    
    });
}