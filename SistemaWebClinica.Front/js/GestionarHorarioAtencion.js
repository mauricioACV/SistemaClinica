//variables globales
var tabla;

//acciones al cargar pagina
iniciaDataTable();

//Iniciar timepicker y date
$("[data-mask]").inputmask();
$(".timepicker").timepicker({ showInputs: false, showMeridian: false, minuteStep: 30 });

function iniciaDataTable() {
    tabla = $("#tbl_horarios").DataTable({
        "oLanguage": {
            "sInfo": "De un total de (_TOTAL_) registros, mostrando (_START_ al _END_)",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sSearch": "Buscar:",
            "oPaginate": {
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
        },
        "aaSorting": [[0, 'asc']],
        "bSort": true,
        "aoColumns": [
            { "bSortable": false },
            { "bSortable": false },
            null,
            null,
        ],
        bDestroy: true
    });
    tabla.fnSetColumnVis(0, false);
};

function llenarDatosMedico(obj) {
    $("#lblNombre").text(obj.Nombre);
    $("#lblApellidos").text(obj.ApPaterno.concat(" ".concat(obj.ApMaterno)));
    $("#lblEspecialidad").text(obj.Especialidad.Descripcion);
    $("#txtIdMedico").val(obj.IdMedico);
}

//agrega el horario en datatable pagina principal
function addRowDT(obj) {
    var fecha = moment(obj.Fecha).format('DD/MM/YYYY');

    tabla.fnAddData(
        [
            obj.IdHorarioAtencion,
            '<Button type="button" value="Actualizar" title="Actualizar" class="btn btn-primary btn-xs btn-edit" data-target="#editarHorario" data-toggle="modal"><i class="fa fa-pencil-square-o fa-lg" aria-hidden="true"></i></button>&nbsp;&nbsp;' +
            '<Button type="button" value="Eliminar" title="Eliminar" class="btn btn-danger btn-xs btn-delete"><i class="fa fa-trash-o fa-lg" aria-hidden="true"></i></button>',
            fecha,
            obj.Hora.HoraAtencion
        ]
    );
}

function listarHorarioMedico(idMedico) {

    var obj = JSON.stringify({ idMedico: idMedico });

    $.ajax({
        type: "POST",
        url: "GestionarHorarioAtencion.aspx/ListarHorarioMedico",
        data: obj,
        contentType: 'application/json; chartset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            //console.log("Exitoso!", data.d);
            tabla.fnClearTable();
            for (var i = 0; i < data.d.length; i++) {
                addRowDT(data.d[i]);
            }


        }
    });
}

function eliminaHorarioAjax(data) {

    var obj = JSON.stringify({ id: JSON.stringify(data) });
    //console.log(obj);
    $.ajax({
        type: "POST",
        url: "GestionarHorarioAtencion.aspx/EliminarHorarioAtencion",
        data: obj,
        dataType: "json",
        contentType: 'application/json; chartset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            if (response.d) {
                alert("Registro eliminado con exito");
            }
            else {
                alert("Problemas para actualizar...")
            }
        }
    });
};

function ActualizaHorarioAtencion() {
    var obj = JSON.stringify(
        {
            idMedico: $("#txtIdMedico").val(),
            idHorario: $("#txtIdHorario").val(),
            fecha: $("#txtEditarFecha").val(),
            hora: $("#txtEditarHora").val(),
        });

    $.ajax({
        type: "POST",
        url: "GestionarHorarioAtencion.aspx/ActualizarHorarioAtencion",
        data: obj,
        dataType: "json",
        contentType: 'application/json; chartset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            if (response.d) {
                listarHorarioMedico($("#txtIdMedico").val());
                alert("Registro actualizado con exito");
            }
            else {
                alert("Problemas para actualizar...")
            }
        }
    });
};

//Boton buscar medico
$("#btnBuscarMedico").on("click", function (event) {
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
                llenarDatosMedico(data.d);
                listarHorarioMedico(data.d.IdMedico);
                //console.log("Exitoso", data);
            }
        });
    }
    else {
        console.log("No ha ingresado rut")
    }
});

//boton agregar en modal horarios
$("#btnAgregar").on("click", function (event) {
    event.preventDefault();

    // obtener valores del modal
    var fecha, hora, idMedico;
    fecha = $("#txtFecha").val();
    hora = $("#txtHoraInicio").val();
    idMedico = $("#txtIdMedico").val();

    if (fecha.length > 0 && hora.length > 0) {
        var obj = JSON.stringify({ fecha: fecha, hora: hora, idMedico: idMedico });

        //LLamada ajax
        $.ajax({
            type: "POST",
            url: "GestionarHorarioAtencion.aspx/AgregarHorario",
            data: obj,
            contentType: 'application/json; chartset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                console.log("Exitoso!", data.d);
                //cerrar modal
                $("#AgregarHorario").modal('toggle');
                addRowDT(data.d);

            }
        });
    }
    else {
        console.log("Ingrese los datos requeridos");
    }

});

// evento click boton eliminar Horario
$(document).on('click', '.btn-delete', function (e) {
    e.preventDefault();
    var row = $(this).parent().parent()[0];
    var dataRow = tabla.fnGetData(row);

    //paso1: enviar id por medio de ajax
    eliminaHorarioAjax(dataRow[0]);

    //paso2: renderizar el datatable
    listarHorarioMedico($("#txtIdMedico").val());
    
});

// evento click boton editar Horario en modal
$(document).on('click', '.btn-edit', function (e) {
    e.preventDefault();
    var row = $(this).parent().parent()[0];
    var dataRow = tabla.fnGetData(row);
    pasarDatosModalActualizar(dataRow);

});

function pasarDatosModalActualizar(data) {
    $("#txtEditarFecha").val(data[2]);
    $("#txtEditarHora").val(data[3]);
    $("#txtIdHorario").val(data[0]);
};

$("#btnEditar").click(function (e){
    e.preventDefault();
    ActualizaHorarioAtencion();
});