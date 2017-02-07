$(function () {
    var dateFormat = "mm-dd-yy",
    from = $("#from")
    .datepicker({
        defaultDate: "+1w",
        changeMonth: true,
        numberOfMonths: 1
    })
    .on("change", function () {
        to.datepicker("option", "minDate", getDate(this));
    }),
    to = $("#to").datepicker({
        defaultDate: "+1w",
        changeMonth: true,
        numberOfMonths: 1
    })
    .on("change", function () {
        from.datepicker("option", "maxDate", getDate(this));
    });

    function getDate(element) {
        var date;
        try {
            date = $.datepicker.parseDate(dateFormat, element.value);
        } catch (error) {
            date = null;
        }

        return date;
    }
});

$('#frmSel input').on('change', function () {
    var rptType = $('input[name=rptType]:checked', '#frmSel').val();
    var strtDate = $('#from').val();
    var endDate = $('#to').val();
    $.ajax({
        type: "post",
        url: "/Media/Index/",
        data:{rptType:rptType, strtDate:strtDate, endDate:endDate},
        datatype: "json",
        traditional: true,
        success: function (data) {
            // debugger  
            if (data == "No Record Found") {
                alert('No Record Found');
            }
            else {
                $('#gridContent').html(data);
            }
        }
    });
});

$(document).ready(function () {
    $('#bttnSearch').click(function () {
        var rptType = $('input[name=rptType]:checked', '#frmSel').val();
        var strtDate = $('#from').val();
        var endDate = $('#to').val();
        $.ajax({
            type: "post",
            url: "/Mediaradar.Ads/GetAds/" +rptType +"/"+strtDate+"/"+endDate,
            datatype: "json",
            traditional: true,
            success: function (data) {
                // debugger  
                if (data == "No Record Found") {
                    alert('No Record Found');
                }
                else {
                    $('#gridContent').html(data);
                }
            }
        });
    });
});