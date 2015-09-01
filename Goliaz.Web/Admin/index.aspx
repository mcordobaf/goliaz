<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Goliaz.Web.Admin.index" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Goliaz Challenge</title>
    <script src="../js/jquery-1.11.3.min.js"></script>
    <script src="../js/jquery-ui.js" type="text/javascript" ></script>
    <script src="../js/jquery.inputmask.bundle.js" type="text/javascript" ></script>

    <meta http-equiv="Cache-Control" content="no-cache" />

    <link href="../css/jquery-ui.css" type="text/css" rel="stylesheet" />
    <link href="../css/StyleIndex.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#divAddNewDay").dialog({
                height: "auto",
                width: "auto",
                autoOpen: false,
                dialogClass: 'noTitleStuff'
            });


            $("#txtDateNew").inputmask("dd/mm/yyyy", { autoUnmask: true });

            $("#btnSaveNewDay").unbind("click", saveNewDay);
            $("#btnSaveNewDay").bind("click", saveNewDay);
            loadMainDiv();
        });

        function saveNewDay()
        {
            var service = new Services.wcfGoliaz();
            service.saveNewDay($("#ddlDayNew").val(),
                $("#txtDateNew")[0].value,
                $("#ddlState").val(),
                function (resp) {
                    if (resp) {
                        $("#ddlDay").val("1");
                        $("#divAddNewDay").dialog("close");
                        $("<div>New Day saved!</div>").dialog({
                            height: "auto",
                            dialogClass: 'noTitleStuff',
                            width: "auto",
                            buttons: {
                                Accept: function () {
                                    $(this).dialog("destroy");
                                    loadMainDiv();
                                }
                            }
                        });
                    }
                },
                function (error) {
                }
                );
            return false;
        }

        function saveReport() {
            var idArrays = new Array();
            var nameArrays = new Array();
            var dataTypeArrays = new Array();
            var descArrays = new Array();
            var minimoIngres = 0;
            for (var i = 1; i <= 10; i++) {
                if ($("#CheckBox" + i).is(":checked")) {
                    if ($("#hdReport" + i).val() != "" && typeof ($("#hdReport" + i).val()) != "undefined") {
                        minimoIngres++;
                        idArrays.push(parseInt($("#hdReport" + i).val()));
                        nameArrays.push($("#txtReport" + i).val());
                        dataTypeArrays.push($("#ddlDataTypeReport" + i).val());
                        descArrays.push($("#txtDescription" + i)[0].value);
                    }
                    else {
                        if ($("#txtReport" + i)[0].value != "" && typeof ($("#txtReport" + i).val()) != "undefined") {
                            minimoIngres++;
                            nameArrays.push($("#txtReport" + i).val());
                            dataTypeArrays.push($("#ddlDataTypeReport" + i).val());
                            descArrays.push($("#txtDescription" + i)[0].value);
                        }
                    }
                }
            }

            if (minimoIngres == 0) {
                var spanColor = $("<span class='spanColor' ></span>");
                $(spanColor).text("* You have to register all fields.");
                $(spanColor).appendTo("#divMensajeErrores");
                $("#divMensajeErrores").show();
                return false;
            }
            else {
                $("#divMensajeErrores").hide();
            }

            var service = new Services.wcfGoliaz();
            service.SaveConfigDay(
                parseInt($("#ddlDay").val()),
                parseInt($("#hdIdDayConfigured").val()),
                $("#txtDateOfDay")[0].value,
                $("#ddlStateDay").val(),
                idArrays,
                nameArrays,
                dataTypeArrays,
                descArrays,
                function (resp) {
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
                                }
                            }
                        });
                    }
                },
                function (error) {

                });
            return false;
        }

        function loadMainDiv() {
            if ($("#ddlDay").val() != "0") {
                $("#divSelectDay").empty();
                $("#divSelectDay").load("selectDay.aspx", { Random: Math.random() }, function () {
                    $("#ddlDay").unbind("change", loadOnlyReport);
                    $("#ddlDay").bind("change", loadOnlyReport);
                    loadOnlyReport();
                });
            }
            else {
                $("#divAddNewDay").dialog("open");
            }
            return false;
        }

        function DeleteExercise(idExercise)
        {
            $("<div id='DivDel' >Do you want to delete this exercise definitely?</div>").dialog({
                height: "auto",
                dialogClass: 'noTitleStuff',
                width: "auto",
                buttons: {
                    Delete: function () {
                        var service = new Services.wcfGoliaz();
                        service.DeleteExercise(idExercise, function (resp) {
                            
                            $("#DivDel").dialog("destroy");
                            if (resp) {
                                $("<div>The selected exercise was deleted sucessfully</div>").dialog({
                                    height: "auto",
                                    dialogClass: 'noTitleStuff',
                                    width: "auto",
                                    buttons: {
                                        Accept: function () {
                                            $(this).dialog("destroy");
                                            loadOnlyReport();
                                        }
                                    }
                                });
                            }
                        },
                        function (error) {
                            $("#DivDel").dialog("destroy");
                        });
                    },
                    Cancel: function () {
                        $(this).dialog("destroy");
                    }
                }
            });
        }

        function loadOnlyReport()
        {
            if ($("#ddlDay").val() != "0") {
                $("#divReports").empty();
                $("#divReports").load("Report.aspx", { Day: $("#ddlDay").val() }, function () {
                    $("#MainDiv").dialog({
                        height: "auto",
                        dialogClass: 'noTitleStuff',
                        width: 700
                    });
                    $("#btnSaveReport").unbind("click", saveReport);
                    $("#btnSaveReport").bind("click", saveReport);
                    $("#txtDateOfDay").inputmask("dd/mm/yyyy", { autoUnmask: true });
                });
            }
            else {
                $("#divAddNewDay").dialog("open");
            }
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
    <div id="MainDiv" style="display:none;" >
        <div style="height:30px; width: 400px;" id="divSelectDay">
        </div>
        <button id="btnSaveReport" >Save Report</button>
        <div id="divReports">
        </div>
    </div>
    <div id="divAddNewDay">
        <table>
            <tr>
                <td>
                    Day
                </td>
                <td>
                    <asp:DropDownList ID="ddlDayNew" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Date
                </td>
                <td>
                    <asp:TextBox ID="txtDateNew" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    State
                </td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;">
                    <button id="btnSaveNewDay">Add Day</button>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
