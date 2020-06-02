const DAY_PATTERN1 = "dd/MM/yyyy";
const DAY_PATTERN2 = "yyyy-MM-dd";


/**
 * format date theo định dạng cho trước
 * @param {any} format có 2 dạng là dd/MM/yyyy và yyyy-MM-dd
 * @param {any} date date cần format
 */
function convertDateString(format, date) {
    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();

    switch (format) {
        case DAY_PATTERN1:
            return pad(day) + "/" + pad(month) + "/" + year;
        case DAY_PATTERN2:
            return year + "-" + pad(month) + "-" + pad(day);
    }
}

function pad(number) {
    if (number < 10) {
        return "0" + number;
    }
    else
        return number;
}