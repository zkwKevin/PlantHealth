

export function style (state ={}, action ){
    switch (action.type) {
        case "SetRegister" :
            return {
                styleChanged: "register",
            };
        case "SetLogin" :
            return {
                styleChanged: "login",
            };
        case "SetAnimal" :
            return {
                styleChanged: "animal",
        };
        case "SetPlant" :
            return {
                styleChanged: "plant",
        };
        case "SetTimeTable" :
            return {
                styleChanged: "timetable",
        };
        case "SetHome" :
            return {
                styleChanged: "home",
        };
        default:
            return state
    }
}