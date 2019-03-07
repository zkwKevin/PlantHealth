// make http request to api using JWT

export function authHeader(){
    let user = JSON.parse(localStorage.getItem('user'));

    if(user && user.token){
        return {'Authorization': 'Bearer' + user.token };
    } else {
        return {};
    }
}