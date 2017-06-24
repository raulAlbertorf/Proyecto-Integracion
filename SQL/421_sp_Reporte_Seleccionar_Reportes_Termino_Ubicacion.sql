--Delimiter $$
DROP PROCEDURE IF EXISTS sp_Item_Seleccionar_Items_Termino_Ubicacion $$
CREATE PROCEDURE sp_Item_Seleccionar_Items_Termino_Ubicacion (
	inTermino VARCHAR(256),
    inUbicacion_Latitude float(10,6),
    inUbicacion_Longitude float(10,6),
    inRadio	INT,
    inOffset INT,
	inLimit INT
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
	CAST(r.Fecha AS date) = inTermino AND
    YEAR(r.Fecha) = inTermino)
	ORDER BY r.Fecha desc
    LIMIT
		inOffset, inLimit 
	;
    
    
    
END $$
 