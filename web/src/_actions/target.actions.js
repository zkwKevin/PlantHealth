import {alertActions} from './alert.actions';
import {targetConstants} from '../_constants/target.constants';
import {targetService} from '../_services/target.service';
import {history} from '../_helpers/history';

export const targetActions = {
    getAnimalList,
}; 

function getAnimalList (id){
    return dispatch => {
        dispatch(request());

        targetService.getAnimalList(id)
            .then(
                animals => {
                    dispatch(success(animals));
                },
                error => {
                    dispatch(failure(error.toString()));
                }                
            );
    };

    function request(){
        return { type: targetConstants.GETALL_ANIMAL_REQUEST}
    }
    function success(animals){
        return { type: targetConstants.GETALL_ANIMAL_SUCCESS, animals}
    }
    function failure(error){
        return { type: targetConstants.GETALL_ANIMAL_FAILURE, error}
    }
}
