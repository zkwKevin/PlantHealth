import {targetConstants} from '../_constants/target.constants';

export function target (state ={}, action ){
    switch (action.type) {
        case targetConstants.GETALL_ANIMAL_REQUEST:
            return {
                loading: true
            };
        case targetConstants.GETALL_ANIMAL_SUCCESS:
            return {
                animals: action.animals
            };
        case targetConstants.GETALL_ANIMAL_FAILURE:
            return { 
                error: action.error
            };
        default:
            return state
    }
}