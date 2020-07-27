

$(function () {
    // $("#dialog-message").hide()
    //MensajeUsuarioNoExiste(1);
    //Mensaje();

});


function Mensaje() {
    $("#mje_error").dialog({
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

function RefreshDiv(div, destino) {
    $(div).load(destino);  
}