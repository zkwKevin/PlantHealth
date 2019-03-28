import {userConstants} from '../_constants/user.constants';

export function items (state ={}, action ){
    switch (action.type) {
        case userConstants.GETALL_REQUEST:
            return {
                loading: true
            };
        case userConstants.GETALL_SUCCESS:
            return {
                items: action.items
            };
        case userConstants.GETALL_FAILURE:
            return { 
                error: action.error
            };
        default:
            return state
    }
}