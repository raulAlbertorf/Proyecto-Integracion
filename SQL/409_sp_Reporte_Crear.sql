--DELIMITER $$

DROP PROCEDURE IF EXISTS sp_reporte_crear $$

CREATE PROCEDURE sp_reporte_crear(
	inPerfil_Id BIGINT UNSIGNED,
    inFecha DATETIME,
    inIncidente INT,
	inDescripcion TEXT,
    inUbicacion BIGINT UNSIGNED,
	OUT outId BIGINT
)
BEGIN
	INSERT INTO Reporte 
		(	Perfil_Id, 
			Fecha,
			Incidente,
            Descripcion,
            Ubicacion_Id)
	VALUES
		(	inPerfil_Id, 
			inFecha,
			inIncidente,
            inDescripcion,
            inUbicacion);
	SET outId = LAST_INSERT_ID();
END
$$
