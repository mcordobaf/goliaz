<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Goliaz.Web.index" EnableViewStateMac="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Goliaz Challenge</title>
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/jquery-ui.js" type="text/javascript" ></script>
    <script src="js/jquery.inputmask.bundle.js" type="text/javascript" ></script>

    <meta http-equiv="Cache-Control" content="no-store" />

    <link href="css/jquery-ui.css" type="text/css" rel="stylesheet" />
    <link href="css/StyleIndex.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            if ($("#hdIsNew").val() != "") {
                $("#divMensaje").dialog({
                    width: 290,
                    height: "auto",
                    dialogClass: 'noTitleStuff',
                    buttons: {
                        Accept: function () {
                            $(this).dialog("close");
                        }
                    }
                });
                $("#MainDiv").hide();
            }
            $("#MainDiv").hide();
            $("#btnRegisterReport").show();
            $("#btnRegisterReport").unbind("click", loadMainDiv);
            $("#btnRegisterReport").bind("click", loadMainDiv);

            $("#btnSaveReport").unbind("click", saveReport);
            $("#btnSaveReport").bind("click", saveReport);

            $("#ddlDay").unbind("change", loadMainDiv);
            $("#ddlDay").bind("change", loadMainDiv);
        });

        function saveReport() {
            $("#btnSaveReport").prop("disabled", true);
            $("#divMensajeErrores").empty();
            $("#divMensajeErrores").hide();
            var idArrays = new Array();
            var nameArrays = new Array();
            var dataTypeArrays = new Array();
            var informsArrays = new Array();
            var minimoIngres = 0;
            for (var i = 1; i <= 10; i++) {
                if ($("#hdReport" + i).val() != "" && typeof ($("#hdReport" + i).val()) != "undefined") {
                    if ($("#txtReport" + i)[0].value.indexOf("m") > -1 || $("#txtReport" + i)[0].value.indexOf("s") > -1) {
                        var spanColor = $("<span class='spanColor' ></span>");
                        $(spanColor).text("* Time contains wrong characters.");
                        $(spanColor).appendTo("#divMensajeErrores");
                        $("#divMensajeErrores").show();
                        $("#btnSaveReport").prop("disabled", false);

                        return false;
                    } else {
                        if ($("#txtReport" + i)[0].value != "") {
                            minimoIngres++;
                            idArrays.push(parseInt($("#hdReport" + i).val()));
                            nameArrays.push($("#lblReport" + i).text());
                            dataTypeArrays.push($("#ddlDataTypeReport" + i).val());
                            informsArrays.push($("#txtReport" + i)[0].value);
                        }
                    }
                }
                else
                {
                    if ($("#txtReport" + i)[0].value != "" && typeof ($("#txtReport" + i).val()) != "undefined") {
                        if ($("#txtReport" + i)[0].value.indexOf("m") > -1 || $("#txtReport" + i)[0].value.indexOf("s") > -1) {
                            var spanColor = $("<span class='spanColor' ></span>");
                            $(spanColor).text("* Time contains wrong characters.");
                            $(spanColor).appendTo("#divMensajeErrores");
                            $("#divMensajeErrores").show();
                            $("#btnSaveReport").prop("disabled", false);

                            return false;
                        }
                        else {
                            minimoIngres++;
                            nameArrays.push($("#lblReport" + i).text());
                            dataTypeArrays.push($("#ddlDataTypeReport" + i).val());
                            informsArrays.push($("#txtReport" + i)[0].value);
                        }
                    }
                }
            }

            if (minimoIngres == 0) {
                var spanColor = $("<span class='spanColor' ></span>");
                $(spanColor).text("* You have to register at least 1 field.");
                $(spanColor).appendTo("#divMensajeErrores");
                $("#divMensajeErrores").show();
                $("#btnSaveReport").prop("disabled", false);

                return false;
            }


            var service = new Services.wcfGoliaz();
            service.SaveInform(
                parseInt($("#hdIdUser").val()),
                parseInt($("#ddlDay").val()),
                parseInt($("#hdIdDayReported").val()),
                idArrays,
                nameArrays,
                dataTypeArrays,
                informsArrays,
                function (resp)
                {
                    if (resp) {
                        $("<div>Report saved successfully!</div>").dialog({
                            height: "auto",
                            title: "Report Saved",
                            dialogClass: 'noTitleStuff',
                            width: "auto",
                            buttons: {
                                Accept: function () {
                                    $(this).dialog("destroy");
                                    loadMainDiv();
                                    $("#btnSaveReport").prop("disabled", false);
                                }
                            }
                        });
                    }
                },
                function (error)
                {
                       
                });
            return false;
        }

        function loadMainDiv() {
            $("#divMensaje").hide();
            $("#divReports").empty();
            $("#divReports").load("Report.aspx", { Day: $("#ddlDay").val() }, function () {


                $(".validateTime").inputmask("mm:ss", { autoUnmask: true });

                $(".validateOnlyNumber").keyup(function (e) {
                    if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g, '')
                });
                //$(".validateOnlyNumber").keydown(function (e) {
                //    // Allow: backspace, delete, tab, escape, enter and .
                //    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                //        // Allow: Ctrl+A, Command+A
                //        (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
                //        // Allow: home, end, left, right, down, up
                //        (e.keyCode >= 35 && e.keyCode <= 40)) {
                //        // let it happen, don't do anything
                //        return;
                //    }
                //    // Ensure that it is a number and stop the keypress
                //    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                //        e.preventDefault();
                //    }
                //});


                $(".validateOnlyBOrU").keydown(function (e) {
                    //Only B or U
                    if (e.keyCode == 66 || e.keyCode == 85 || e.keyCode == 8 || e.keyCode == 46
                        || e.keyCode == 37 || e.keyCode == 39) {
                        return true;
                    }
                    else {
                        return false;
                    }
                });

                $("#MainDiv").dialog({
                    height: "auto",
                    dialogClass: 'noTitleStuff',
                    width: 700
                });
            });
            return false;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptManager1" runat="server" >
            <Services>
                <asp:ServiceReference Path="~/Services/wcfGoliaz.svc" />
            </Services>
        </asp:ScriptManager>
        <asp:HiddenField ID="hdIdUser" runat="server" />
        <asp:HiddenField ID="hdIsNew" runat="server" />
        <button id="btnRegisterReport" style="display:none;" >Register Report</button>
    <div id="divMensaje" >
        <p id="pMensaje" runat="server" style="padding-top:30px;">
        </p>
    </div>
    <div id="MainDiv" >
        <div style="height:30px; width: 400px;">
            Select Day: <asp:DropDownList ID="ddlDay" runat="server" style="margin-left: 20px; width:200px;" ></asp:DropDownList>
        </div>
        <button id="btnSaveReport" >Save Report</button>
        <div id="divReports">
        </div>
        <div id="divMensajeErrores" style="display:none;">

        </div>
    </div>
    </form>
</body>
</html>
