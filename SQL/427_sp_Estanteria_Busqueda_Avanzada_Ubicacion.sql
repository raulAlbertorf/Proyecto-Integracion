--Delimiter $$
DROP PROCEDURE IF EXISTS sp_Estanteria_Busqueda_Avanzada_Ubicacion $$

CREATE PROCEDURE sp_Estanteria_Busqueda_Avanzada_Ubicacion (
	inPalabra 		varchar(255),
    inFecha			varchar(10),
    inIncidente		int,
    inDireccion		varchar(255),
	inPerfil		varchar(20),
    inUbicacion_Latitude float(10,6),
    inUbicacion_Longitude float(10,6),
    inRadio	int,
    inPage 			int,
	inCantResult 	int
)
BEGIN
	SELECT DISTINCT
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
		ubicacion AS u,
		perfil AS p,
		reporte AS r,
        cuenta AS c
	WHERE
		c.Email = p.Cuenta_Email
        AND
		u.Id = r.Ubicacion_Id
		AND
		r.Perfil_Id = p.Id
		AND
		(
			( 6371 * acos( cos( radians(inUbicacion_Latitude) ) * cos( radians( u.Latitude ) ) * cos( radians( u.Longitude ) - radians(inUbicacion_Longitude) ) + sin( radians(inUbicacion_Latitude) ) * sin( radians( u.Latitude ) ) ) ) <= inRadio AND
			u.Delegacion LIKE CONCAT('%', SUBSTRING_INDEX(SUBSTRING_INDEX( inDireccion , ' ', 2 ),' ',1) , '%') 
			Or
		    r.Descripcion LIKE CONCAT('%', SUBSTRING_INDEX(SUBSTRING_INDEX( inPalabra, ' ', -1 ),' ',2) , '%')
		    Or
            p.Nombre = inPerfil
            Or
		    CAST(r.Fecha AS DATE)= inFecha
		    Or
		    r.Incidente = inIncidente
		)
        ORDER BY r.Fecha DESC
        LIMIT inPage, inCantResult;
END
$$