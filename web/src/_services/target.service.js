import config from 'config';
import { authHeader } from '../_helpers/auth-header';

export const targetService = {
    getAnimalList,
  
};

function getAnimalList(id) {
    const requestOptions = {
        method: 'GET',
        headers: authHeader()
    };
    //return fetch('https://localhost:5001/api/targetItems/' + id, requestOptions).then(handleResponse);
    return fetch('https://localhost:5001/api/targetItems/' + id, requestOptions)
    .then(response => response.text()
        .then(text => {return text && JSON.parse(text)})
        .catch( () => 
            { 
                if (response.status === 401) {
                    // auto logout if 401 response returned from api
                    logout();
                    location.reload(true);
                }
                const error = (data && data.message) || response.statusText;
                return error;
            }
        )
    )
}

// function handleResponse(response) {
//     return response.text().then(text => {
//         const data = text && JSON.parse(text);
//         if (response.ok)
//         {
//             return data;
//         }
//         else {
//             if (response.status === 401) {
//                 // auto logout if 401 response returned from api
//                 logout();
//                 location.reload(true);
//             }
//             const error = (data && data.message) || response.statusText;
//             return Promise.reject(error);
//         }    
//     });
// }