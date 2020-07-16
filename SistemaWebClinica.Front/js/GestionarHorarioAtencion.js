//variables globales
var tabla;

//acciones al cargar pagina
iniciaDataTable();

//Iniciar timepicker y date
$("[data-mask]").inputmask();
$(".timepicker").timepicker({ showInputs: false, showMeridian: false, minuteStep: 30 });

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
                console.log("Exitoso", data);
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
    $("#txtIdMedico").val(obj.IdMedico);
}

//boton agregar en modal horarios
$("#btnAgregar").on("click", function (event){
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

function iniciaDataTable() {
    tabla = $("#tbl_horarios").DataTable({
        "oLanguage": {
            "sInfo": "De un total de (_TOTAL_) registros, mostrando (_START_ al _END_)",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sSearch": "Buscar Registros:",
            "oPaginate": {
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
        },
        "aaSorting": [[0, 'asc']],
        "bSort": true,
        "aoColumns": [
            { "bSortable": false },
            null,
            null,
        ],
        bDestroy: true
    });
};

function addRowDT(obj) {
    var fecha = moment(obj.Fecha).format('DD/MM/YYYY');

    tabla.fnAddData(
        [
            '<Button type="button" value="Actualizar" title="Actualizar" class="btn btn-primary btn-xs btn-edit" data-target="#editmodal" data-toggle="modal"><i class="fa fa-pencil-square-o fa-lg" aria-hidden="true"></i></button>&nbsp;&nbsp;'+
            '<Button type="button" value="Eliminar" title="Eliminar" class="btn btn-danger btn-xs btn-delete"><i class="fa fa-trash-o fa-lg" aria-hidden="true"></i></button>',
            fecha,
            obj.Hora.HoraAtencion
        ]
    );
}
