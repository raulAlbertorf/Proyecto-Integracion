--DELIMITER $$

DROP PROCEDURE IF EXISTS sp_reporte_seleccionar $$

CREATE PROCEDURE sp_reporte_seleccionar(
	inId BIGINT
)
BEGIN
	SELECT 	
			Id,
			Perfil_Id, 
			Fecha,
			Incidente,
            Descripcion,
            Ubicacion_Id,
            UltimaModificacion
	FROM 
		Reporte 
	WHERE 
		inId = Id;
END
$$