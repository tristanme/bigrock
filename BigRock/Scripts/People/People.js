﻿$(function () {
    $('#TypeCode').change(function () {
        var typeCode = $("#TypeCode").val();
        console.log(typeCode);

        if (typeCode == 3) {
            $('#TypeCodeOther_Container').show();
        } else {
            $('#TypeCodeOther_Container').hide();
        }

    });
});