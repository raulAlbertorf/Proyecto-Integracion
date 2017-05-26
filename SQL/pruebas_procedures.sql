SELECT * FROM reportit_api.cuenta;
SELECT * FROM reportit_api.perfil;
SELECT * FROM reportit_api.reporte;
SELECT * FROM reportit_api.ubicacion;
SELECT * FROM reportit_api.perfil_reporte;


CALL sp_cuenta_crear("email6@hotmail.com", "contrasena");
CALL sp_cuenta_seleccionar("email6@hotmail.com");
CALL sp_cuenta_modificar("email6@hotmail.com","nuevaContrasena");

CALL sp_perfil_crear("NombreN","ImagenN","MEX",  "email6@hotmail.com", 1, @perfil);
SELECT @perfil;
CALL sp_perfil_seleccionar(@perfil);
CALL sp_perfil_modificar(@perfil, "NombreNM","ImagenNM","CHL",  "email6@hotmail.com", 1);

CALL sp_ubicacion_crear(12.121212, 23.232323, @ubicacion);
CALL sp_ubicacion_seleccionar(@ubicacion);
CALL sp_ubicacion_modificar(@ubicacion, 0.0, 0.0);
CALL sp_ubicacion_eliminar(@ubicacion);
CALL sp_reporte_crear(@perfil, now(), 2, "Descripcion NM", @ubicacion, @reporte);
CALL sp_reporte_seleccionar(@reporte);
CALL sp_reporte_modificar(@reporte, @perfil, now(), 3, "DescripcionNueva", @ubicacion, @ultimamodificacion);
CALL sp_reporte_eliminar(@reporte);
SELECT @ultimamodificacion;

SELECT @reporte;
SELECT @salida;
CALL sp_cuenta_eliminar("email6@hotmail.com");
CALL sp_ubicacion_eliminar(@ubicacion);
CALL sp_reporte_eliminar(@reporte);
CALL sp_perfil_eliminar(@perfil);


