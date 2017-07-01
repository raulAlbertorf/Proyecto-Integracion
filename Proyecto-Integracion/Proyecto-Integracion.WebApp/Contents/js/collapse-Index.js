//Mostrar solo Buscador Todo
$('#btn_all_index').on('click', function () {
    $('#collapseFecha-Index').collapse('hide');
    $('#collapseDireccion-Index').collapse('hide');
    $('#collapsePalabra-Index').collapse('hide');
    $('#collapseIncidente-Index').collapse('hide');
})

//Mostrar solo Buscador Direcciòn
$('#btn_direccion_index').on('click', function () {
    $('#collapseFecha-Index').collapse('hide');
    $('#collapseAll-Index').collapse('hide');
    $('#collapsePalabra-Index').collapse('hide');
    $('#collapseIncidente-Index').collapse('hide');
})


//Mostrar solo Buscador Fecha
$('#btn_fecha_index').on('click', function () {
    $('#collapseAll-Index').collapse('hide');
    $('#collapseDireccion-Index').collapse('hide');
    $('#collapsePalabra-Index').collapse('hide');
    $('#collapseIncidente-Index').collapse('hide');
})


//Mostrar solo Buscador Palabra Clave
$('#btn_palabrac_index').on('click', function () {
    $('#collapseFecha-Index').collapse('hide');
    $('#collapseDireccion-Index').collapse('hide');
    $('#collapseAll-Index').collapse('hide');
    $('#collapseIncidente-Index').collapse('hide');
})



//Mostrar solo Buscador Incidente
$('#btn_incidente_index').on('click', function () {
    $('#collapseFecha-Index').collapse('hide');
    $('#collapseDireccion-Index').collapse('hide');
    $('#collapsePalabra-Index').collapse('hide');
    $('#collapseAll-Index').collapse('hide');
})