export const BirthArray = {
    dateArray,
    monthArray
};
function dateArray(start,end)
{
    let dateOptions = [];
    for(let i = start; i< end; i++){
        dateOptions.push({key:i, text:i, value:i});
    }
    return dateOptions;
}

function monthArray(monthNameList)
{
    let dateOptions = [];
    for(let i = 0; i< monthNameList.length; i++){
        dateOptions.push({key:monthNameList[i], text:monthNameList[i], value:monthNameList[i]});
    }
    return dateOptions;
}




