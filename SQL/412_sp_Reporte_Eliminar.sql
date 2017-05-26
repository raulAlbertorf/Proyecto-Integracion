--DELIMITER $$

DROP PROCEDURE IF EXISTS sp_reporte_eliminar $$

CREATE PROCEDURE sp_reporte_eliminar(
	inId BIGINT
)
BEGIN
	DELETE FROM 
			Reporte 
	WHERE 
		inId = Id;
END
$$