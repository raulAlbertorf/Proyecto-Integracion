--Delimiter $$
DROP PROCEDURE IF EXISTS sp_Reporte_Seleccionar_Reportes_Termino_Ubicacion $$
CREATE PROCEDURE sp_Reporte_Seleccionar_Reportes_Termino_Ubicacion (
	inTermino VARCHAR(256),
    inUbicacion_Latitude float(10,6),
    inUbicacion_Longitude float(10,6),
    inPage int,
	inCantResult int,
    inRadio	INT
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
    ( 6371 * acos( cos( radians(inUbicacion_Latitude) ) * cos( radians( U.Latitude ) ) * cos( radians( U.Longitude ) - radians(inUbicacion_Longitude) ) + sin( radians(inUbicacion_Latitude) ) * sin( radians( U.Latitude ) ) ) ) <= inRadio AND
    (r.Descripcion LIKE  CONCAT("%",inTermino,"%") 		OR
    u.Delegacion LIKE CONCAT('%', SUBSTRING_INDEX(SUBSTRING_INDEX( inTermino , ' ', 2 ),' ',1) , '%')
			OR
		    r.Descripcion LIKE CONCAT('%', SUBSTRING_INDEX(SUBSTRING_INDEX( inTermino, ' ', -1 ),' ',2) , '%')
		    OR
            p.Nombre = inTermino
            OR
		    CAST(r.Fecha AS DATE)= inTermino)
	ORDER BY r.Fecha desc
    LIMIT inPage, inCantResult;
    
    
    
END $$
 