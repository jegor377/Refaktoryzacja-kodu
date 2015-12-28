function setCodedValues(valuesToSet) //where, what, toWhat
{
    if(isArray(valuesToSet)) {
        for(var value in valuesToSet) {
            setCodedValue(valuesToSet[value]);
        }
    }
    else {
        setCodedValue(valuesToSet);
    }
}

function setCodedValue(valueToSet)
{
    if(isArray(valueToSet.where)) {
        for(item in valueToSet.where)
        {
            setOneCodedValue({
                where: valueToSet.where[item],
                what: valueToSet.what,
                toWhat: valueToSet.toWhat
            });
        }
    }
    else {
        setOneCodedValue(valueToSet);
    }
}

function setOneCodedValue(valueToSet)
{
    oldValue = $(valueToSet.where).html();
    newValue = oldValue.replace('{{' + valueToSet.what + '}}', valueToSet.toWhat);
    $(valueToSet.where).html(newValue);
}

function isArray(obj)
{
    return Object.prototype.toString.call( obj ) === '[object Array]';
}