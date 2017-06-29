--Delimiter $$
DROP PROCEDURE IF EXISTS sp_Estanteria_Buscar_All $$

CREATE PROCEDURE sp_Estanteria_Buscar_All (
	inTermino varchar(255),
    inPage int,
	inCantResult int
)
BEGIN
	SELECT DISTINCT
		r.Id as Reporte_Id,
        r.Perfil_Id AS Perfil_Id,
        r.fecha as FechaExpedicion,
        r.Incidente as Incidente,
        r.Descripcion as Descripcion,
        r.Ubicacion_Id as Ubicacion_Id,
        p.Nombre as Perfil_Nombre,
        r.UltimaModificacion as UltimaModificacion
		
	FROM
		ubicacion AS u,
		perfil AS p,
		reporte AS r
	WHERE
		 
		u.Id = r.Ubicacion_Id
		AND
		r.Perfil_Id = p.Id
		AND
		(
			u.Delegacion LIKE CONCAT('%', SUBSTRING_INDEX(SUBSTRING_INDEX( inTermino , ' ', 2 ),' ',1) , '%') 
			OR
		    r.Descripcion LIKE CONCAT('%', SUBSTRING_INDEX(SUBSTRING_INDEX( inTermino, ' ', -1 ),' ',2) , '%')
		    OR
            p.Nombre = inTermino
            OR
		    CAST(r.Fecha AS DATE)= inTermino
		    OR
		    r.Incidente = CAST( inTermino AS decimal)
		)
        ORDER BY r.Fecha DESC
        LIMIT inPage, inCantResult;
END
$$