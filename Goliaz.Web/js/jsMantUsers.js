$(document).ready(function () {
    $("#divEditUser").dialog({
        width: "auto",
        height: "auto",
        autoOpen: false,
        title: "Edit User"
    });
});

function EditUser(idUser)
{
    $("#divEditUser").empty();
    $("#divEditUser").load("EditUser.aspx", { idUser: idUser }, function () {
        $("#divEditUser").dialog("open");

        $(".validate").watermark();

        $("#txtBirthDate").inputmask("dd/mm/yyyy", { autoUnmask: true });

        $("#txtVenusPB").inputmask("h:s:s", { autoUnmask: true });
        $("#txtPoseidonPB").inputmask("h:s:s", { autoUnmask: true });
        $("#txtHadesPB").inputmask("h:s:s", { autoUnmask: true });

        $("#btnSaveChanges").unbind("click", saveChangesUser);
        $("#btnSaveChanges").bind("click", saveChangesUser);
    });
}

function saveChangesUser() {
    if (validateRegister()) {
        var service = new Services.wcfGoliaz();
        service.SaveChangesUser($("#hdIdUser").val(),
            $("#txtName").val(),
            $("#txtEmail").val(),
            $("#Nationality").val(),
            $('input[name=rdSex]:checked').val(),
            $("#txtBirthDate")[0].value,
            $("#txtPoseidonPB")[0].value,
            $("#txtHadesPB")[0].value,
            $("#txtVenusPB")[0].value,
            function (resp) {
                if (resp) {
                    $("#divEditUser").dialog("close");
                    $("<div>Your changes have been saved successfully</div>").dialog({
                        height: "auto",
                        width: "auto",
                        resizable: false,
                        buttons: {
                            Accept: function () {
                                $(this).dialog("destroy");
                            }
                        }
                    });
                }
            },
            function (error) {
                $("#divEditUser").dialog("close");
            });
    }
    return false;
}

function showMessage(message, title) {
    $("<div>" + message + "</div>").dialog({
        width: "auto",
        height: "auto",
        title: title,
        buttons: {
            Accept: function () {
                $(this).dialog("destroy");
            }
        }
    });
}

function DeleteUser(userId) {
    $("<div>Are you sure that you want to delete the selected user definitely?</div>").dialog({
        width: "auto",
        height: "auto",
        title: "Delete User",
        buttons: {
            Accept: function () {
                var service = new Services.wcfGoliaz();
                service.DeleteUser(userId, function (resp) {
                    showMessage("User successfully deleted", "User Deleted");
                },
                function (error) {
                });
                $(this).dialog("destroy");
            },
            Cancel: function () {
                $(this).dialog("destroy");
            }
        }
    });
}

function validateRegister() {
    var valido = true;
    $("#ErrorMessages").empty();
    $(".validate").each(function () {
        if (($(this).val() == $(this).attr("title")) || $(this).val() == "") {
            valido = false;
            var spanColor = $("<span class='spanColor' ></span>");
            $(spanColor).text("* You must insert " + $(this).attr("title") + ".");
            $(spanColor).appendTo("#ErrorMessages");
            $("<br/>").appendTo("#ErrorMessages");
            $(this).css("border-color", "rgba(255,0,0,0.4)");
        }
        else {
            $(this).css("border-color", "");
        }
    });

    if (valido) {
        $("#ErrorMessages").hide();
    }
    else {
        $("#ErrorMessages").show();
    }
    return valido;
}