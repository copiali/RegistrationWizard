$(document).ready(function () {

    $.fn.dataTableExt.aTypes.unshift(
        function (sData) {

            var pattern = new RegExp("^[0-9]{2}\/[0-9]{2}\/[0-9]{4}$");

            if (pattern.test(sData)) {
                return 'AuDate';
            }
            return null;
        }


    );

    $.fn.dataTableExt.oSort['AuDate-asc'] = function (x, y) {
        var arrayX = x.split('/');
        var arrayY = y.split('/');

        if (arrayX.length < 3 && arrayY.length < 3) {
            return 0;

        } else if (arrayX.length < 3 && arrayY.length == 3) {
            return -1;
        } else if (arrayX.length == 3 && arrayY.length < 3) {
            return 1;
        }


        var dateX = new Date(parseInt(arrayX[2]), parseInt(arrayX[1]) - 1, parseInt(arrayX[0]), 0, 0, 0, 0);
        var dateY = new Date(parseInt(arrayY[2]), parseInt(arrayY[1]) - 1, parseInt(arrayY[0]), 0, 0, 0, 0);

        return ((dateX < dateY) ? -1 : ((dateX > dateY) ? 1 : 0));
    };

    $.fn.dataTableExt.oSort['AuDate-desc'] = function (x, y) {
        var arrayX = x.split('/');
        var arrayY = y.split('/');

        if (arrayX.length < 3 && arrayY.length < 3) {
            return 0;

        } else if (arrayX.length < 3 && arrayY.length == 3) {
            return 1;
        } else if (arrayX.length == 3 && arrayY.length < 3) {
            return -1;
        }

        var dateX = new Date(parseInt(arrayX[2]), parseInt(arrayX[1]) - 1, parseInt(arrayX[0]), 0, 0, 0, 0);
        var dateY = new Date(parseInt(arrayY[2]), parseInt(arrayY[1]) - 1, parseInt(arrayY[0]), 0, 0, 0, 0);

        return ((dateX < dateY) ? 1 : ((dateX > dateY) ? -1 : 0));
    };

});