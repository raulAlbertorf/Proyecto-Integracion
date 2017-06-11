--DELIMITER $$

DROP PROCEDURE IF EXISTS sp_reporte_seleccionar_perfil $$

CREATE PROCEDURE sp_reporte_seleccionar_perfil(
	inId_perfil BIGINT
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
		inId_perfil = Perfil_Id;
END
$$