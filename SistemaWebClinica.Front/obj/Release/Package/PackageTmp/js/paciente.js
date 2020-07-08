
// variables globales
var tabla, data;
// variables globales

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
    tabla = $("#tbl_pacientes").DataTable();
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
            '<Button value="Actualizar" title="Actualizar" class="btn btn-primary btn-xs btn-edit" data-target="#editmodal" data-toggle="modal"><i class="fa fa-pencil-square-o fa-lg" aria-hidden="true"></i></button>&nbsp;' +
            '<Button value="Eliminar" title="Eliminar" class="btn btn-danger btn-xs btn-delete"><i class="fa fa-trash-o fa-lg" aria-hidden="true"></i></button>'
            //((data[i].estado==true)? "ACTIVO" : "INACTIVO")
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

function updateDataAjax() {
    var obj = JSON.stringify({ id: JSON.stringify(data[0]), direccion: $("#txtModalDireccion").val()});

    $.ajax({
        type: "POST",
        url: "GestionarPaciente.aspx/ActualizarDatosPaciente",
        data: obj,
        dataType: "json",
        contentType: 'application/json; chartset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            if (response.d) {
                alert("Registro actualizado con exito");
            }
            else {
                alert("Problemas para actualizar...")
            }
        }
    });
}

// evento click boton actualizar registro
$(document).on('click', '.btn-edit', function (e) {
    e.preventDefault();
    var row = $(this).parent().parent()[0];
    data = tabla.fnGetData(row);
    fillDataEditModal();
});

// evento click boton eliminar registro
$(document).on('click', '.btn-delete', function (e) {
    e.preventDefault();
    var row = $(this).parent().parent()[0];
    var data = tabla.fnGetData(row);
    console.log(data);
});

//Carga datos para edición en modal
function fillDataEditModal() {
    $("#txtFullName").val(data[1] + " " + data[2]);
    $("#txtModalDireccion").val(data[7]);
}

//Enviar informacion actualizada al servidor
$("#btnactualizar").click(function (e) {
    e.preventDefault();
    updateDataAjax();
})

//LLamado a la funcion de ajax al cargar el documento
sendDataAjax();