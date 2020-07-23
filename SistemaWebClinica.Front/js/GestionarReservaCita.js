$("#btnBuscar").on('click', function (e) {
    e.preventDefault();

    var dni = $("#txtDNI").val();
    buscarPacientePorDni(dni);

});

function buscarPacientePorDni(dni) {

    var data = JSON.stringify({ dni: dni });

    $.ajax({
        type: "POST",
        url: "GestionarReservaCita.aspx/BuscarPacientePorDni",
        data: data,
        contentType: 'application/json; chartset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            if (data.d == null) {
                alert('No existe el paciente con dni: ' + dni);
                limpiarFormularioPaciente();
            }
            else {
                llenarFormularioPaciente(data.d);
            }
        }
        });
};

function llenarFormularioPaciente(obj) {

    $("#idPaciente").val(obj.IdPaciente);
    $("#txtNombres").val(obj.Nombres);
    $("#txtApellidos").val(obj.ApPaterno + " " + obj.ApMaterno);
    $("#txtTelefono").val(obj.Telefono);
    $("#txtEdad").val(obj.Edad);
    $("#txtSexo").val((obj.Sexo == 'M')?'Masculino':'Femenino');

};

function limpiarFormularioPaciente() {

    $("#idPaciente").val("");
    $("#txtNombres").val("");
    $("#txtApellidos").val("");
    $("#txtTelefono").val("");
    $("#txtEdad").val("");
    $("#txtSexo").val("");
};