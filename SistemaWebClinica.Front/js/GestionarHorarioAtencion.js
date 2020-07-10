//Boton buscar medico
$("#btnBuscar").on("click", function (event) {
    event.preventDefault();

    //obtener datos de txtRut del form
    var rut = $("#txtRut").val();
    var obj = JSON.stringify({ rut: rut });

    if (rut.length > 0) {
        //LLamada ajax
        $.ajax({
            type: "POST",
            url: "GestionarHorarioAtencion.aspx/BuscarMedico",
            data: obj,
            contentType: 'application/json; chartset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                console.log("Exitoso");
                llenarDatosMedico(data.d);
            }
        });
    }
    else {
        console.log("No ha ingresado rut")
    }
});

function llenarDatosMedico(obj) {
    $("#lblNombre").text(obj.Nombre);
    $("#lblApellidos").text(obj.ApPaterno.concat(" ".concat(obj.ApMaterno)));
    $("#lblEspecialidad").text(obj.Especialidad.Descripcion);    
}