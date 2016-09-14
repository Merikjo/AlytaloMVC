﻿/// <reference path="../typings/jquery/jquery.d.ts" />
var SaunaLämpöModel = (function () {
    function SaunaLämpöModel() {
    }
    return SaunaLämpöModel;
}());

function initSaunanTila() {
    $("#SaunanTilaButton").click(function () {
        //alert("Toimii!");
        var switched = $("#Switched").val();
        var saunaOn = $("#SaunaOn").val();
        alert("S: " + switched + ", O:" + saunaOn);

        //määritetään muuttuja:
        var data = new SaunaLämpöModel();
        data.Switched = switched;
        data.SaunaOn = saunaOn;

        //lähetetään JSON-muotoista dataa palvelimelle
        $.ajax({
            type: "POST",
            url: "/TaloSaunat/Edit/1",
            data: JSON.stringify(data),
            contentType: "application/json",
            success: function (data) {
                if (data.success == true) {
                    alert("Kirjaus onnistui.");
                }
                else {
                    alert("Tapahtui virhe: " + data.error);
                }
            },
            dataType: "json"
        });
    });
}