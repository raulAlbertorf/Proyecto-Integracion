//Mostrar solo Buscador Todo
$('#btn_all').on('click', function () {
    $('#collapseFecha').collapse('hide');
    $('#collapseDireccion').collapse('hide');
    $('#collapsePalabra').collapse('hide');
    $('#collapseIncidente').collapse('hide');
    $('#collapseMiUbicacion').collapse('hide');
})

//Mostrar solo Buscador Direcciòn
$('#btn_direccion').on('click', function () {
    $('#collapseFecha').collapse('hide');
    $('#collapseAll').collapse('hide');
    $('#collapsePalabra').collapse('hide');
    $('#collapseIncidente').collapse('hide');
    $('#collapseMiUbicacion').collapse('hide');
})


//Mostrar solo Buscador Fecha
$('#btn_fecha').on('click', function () {
    $('#collapseAll').collapse('hide');
    $('#collapseDireccion').collapse('hide');
    $('#collapsePalabra').collapse('hide');
    $('#collapseIncidente').collapse('hide');
    $('#collapseMiUbicacion').collapse('hide');
})


//Mostrar solo Buscador Palabra Clave
$('#btn_palabrac').on('click', function () {
    $('#collapseFecha').collapse('hide');
    $('#collapseDireccion').collapse('hide');
    $('#collapseAll').collapse('hide');
    $('#collapseIncidente').collapse('hide');
    $('#collapseMiUbicacion').collapse('hide');
})



//Mostrar solo Buscador Incidente
$('#btn_incidente').on('click', function () {
    $('#collapseFecha').collapse('hide');
    $('#collapseDireccion').collapse('hide');
    $('#collapsePalabra').collapse('hide');
    $('#collapseAll').collapse('hide');
    $('#collapseMiUbicacion').collapse('hide');
})

//Mostrar solo Buscador Incidente
$('#btn_mi_ubicacion').on('click', function () {
    $('#collapseFecha').collapse('hide');
    $('#collapseDireccion').collapse('hide');
    $('#collapsePalabra').collapse('hide');
    $('#collapseAll').collapse('hide');
    $('#collapseIncidente').collapse('hide');
})