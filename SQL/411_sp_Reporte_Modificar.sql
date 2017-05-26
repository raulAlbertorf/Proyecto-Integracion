--DELIMITER $$

DROP PROCEDURE IF EXISTS sp_reporte_modificar $$

CREATE PROCEDURE sp_reporte_modificar(
	inId BIGINT,
    inPerfil_Id BIGINT UNSIGNED,
    inFecha DATETIME,
    inIncidente INT,
	inDescripcion TEXT,
    inUbicacion BIGINT UNSIGNED,
    OUT outUltimaModificacion DATETIME
)
BEGIN
	UPDATE
		Reporte 
	SET
			Perfil_Id = inPerfil_Id,
			Fecha = inFecha,
			Incidente = inIncidente,
            Descripcion = inDescripcion, 
            Ubicacion_Id = inUbicacion,
            UltimaModificacion = CURRENT_TIMESTAMP	
	WHERE 
		Id = inId;
	SET outUltimaModificacion = CURRENT_TIMESTAMP;
END
$$
