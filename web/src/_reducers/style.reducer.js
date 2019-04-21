

export function style (state ={}, action ){
    switch (action.type) {
        case "SetRegister" :
            return {
                styleChanged: true,
            };
        case "SetLogin" :
            return {
                styleChanged: false,
            };
        default:
            return state
    }
}