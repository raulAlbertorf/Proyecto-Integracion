--Delimiter $$
DROP PROCEDURE IF EXISTS sp_Reporte_Seleccionar_Reportes_Termino_Descripcion $$
CREATE PROCEDURE sp_Reporte_Seleccionar_Reportes_Termino_Descripcion (
	inPalabra VARCHAR(255),
    inPage int,
	inCantResult int
)
BEGIN
SELECT 
 	r.Id			AS 	Reporte_Id,
    r.Descripcion	AS 	Reporte_Descripcion,
    r.Fecha			AS	Reporte_Fecha,
    r.Incidente		AS 	Reporte_Incidente,
    r.Perfil_Id		AS	Perfil_Id,
    r.Ubicacion_Id  AS  Ubicacion_Id,
    p.Nombre		AS	Perfil_Nombre,
    p.UrlImagen		AS	Perfil_UrlImagen,
    p.Cuenta_Email	AS	Cuenta_Email,
    c.Contrasena	AS	Cuenta_Contrasena,
    u.Latitude 		AS	Ubicacion_Latitud,
    u.Longitude		AS	Ubicacion_Longitud,
    u.Delegacion	AS	Ubicacion_Direccion
    
    
FROM 
    reporte		AS r
INNER JOIN perfil AS p
	ON p.Id = r.Perfil_Id
INNER JOIN ubicacion AS u
	ON u.Id = r.Ubicacion_Id
INNER JOIN cuenta AS c
	ON p.Cuenta_Email =  c.Email
    WHERE
    r.Descripcion LIKE CONCAT('%', SUBSTRING_INDEX(SUBSTRING_INDEX( inPalabra , ' ', 2 ),' ',1) , '%') 
	ORDER BY r.Fecha desc
    LIMIT inPage, inCantResult;
    
    
    
END $$
 