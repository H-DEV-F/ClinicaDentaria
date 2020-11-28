// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function noMondays(date) {
    /*var id = $("#dentista-id option:selected").val();
    var status = false;
    Jajax = jQuery.noConflict(true);
    $.ajax({
        url: "/Agenda/VerificarDatasDisponiveis",
        method: "GET",
        contentType: 'application/x-www-form-urlencoded; charset=utf-8',
        dataType: "json",
        data: {
            Id: id
        },
        success: function (data, textStatus, jqXHR) {
            data.map((day) => {
                var datevalidacao = new Date(day.replace("T00:00:00", ""));
                //console.log(String(date.getDate()) == String(datevalidacao.getDate()));
                if (String(date.getDate()) == String(datevalidacao.getDate()))
                    return [false, "closed", "Closed on Monday"]
                else
                    return [true, "", ""]
            });

            //console.log(days);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus);
            console.log(jqXHR.status);
            console.log(jqXHR.statusText);
            console.log(jqXHR.responseText);
        }
    });
    if (date.getDay() === 1)
        return [false, "closed", "Closed on Monday"]
    else
        return [true, "", ""]*/
}
$(function () {
    var id = $("#dentista-id option:selected").val();
    var days = [];
    var month = 0;
    $.post("/Agenda/VerificarDatasDisponiveis/" + id, function (data, textStatus, jqXHR) {
        //console.log(data);
        data.map((d) => {
            var dt = Date.parse(d.replace("00:00:00", "01:00:00"));
            var datevalidacao = new Date(dt);
            days.push(String(datevalidacao.getDate()));
            month = String(datevalidacao.getMonth());
        });
    });
    $("#datepicker").datepicker({
        altFormat: "yy-mm-dd", dateFormat: "dd/mm/yy", minViewMode: 1,
        autoclose: true,
        beforeShowDay: function (date) {
            var status = false;
            if (days.includes(String(date.getDate()))) status = true;
            if (String(date.getMonth()) != month) status = true;
            if (!status)
                return [false, "closed", "Closed on Monday"]
            else
                return [true, "", ""]
        }
    });
    $(document).ready(function ()
    {
        if ($("#datepicker").val() == "") {
            $("#hora").hide();
            $('label[for="hora"]').hide();
        } else
        {
            var id = $("#dentista-id option:selected").val();
            var data = $("#datepicker").val();
            data = data.split("/");
            data = data[2] + "-" + data[1] + "-" + data[0];
            $.ajax({
                url: "/Agenda/VerificarHorariosDisponiveis",
                method: "GET",
                contentType: 'application/x-www-form-urlencoded; charset=utf-8',
                dataType: "json",
                data: {
                    id: id,
                    date: data
                },
                success: function (data, textStatus, jqXHR) {
                    //console.log(data);
                    var list = $("#hora").html();
                    data.map((d) => {
                        list += "<option value=" + d + ">" + d + ":00</option>";
                    });
                    $("#hora").html("");
                    $("#hora").html(list);
                    $("#hora").show();
                    $('label[for="hora"]').show();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log(textStatus);
                    console.log(jqXHR.status);
                    console.log(jqXHR.statusText);
                    console.log(jqXHR.responseText);
                }
            });
        }
    });
    $("#datepicker").on("change", function () {
        var id = $("#dentista-id option:selected").val();
        var data = $("#datepicker").val();
        data = data.split("/");
        data = data[2] + "-" + data[1] + "-" + data[0];

        $.ajax({
            url: "/Agenda/VerificarHorariosDisponiveis",
            method: "GET",
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',
            dataType: "json",
            data: {
                id: id,
                date: data
            },
            success: function (data, textStatus, jqXHR) {
                //console.log(data);
                var list = "";
                data.map((d) => {
                    list += "<option value=" + d + ">" + d + ":00</option>";
                });
                $("#hora").html(list);
                $("#hora").show();
                $('label[for="hora"]').show();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus);
                console.log(jqXHR.status);
                console.log(jqXHR.statusText);
                console.log(jqXHR.responseText);
            }
        });
    });
    $("#dentista-id").on("change", function () {
        $("#datepicker").val("");
        $("#hora").hide();
        $('label[for="hora"]').hide();
    });
});
