
export const styleActions = {
    changeLinkStyleToRegister,
    changeLinkStyleToLogin,
    changeLinkStyleToAnimal,
    changeLinkStyleToPlant,
    changeLinkStyleToTimeTable,
    changeLinkStyleToHome,
    
};

function changeLinkStyleToRegister (){
    return {
        type: "SetRegister"      
    };
}


function changeLinkStyleToLogin (){
    return {
        type: "SetLogin"      
    };
}

function changeLinkStyleToAnimal (){
    return {
        type: "SetAnimal"      
    };
}

function changeLinkStyleToPlant (){
    return {
        type: "SetPlant"      
    };
}

function changeLinkStyleToTimeTable (){
    return {
        type: "SetTimeTable"      
    };
}

function changeLinkStyleToHome (){
    return {
        type: "SetHome"      
    };
}
