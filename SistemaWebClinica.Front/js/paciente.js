
function templateRow() {
    var template = "<tr>";
    template += ("<td>" + "123" + "</td>");
    template += ("<td>" + "123" + "</td>");
    template += ("<td>" + "123" + "</td>");
    template += ("<td>" + "123" + "</td>");
    template += ("<td>" + "123" + "</td>");
    template += ("<td>" + "123" + "</td>");
    template += ("<td>" + "123" + "</td>");
    template += ("</tr>");
    return template;
}

function addRow() {
    var template = templateRow();
    for (var i = 0; i < 10; i++) {
        $("#tbl_body_table").append(template);
    }
}

function addRowDT(data) {
    var tabla = $("#tbl_pacientes").DataTable();
    for (var i = 0; i < data.length; i++) {
        tabla.fnAddData([
            data[i].IdPaciente,
            data[i].Nombres,
            data[i].ApPaterno,
            data[i].ApMaterno,
            data[i].Edad,
            ((data[i].Sexo=='M')? "MASCULINO" : "FEMENINO"),
            data[i].NroDocumento,
            data[i].Direccion,
            data[i].Telefono,
            ((data[i].estado==true)? "ACTIVO" : "INACTIVO")
        ]);
    }
}

function sendDataAjax() {
    $.ajax({
        type:"POST",
        url:"GestionarPaciente.aspx/ListarPacientes",
        data: {},
        contentType:'application/json; chartset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            //console.log(data.d);
            addRowDT(data.d);
        }
    });
}

//LLamado a la funcion de ajax al cargar el documento
sendDataAjax();