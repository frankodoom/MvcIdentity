
$(document).ready(function () {
    $.ajax({
        url: "/App/GetChartData",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        method: "Get",
        succcess: function (result) {
            alert(result.data);
            // morris config
            new Morris.Line({
                // ID of the element in which to draw the chart.
                element: 'demographics',
                // Chart data records -- each entry in this array corresponds to a point on
                // the chart.
                data: $.parseJSON(data),
                // The name of the data record attribute that contains x-values.
                xkey: 'year',
                // A list of names of data record attributes that contain y-values.
                ykeys: ['value'],
                // Labels for the ykeys -- will be displayed when you hover over the
                // chart.
                labels: ['Value']
            });

        },
        error: function (xhr, status, error) {
            alert(error);
            alert(status);
        }
    });
});
