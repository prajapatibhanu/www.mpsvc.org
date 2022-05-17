function RemoveExtraChars(value) {
    var iCount; var returnVal = "";
    for (iCount = 0; iCount < value.length; iCount++) { if (!isNaN(value.charAt(iCount)) && value.charAt(iCount) != " ") returnVal = returnVal + value.charAt(iCount); }
    return returnVal;
}
function fnCheckForReturnKey(cntrl, e) { if (!e) e = window.event; if (e.keyCode == 13) cntrl.click(); }

function fnSetMaxLength(obj, maxlength) { var mlength = maxlength; if (obj.getAttribute && obj.value.length > mlength) obj.value = obj.value.substring(0, mlength); }

//Only Numeric    onkeypress='javascript:tbx_fnNumeric(event, this);'
function tbx_fnNumeric(e, ctrl) {
    if (!e) e = window.event;
    if (e.charCode) {
        if (e.charCode < 48 || e.charCode > 57) {
            if (e.charCode != 46 || ctrl.value.indexOf('.') >= 0) {
                if (e.preventDefault) { e.preventDefault(); }
            }
        }
    }
    else if (e.keyCode) {
        if (e.keyCode < 48 || e.keyCode > 57) {
            if (e.keyCode != 46 || ctrl.value.indexOf('.') >= 0) {
                try {
                    e.keyCode = 0;
                }
                catch (e)
                { }
            }
        }
    }
}

//Only Numeric    onblur='javascript:tbx_fnNumericOnBlur(this);'
function tbx_fnNumericOnBlur(ctrl) {
    var text = ctrl.value;
    var iCount = 0;
    var bInvalid = 0;
    var returnStr = '';
    if (text == '')
        return;
    for (iCount = 0; iCount < text.length; iCount++) {
        if ((text.charCodeAt(iCount) < 48 || text.charCodeAt(iCount) > 57) && (text.charCodeAt(iCount) != 46 || iCount != ctrl.value.indexOf('.'))) {
            bInvalid = 1;
        }
        else {
            returnStr = returnStr.toString() + text.charAt(iCount).toString();
        }
    }
    //ctrl.value=returnStr;
    var num = returnStr.toString().replace(/\$|\,/g, '');
    num = num.toString().replace("$", "").Replace(",", "").Trim();
    if (isNaN(num)) num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10) cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + ',' + num.substring(num.length - (4 * i + 3));
    ctrl.value = (((sign) ? '' : '-') + num + '.' + cents);

    //if(bInvalid==1) fnShowAlert('Invalid characters will be ignored', ctrl);
}


// ************** //
//Only Integer    onkeypress='javascript:tbx_fnInteger(event, this);'
function tbx_fnInteger(e, ctrl) {
    if (!e) e = window.event;
    if (e.charCode) {
        if (e.charCode < 48 || e.charCode > 57) {
            if (e.preventDefault) { e.preventDefault(); }
        }
    }
    else if (e.keyCode) {
        if (e.keyCode < 48 || e.keyCode > 57) {
            try { e.keyCode = 0; } catch (e) { }
        }
    }
}
//Only Integer    onkeypress='javascript:tbx_fnIntegerOneOrTwo(event, this);'
function tbx_fnIntegerOneOrTwo(e, ctrl) {
    if (!e) e = window.event;
    if (e.charCode) {

        if (e.charCode == 49 || e.charCode == 50) {

        }
        else {
            if (e.preventDefault) { e.preventDefault(); }
        }

    }
    else if (e.keyCode) {
        if (e.keyCode < 48 || e.keyCode > 57) {
            try { e.keyCode = 0; } catch (e) { }
        }
    }
}

function tbx_fnIntegerZeroOneOrTwo(e, ctrl) {
    if (!e) e = window.event;
    if (e.charCode) {

        if (e.charCode == 48 || e.charCode == 49 || e.charCode == 50) {

        }
        else {
            if (e.preventDefault) { e.preventDefault(); }
        }

    }
    else if (e.keyCode) {
        if (e.keyCode < 48 || e.keyCode > 57) {
            try { e.keyCode = 0; } catch (e) { }
        }
    }
}
//Only Integer    onkeypress='javascript:tbx_fnIntegerOneOrTwoTreeFour(event, this);'
function tbx_fnIntegerOneOrTwoTreeFour(e, ctrl) {
    if (!e) e = window.event;
    if (e.charCode) {

        if (e.charCode == 49 || e.charCode == 50 || e.charCode == 51 || e.charCode == 52) {

        }
        else {
            if (e.preventDefault) { e.preventDefault(); }
        }

    }
    else if (e.keyCode) {
        if (e.keyCode < 48 || e.keyCode > 57) {
            try { e.keyCode = 0; } catch (e) { }
        }
    }
}
//Only Integer    onkeypress='javascript:tbx_fnIntegerOneOrTwoTreeFourFive(event, this);'
function tbx_fnIntegeroOneTwoTreeFourFive(e, ctrl) {
    if (!e) e = window.event;
    if (e.charCode) {

        if (e.charCode == 48 || e.charCode == 49 || e.charCode == 50 || e.charCode == 51 || e.charCode == 52 || e.charCode == 53) {

        }
        else {
            if (e.preventDefault) { e.preventDefault(); }
        }

    }
    else if (e.keyCode) {
        if (e.keyCode < 48 || e.keyCode > 57) {
            try { e.keyCode = 0; } catch (e) { }
        }
    }
}

function tbx_fnInteger0To8(e, ctrl) {
    if (!e) e = window.event;
    if (e.charCode) {

        if (e.charCode == 48 || e.charCode == 49 || e.charCode == 50 || e.charCode == 51 || e.charCode == 52 || e.charCode == 53 || e.charCode == 54 || e.charCode == 55 || e.charCode == 56) {

        }
        else {
            if (e.preventDefault) { e.preventDefault(); }
        }

    }
    else if (e.keyCode) {
        if (e.keyCode < 48 || e.keyCode > 57) {
            try { e.keyCode = 0; } catch (e) { }
        }
    }
}
//



//Only Integer    onkeypress='javascript:tbx_fnIntegerOneOrTwoTreeFourFive(event, this);'
function tbx_fnIntegerOneOrTwoTreeFourFive(e, ctrl) {
    if (!e) e = window.event;
    if (e.charCode) {

        if (e.charCode == 49 || e.charCode == 50 || e.charCode == 51 || e.charCode == 52) {

        }
        else {
            if (e.preventDefault) { e.preventDefault(); }
        }

    }
    else if (e.keyCode) {
        if (e.keyCode < 48 || e.keyCode > 57) {
            try { e.keyCode = 0; } catch (e) { }
        }
    }
}
//Only Integer    onkeypress='javascript:tbx_fnIntegerOneOrTwoTreeFourFiveSixSevenEight(event, this);'
function tbx_fnIntegerOneOrTwoTreeFourFiveSixSevenEight(e, ctrl) {
    if (!e) e = window.event;
    if (e.charCode) {

        if (e.charCode == 49 || e.charCode == 50 || e.charCode == 51 || e.charCode == 52 || e.charCode == 53 || e.charCode == 54 || e.charCode == 55 || e.charCode == 56) {

        }
        else {
            if (e.preventDefault) { e.preventDefault(); }
        }

    }
    else if (e.keyCode) {
        if (e.keyCode < 48 || e.keyCode > 57) {
            try { e.keyCode = 0; } catch (e) { }
        }
    }
}
//Only Integer    onkeypress='javascript:tbx_fnIntegerOneOrTwoTreeFourFiveSixSevenEightnine(event, this);'
function tbx_fnIntegerOneOrTwoTreeFourFiveSixSevenEightnine(e, ctrl) {
    if (!e) e = window.event;
    if (e.charCode) {

        if (e.charCode == 49 || e.charCode == 50 || e.charCode == 51 || e.charCode == 52 || e.charCode == 53 || e.charCode == 54 || e.charCode == 55 || e.charCode == 56 || e.charCode == 57) {

        }
        else {
            if (e.preventDefault) { e.preventDefault(); }
        }

    }
    else if (e.keyCode) {
        if (e.keyCode < 48 || e.keyCode > 57) {
            try { e.keyCode = 0; } catch (e) { }
        }
    }
}
//Only Integer    onblur='javascript:tbx_fnIntegerOnBlur(this);'
function tbx_fnIntegerOnBlur(ctrl) {
    var text = ctrl.value;
    var iCount = 0;
    var bInvalid = 0;
    var returnStr = '';
    if (text == '') return;
    for (iCount = 0; iCount < text.length; iCount++) {
        if ((text.charCodeAt(iCount) < 48 || text.charCodeAt(iCount) > 57))
        { bInvalid = 1; }
        else { returnStr = returnStr.toString() + text.charAt(iCount).toString(); }
    }
    ctrl.value = returnStr;
    if (bInvalid == 1) fnShowAlert('Invalid characters will be ignored', ctrl);
}
// ************** //

// ************** //
//Only Signed Integer    onkeypress='javascript:tbx_fnSignedInteger(event, this);'
function tbx_fnSignedInteger(e, ctrl) {
    if (!e) e = window.event;

    if (e.charCode) {
        if ((e.charCode != 45) && (e.charCode < 48 || e.charCode > 57)) {
            if (e.preventDefault) e.preventDefault();
        }
    }
    else if (e.keyCode) {
        if ((e.keyCode != 45) && (e.keyCode < 48 || e.keyCode > 57)) {
            try { e.keyCode = 0; } catch (e) { }
        }
    }
    //    alert(ctrl.value);
    //    //check the position of '-' char, if invalid then remove
    //    fnSignedIntegerCheck(ctrl);
}

//Only Signed Integer    onkeyup='javascript:tbx_fnSignedIntegerCheck(this);'
function tbx_fnSignedIntegerCheck(ctrl) {
    var text = ctrl.value;
    var iCount = 0;
    var bInvalid = 0;
    var returnStr = '';
    if (text == '') return;
    for (iCount = 0; iCount < text.length; iCount++) {
        if (text.charCodeAt(iCount) == 45) {
            if (iCount == 0) {
                if (text.charCodeAt(0) == 45)
                { returnStr = returnStr.toString() + text.charAt(0).toString(); }
                else if (text.charCodeAt(0) < 48 || text.charCodeAt(0) > 57)
                { bInvalid = 1; }
                else { returnStr = returnStr.toString() + text.charAt(0).toString(); }
            }
            else {
                if (text.charCodeAt(iCount) < 48 || text.charCodeAt(iCount) > 57)
                { bInvalid = 1; }
                else { returnStr = returnStr.toString() + text.charAt(iCount).toString(); }
            }
        }
        else {
            if (text.charCodeAt(iCount) < 48 || text.charCodeAt(iCount) > 57)
            { bInvalid = 1; }
            else { returnStr = returnStr.toString() + text.charAt(iCount).toString(); }
        }
    }

    if (bInvalid == 1)
    { ctrl.value = returnStr; /*some invalid character exist & removed*/ }
}

//Only Signed Integer    onblur='javascript:tbx_fnSignedIntegerOnBlur(this);'
function tbx_fnSignedIntegerOnBlur(ctrl) {
    var text = ctrl.value;
    var iCount = 0;
    var bInvalid = 0;
    var returnStr = '';
    if (text == '') return;
    for (iCount = 0; iCount < text.length; iCount++) {
        if (text.charCodeAt(iCount) == 45) {
            if (iCount == 0) {
                if (text.charCodeAt(0) == 45)
                { returnStr = returnStr.toString() + text.charAt(0).toString(); }
                else if (text.charCodeAt(0) < 48 || text.charCodeAt(0) > 57)
                { bInvalid = 1; }
                else { returnStr = returnStr.toString() + text.charAt(0).toString(); }
            }
            else {
                if (text.charCodeAt(iCount) < 48 || text.charCodeAt(iCount) > 57)
                { bInvalid = 1; }
                else { returnStr = returnStr.toString() + text.charAt(iCount).toString(); }
            }
        }
        else {
            if (text.charCodeAt(iCount) < 48 || text.charCodeAt(iCount) > 57)
            { bInvalid = 1; }
            else { returnStr = returnStr.toString() + text.charAt(iCount).toString(); }
        }
    }
    ctrl.value = returnStr;
    if (bInvalid == 1) fnShowAlert('Invalid characters will be ignored', ctrl);
}
// ************** //




// ************** //
//Only Signed Numeric    onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
function tbx_fnSignedNumeric(e, ctrl) {
    if (!e) e = window.event;
    if (e.charCode) {
        if ((e.charCode != 45) && (e.charCode < 48 || e.charCode > 57)) {
            if (e.charCode != 46 || ctrl.value.indexOf('.') >= 0) {
                if (e.preventDefault) { e.preventDefault(); }
            }
        }
    }
    else if (e.keyCode) {
        if ((e.keyCode != 45) && (e.keyCode < 48 || e.keyCode > 57)) {
            if (e.keyCode != 46 || ctrl.value.indexOf('.') >= 0) {
                try { e.keyCode = 0; } catch (e) { }
            }
        }
    }
}

//Only Signed Numeric    onblur='javascript:tbx_fnSignedNumericOnBlur(this);'
function tbx_fnSignedNumericOnBlur(ctrl) {
    try {
        var strText = ctrl.value;
        var iCount = 0;
        var bInvalid = 0;
        var returnStr = '';
        if (strText == '') return;

        for (iCount = 0; iCount < strText.length; iCount++) {
            if (strText.charCodeAt(iCount) == 45) {
                if (iCount == 0) {
                    if (strText.charCodeAt(iCount) == 45)
                    { returnStr = returnStr.toString() + strText.charAt(iCount).toString(); }
                    else if ((strText.charCodeAt(iCount) < 48 || strText.charCodeAt(iCount) > 57) && (strText.charCodeAt(iCount) != 46 || iCount != ctrl.value.indexOf('.')))
                    { bInvalid = 1; }
                    else { returnStr = returnStr.toString() + strText.charAt(iCount).toString(); }
                }
                else {
                    if ((strText.charCodeAt(iCount) < 48 || strText.charCodeAt(iCount) > 57) && (strText.charCodeAt(iCount) != 46 || iCount != ctrl.value.indexOf('.')))
                    { bInvalid = 1; }
                    else { returnStr = returnStr.toString() + strText.charAt(iCount).toString(); }
                }
            }
            else {
                if ((strText.charCodeAt(iCount) < 48 || strText.charCodeAt(iCount) > 57) && (strText.charCodeAt(iCount) != 46 || iCount != ctrl.value.indexOf('.')))
                { bInvalid = 1; }
                else { returnStr = returnStr.toString() + strText.charAt(iCount).toString(); }
            }
        }
        ctrl.value = returnStr;
        if (bInvalid == 1) fnShowAlert('Invalid characters will be ignored', ctrl);
    } catch (e) { }
}

//Only Signed Numeric    onkeyup='javascript:tbx_fnSignedNumericCheck(this);'
function tbx_fnSignedNumericCheck(ctrl) {
    var text = ctrl.value;
    var iCount = 0;
    var bInvalid = 0;
    var returnStr = '';
    if (text == '') return;
    for (iCount = 0; iCount < text.length; iCount++) {
        if (text.charCodeAt(iCount) == 45) {
            if (iCount == 0) {
                if (text.charCodeAt(iCount) == 45)
                { returnStr = returnStr.toString() + text.charAt(iCount).toString(); }
                else if ((text.charCodeAt(iCount) < 48 || text.charCodeAt(iCount) > 57) && (text.charCodeAt(iCount) != 46 || iCount != ctrl.value.indexOf('.')))
                { bInvalid = 1; }
                else { returnStr = returnStr.toString() + text.charAt(iCount).toString(); }
            }
            else {
                if ((text.charCodeAt(iCount) < 48 || text.charCodeAt(iCount) > 57) && (text.charCodeAt(iCount) != 46 || iCount != ctrl.value.indexOf('.')))
                { bInvalid = 1; }
                else { returnStr = returnStr.toString() + text.charAt(iCount).toString(); }
            }
        }
        else {
            if ((text.charCodeAt(iCount) < 48 || text.charCodeAt(iCount) > 57) && (text.charCodeAt(iCount) != 46 || iCount != ctrl.value.indexOf('.')))
            { bInvalid = 1; }
            else { returnStr = returnStr.toString() + text.charAt(iCount).toString(); }
        }
    }

    if (bInvalid == 1)
    { ctrl.value = returnStr; /*some invalid character exist & removed*/ }
    ctrl.value = ctrl.value.replace('-', '');
    var ctl = parseFloat(ctrl.value);
    if (ctl <= 0) {
        ctrl.value = '';
    }

}
// ************** //


// ************** //
//Allow to type only integer; onkeypress='javascript:fnSetPhoneDigits(event, this);'
function fnSetPhoneDigits(e, cntrl) {
    try { } catch (e) { } if (!e) e = window.event;
    if (e.charCode) { if (e.charCode < 48 || e.charCode > 57 || cntrl.value.length > 10) { if (e.preventDefault) { e.preventDefault(); } } }
    else if (e.keyCode) { if (e.keyCode < 48 || e.keyCode > 57 || cntrl.value.length > 10) { try { e.keyCode = 0; } catch (e) { } } }
}

//Only for US Phone Format onblur='javascript:fnSetPhoneFormat(this,1);' onkeyup='javascript:fnSetPhoneFormat(this,0);'
function fnSetPhoneFormat(cntrl, lostFocus) { return true; }

function fnIsValidPhoneFormat(cntrl) {
    cntrl.value = cntrl.value;
    if (cntrl.value == '') return;

    var strPhoneDigits = cntrl.value.replace('(', '').replace(')', '').replace('-', '').replace(' ', '').replace(' ', '').replace(' ', '');
    if (strPhoneDigits.length < 10) {
        alert('Please enter a valid phone no.');
        cntrl.value = '';
    }
}
// ************** //


//Only for SSNFormat onblur='javascript:fnSetSSNFormat(this,1);' onkeyup='javascript:fnSetSSNFormat(this,0);'
function fnSetSSNFormat(cntrl, lostFocus) {
    if (window.event) {
        //alert(window.event.keyCode);
        if (window.event.keyCode == 9) return;
    }
    var baseValue = RemoveExtraChars(cntrl.value);
    var finalValue = ""
    if (baseValue == "") {
        if (lostFocus == 1)
            cntrl.value = "";
        return;
    }
    else {
        finalValue = "";
        if (baseValue.length >= 3) {
            finalValue = finalValue + baseValue.substring(0, 3) + "-";
            if (baseValue.length >= 5) {
                finalValue = finalValue + baseValue.substring(3, 5) + "-";
                if (baseValue.length >= 9) {
                    finalValue = finalValue + baseValue.substring(5, 9);
                }
                else {
                    finalValue = finalValue + baseValue.substring(5, baseValue.length);
                }
            }
            else {
                finalValue = finalValue + baseValue.substring(3, baseValue.length);
            }
        }
        else {
            finalValue = finalValue + baseValue;
        }
    }
    cntrl.value = finalValue;
}
// ************** //


//This textbox allows alphabets & numerics
//AlphaNumeric Only onkeypress="tbx_fnAlphaNumericOnly(event, this);" 
function tbx_fnAlphaNumericOnly(e, ctrl) {   //.:46, >:62, ,:44,
    if (!e) e = window.event;
    if (e.charCode) {
        if ((e.charCode < 48 || (e.charCode > 57 && e.charCode < 65) || (e.charCode > 90 && e.charCode < 97) || e.charCode > 122) && e.charCode != 95 && e.charCode != 32) {
            if (e.preventDefault) {
                e.preventDefault();
            }
        }
    }
    else if (e.keyCode) {
        if ((e.keyCode < 48 || (e.keyCode > 57 && e.keyCode < 65) || (e.keyCode > 90 && e.keyCode < 97) || e.keyCode > 122) && e.keyCode != 95 && e.keyCode != 32) {
            try {
                e.keyCode = 0;
            }
            catch (e)
            { }
        }
    }
}

//onchange="return tbx_fnAlphaNumericOnlyOnBlur(this);"
function tbx_fnAlphaNumericOnlyOnBlur(ctrl) {   //.:46, >:62, ,:44,
    var text = ctrl.value;
    var iCount = 0;
    var bInvalid = 0;
    var returnStr = '';
    if (text == '')
        return;

    var tmpAscii;
    for (iCount = 0; iCount < text.length; iCount++) {
        tmpAscii = text.charCodeAt(iCount);
        if (((tmpAscii < 48 || (tmpAscii > 57 && tmpAscii < 65) || (tmpAscii > 90 && tmpAscii < 97) || tmpAscii > 122) && (tmpAscii != 95) && (tmpAscii != 32))) {
            bInvalid = 1;
        }
        else {
            returnStr = returnStr.toString() + text.charAt(iCount);
        }
    }
    ctrl.value = returnStr;
    if (bInvalid == 1) fnShowAlert('Invalid characters will be ignored', ctrl);
}
// ************** //


// ************** //
//This textbox allows alphabets & numerics with . , : > with space
//AlphaNumeric Only onkeypress="tbx_fnAlphaNumeric(event, this);" 
function tbx_fnAlphaNumeric(e, ctrl) {   //.:46, >:62, , :44, #:35
    if (!e) e = window.event;
    if (e.charCode) {
        if ((e.charCode < 48 || (e.charCode > 57 && e.charCode < 65) || (e.charCode > 90 && e.charCode < 97) || e.charCode > 122) && e.charCode != 95 && e.charCode != 32) {
            if (e.charCode != 44 && e.charCode != 46 && e.charCode != 62) //to allow : > ,&& e.charCode != 35
            {
                if (e.preventDefault) {
                    e.preventDefault();
                }
            }
        }
    }
    else if (e.keyCode) {
        if ((e.keyCode < 48 || (e.keyCode > 57 && e.keyCode < 65) || (e.keyCode > 90 && e.keyCode < 97) || e.keyCode > 122) && e.keyCode != 95 && e.keyCode != 32) {
            if (e.keyCode != 44 && e.keyCode != 46 && e.keyCode != 62 && e.keyCode != 35) //to allow : > , #
            {
                try {
                    e.keyCode = 0;
                }
                catch (e)
                { }
            }
        }
    }
}

//onchange="return tbx_fnAlphaNumericOnBlur(this);"
function tbx_fnAlphaNumericOnBlur(ctrl) {   //.:46, >:62, ,:44, #:35
    var text = ctrl.value;
    var iCount = 0;
    var bInvalid = 0;
    var returnStr = '';
    if (text == '')
        return;

    var tmpAscii;
    for (iCount = 0; iCount < text.length; iCount++) {
        tmpAscii = text.charCodeAt(iCount);
        if (((tmpAscii < 48 || (tmpAscii > 57 && tmpAscii < 65) || (tmpAscii > 90 && tmpAscii < 97) || tmpAscii > 122) && (tmpAscii != 95) && (tmpAscii != 32))
            && (tmpAscii != 44 && tmpAscii != 46 && tmpAscii != 62 && tmpAscii != 35)) {
            bInvalid = 1;
        }
        else {
            returnStr = returnStr.toString() + text.charAt(iCount);
        }
    }
    ctrl.value = returnStr;
    if (bInvalid == 1) fnShowAlert('Invalid characters will be ignored', ctrl);
}
// ************** //

// ************** //
//Allows alphanumeric with slash(/) and hyphen(-)
//AlphaNumericType1 onkeypress="javascript:tbx_fnAlphaNumericType1(event, this);" 
function tbx_fnAlphaNumericType1(e, ctrl) {   //  / 47  - 45
    if (!e) e = window.event;
    if (e.charCode) {
        if ((e.charCode < 48 || (e.charCode > 57 && e.charCode < 65) || (e.charCode > 90 && e.charCode < 97) || e.charCode > 122) && e.charCode != 95 && e.charCode != 32) {
            if (e.charCode != 45 && e.charCode != 47) //to allow - and /
            {
                if (e.preventDefault) {
                    e.preventDefault();
                }
            }
        }
    }
    else if (e.keyCode) {
        if ((e.keyCode < 48 || (e.keyCode > 57 && e.keyCode < 65) || (e.keyCode > 90 && e.keyCode < 97) || e.keyCode > 122) && e.keyCode != 95 && e.keyCode != 32) {
            if (e.keyCode != 45 && e.keyCode != 47) //to allow - and /
            {
                try {
                    e.keyCode = 0;
                }
                catch (e)
                { }
            }
        }
    }
}

//Allows alphanumeric with slash(/) and hyphen(-)
//onchange="javascript:return tbx_fnAlphaNumericType1OnBlur(this);"
function tbx_fnAlphaNumericType1OnBlur(ctrl) {   //  / 47  - 45
    var text = ctrl.value;
    var iCount = 0;
    var bInvalid = 0;
    var returnStr = '';
    if (text == '') return;

    var tmpAscii;
    for (iCount = 0; iCount < text.length; iCount++) {
        tmpAscii = text.charCodeAt(iCount);
        if (((tmpAscii < 48 || (tmpAscii > 57 && tmpAscii < 65) || (tmpAscii > 90 && tmpAscii < 97) || tmpAscii > 122) && (tmpAscii != 95) && (tmpAscii != 32))
            && (tmpAscii != 45 && tmpAscii != 47)) {
            bInvalid = 1;
        }
        else {
            returnStr = returnStr.toString() + text.charAt(iCount);
        }
    }
    ctrl.value = returnStr;
    if (bInvalid == 1) alert('Invalid characters will be ignored');
}
// ************** //


//This textbox allows only alphabets with space
//Alpha Only onkeypress='javascript:tbx_fnAlphaOnly(event, this);'
function tbx_fnAlphaOnly(e, cntrl) { if (!e) e = window.event; if (e.charCode) { if (e.charCode < 65 || (e.charCode > 90 && e.charCode < 97) || e.charCode > 122) { if (e.charCode != 95 && e.charCode != 32) { if (e.preventDefault) { e.preventDefault(); } } } } else if (e.keyCode) { if (e.keyCode < 65 || (e.keyCode > 90 && e.keyCode < 97) || e.keyCode > 122) { if (e.keyCode != 95 && e.keyCode != 32) { try { e.keyCode = 0; } catch (e) { } } } } }

//onchange='javascript:return tbx_fnAlphaOnlyOnBlur(this);'
function tbx_fnAlphaOnlyOnBlur(cntrl) { var text = cntrl.value; var iCount = 0; var bInvalid = 0; var returnStr = ''; if (text == '') return; for (iCount = 0; iCount < text.length; iCount++) { if ((text.charCodeAt(iCount) < 65 || (text.charCodeAt(iCount) > 90 && text.charCodeAt(iCount) < 97) || text.charCodeAt(iCount) > 122) && (text.charCodeAt(iCount) != 95) && (text.charCodeAt(iCount) != 32)) { bInvalid = 1; } else { returnStr = returnStr.toString() + text.charAt(iCount); } } cntrl.value = returnStr; if (bInvalid == 1) { alert('Invalid characters will be ignored'); } }
// ************** //


//This textbox allows alphabets & numerics
//AlphaNumeric Only onkeypress="tbx_fnUserName(event, this);" 
function tbx_fnUserName(e, ctrl) {   //.:46, >:62, ,:44,
    if (!e) e = window.event; if (e.charCode) { if ((e.charCode < 48 || (e.charCode > 57 && e.charCode < 65) || (e.charCode > 90 && e.charCode < 97) || e.charCode > 122) && e.charCode != 95 && e.charCode != 46) if (e.preventDefault) e.preventDefault(); }
    else if (e.keyCode) { if ((e.keyCode < 48 || (e.keyCode > 57 && e.keyCode < 65) || (e.keyCode > 90 && e.keyCode < 97) || e.keyCode > 122) && e.keyCode != 95 && e.keyCode != 46) { try { e.keyCode = 0; } catch (e) { } } }
}


// Only for Requrie fild validater    OnClientClick='javascript:return ValidateAllTextForm();'

function ValidateAllTextForm() {
    var count = 0;
    var ID;
    var cnt = 0;
    $('.reqirerd').each(function() {

        if ($(this).is("input") == true) {
            cnt = 0;

        }
        else {
            cnt = $(this).find("input:checked").length;
        }
        $(this).css('background', 'none');
        if (($(this).val() == "" || $(this).val() == "Select.." || $(this).val() == "Select" || ($(this).val() == "0" && $(this).attr('type') != 'text')) && count == 0 && cnt == 0) {

            ID = $(this).attr("id");
            $(this).focus();
            $(this).css('background-color', '#FFBDC1');


            count++;
            return (false);
        }

    });
    if (count == 0) {
        return true;
    }
    else {

        alert("Please fill all required fields");
        return false;

    }

}

function ValidateAllTextForm1() {
    var count = 0;
    var ID;
    var cnt = 0;
    $('.reqirerd1').each(function() {
        if ($(this).is("input") == true) {
            cnt = 0;

        }
        else {
            cnt = $(this).find("input:checked").length;
        }
        $(this).css('background', 'none');
        if (($(this).val() == "" || $(this).val() == "Select..") && count == 0 && cnt == 0) {

            ID = $(this).find("input:checked").length;
            $(this).focus();
            $(this).css('background-color', '#FFBDC1');


            count++;
            return (false);
        }

    });
    if (count == 0) {
        return true;
    }
    else {
        alert("Please fill all required fields");
        return false;
    }

}
function ValidateAllTextForm2() {
    var count = 0;
    var ID;
    var cnt = 0;
    $('.reqirerd2').each(function() {
        if ($(this).is("input") == true) {
            cnt = 0;

        }
        else {
            cnt = $(this).find("input:checked").length;
        }
        $(this).css('background', 'none');
        if (($(this).val() == "" || $(this).val() == "Select.." || ($(this).val() == "0" && $(this).attr('type') != 'text')) && count == 0 && cnt == 0) {

            ID = $(this).find("input:checked").length;
            $(this).focus();
            $(this).css('background-color', '#FFBDC1');


            count++;
            return (false);
        }

    });
    if (count == 0) {
        return true;
    }
    else {
        alert("Please fill all required fields");
        return false;
    }

}

function ValidateAllTextForm3() {
    var count = 0;
    var ID;
    var cnt = 0;
    $('.reqirerd3').each(function() {
        if ($(this).is("input") == true) {
            cnt = 0;

        }
        else {
            cnt = $(this).find("input:checked").length;
        }
        $(this).css('background', 'none');
        if (($(this).val() == "" || $(this).val() == "Select..") && count == 0 && cnt == 0) {

            ID = $(this).find("input:checked").length;
            $(this).focus();
            $(this).css('background-color', '#FFBDC1');


            count++;
            return (false);
        }

    });
    if (count == 0) {
        return true;
    }
    else {
        alert("Please fill all required fields");
        return false;
    }

}

function ValidateRadio(id, rad1, rad2) {

    var Checkdvalue;
    var list = id; //Cleint ID of RadioButtonList
    var rdbtnLstValues = list.getElementsByTagName("input");

    for (var i = 0; i < rdbtnLstValues.length; i++) {
        if (rdbtnLstValues[i].checked) {
            Checkdvalue = rdbtnLstValues[i].value;
            if (Checkdvalue == "1") {

                $("#" + rad1).addClass("reqirerd");
                $("#" + rad2).addClass("reqirerd");
                // document.getElementById("rad1").className='reqirerd';
                //document.getElementById("rad1").className='reqirerd';
            }
            else {
                $("#" + rad1).removeClass("reqirerd");
                $("#" + rad2).removeClass("reqirerd");
                $("#" + rad1).css('background', 'none');
                $("#" + rad2).css('background', 'none');

            }
        }
    }


}


function MaxLengthCount(txt, MaxLen) {
    var txtBox = txt;
    var len = MaxLen;


    if (txtBox.value.length > len) {

        txtBox.value = txtBox.value.substring(0, len);
        alert("Charactor length is Exeed from " + len);



    }
    else { }

}
function checkDateFormat(that) {

    var mo, day, yr;
    var entry = that.value;
    var re = /\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/;
    if (re.test(entry)) {
        var delimChar = (entry.indexOf("/") != -1) ? "/" : "-";
        var delim1 = entry.indexOf(delimChar);
        var delim2 = entry.lastIndexOf(delimChar);

        day = parseInt(entry.substring(0, delim1), 10);
        mo = parseInt(entry.substring(delim1 + 1, delim2), 10);
        yr = parseInt(entry.substring(delim2 + 1), 10);
        var testDate = new Date(yr, mo - 1, day);

        if (testDate.getDate() == day) {
            if (testDate.getMonth() + 1 == mo) {
                if (testDate.getFullYear() == yr) {
                    return true;
                } else {
                    that.value = "";
                    alert("Invalid date.");
                }
            }
            else {
                that.value = "";
                alert("Invalid date.");

            }
        }
        else {
            that.value = "";
            alert("Invalid date.");
        }
    }
    else {
        if (entry != "") {
            that.value = "";
            alert("Incorrect date format. Enter as (dd/MM/yyyy).");
        }
    }
    return false;
}
function ValidateFileSize(a) {

    var uploadcontrol = document.getElementById(a.id);
    if (uploadcontrol.files[0].size > 512000) {
        alert('File size should not greater than 512 kb.');
        document.getElementById(a.id).value = '';
        return false;
    }
    else {
        return true;
    }

}
function UploadControlValidationForLenthAndFileFormat(maxLengthFileName, validFileFormaString, uploadControlId) {
    //ex---------------
    //maxLengthFileName=50;
    //validFileFormaString=JPG*JPEG*PDF*DOCX
    //uploadControlId=upSaveBill
    //ex---------------
    var msg = '';
    if (document.getElementById(uploadControlId).value != '') {
        var size = document.getElementById(uploadControlId);

        var fileName = document.getElementById(uploadControlId).value;
        var lengthFileName = parseInt(document.getElementById(uploadControlId).value.length)

        var fileExtacntionArray = new Array();
        fileExtacntionArray = fileName.split('.');

        if (fileExtacntionArray.length == 2) {

            var fileExtacntion = fileExtacntionArray[fileExtacntionArray.length - 1];


            if (lengthFileName >= parseInt(maxLengthFileName) + parseInt(1)) {
                msg += '- File name should be less than ' + maxLengthFileName + ' characters. \n';
            }
            for (i = 0; i <= (fileName.length - 1); i++) {
                var charFileName = '';

                charFileName = fileName.substring(i, i + 1);

                if ((charFileName == '~') || (charFileName == '!') || (charFileName == '@') || (charFileName == '#') || (charFileName == '$') || (charFileName == '%') || (charFileName == '&') || (charFileName == '*') || (charFileName == '{') || (charFileName == '}') || (charFileName == '|') || (charFileName == '<') || (charFileName == '>') || (charFileName == '?')) {

                    msg += '- Special character not allowed in file name. \n';
                    break;
                }

            }
            var isFileFormatCorrect = false;
            var strValidFormates = '';

            if (validFileFormaString != "") {

                var fileFormatArray = new Array();
                fileFormatArray = validFileFormaString.split('*');

                for (var j = 0; j < fileFormatArray.length; j++) {
                    if (fileFormatArray[j].toUpperCase() == fileExtacntion.toUpperCase()) {
                        isFileFormatCorrect = true;
                    }

                    if (j == fileFormatArray.length - 1) {
                        strValidFormates += '.' + fileFormatArray[j].toLowerCase();

                    }
                    else {
                        strValidFormates += '.' + fileFormatArray[j].toLowerCase() + '/';

                    }
                }

                if (isFileFormatCorrect == false) {
                    msg += '- File format is not correct (only ' + strValidFormates + ').\n';
                }

            }

        }
        else {
            msg += '- File name is incorrect';
        }
        if (msg != '') {
            document.getElementById(uploadControlId).value = "";
            alert(msg);
            return false;
        }
        else {
            return true;
        }

    }
}
