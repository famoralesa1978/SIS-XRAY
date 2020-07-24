

$(function () {
    // $("#dialog-message").hide()
    MensajeUsuarioNoExiste(activo);

});


function Mensaje() {
    $("#dialog-message").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });
}

function MensajeUsuarioNoExiste(activo) {
    if (activo == 1) {
        $("#dialog-UsrNoExiste").dialog({
            modal: true,
            buttons: {
                Ok: function () {
                    $(this).dialog("close");
                }
            }
        });
    }

}