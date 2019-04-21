
export const styleActions = {
    changeLinkStyleToRegister,
    changeLinkStyleToLogin
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
