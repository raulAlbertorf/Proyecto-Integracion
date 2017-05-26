--DELIMITER $$

DROP PROCEDURE IF EXISTS sp_ubicacion_eliminar $$

CREATE PROCEDURE sp_ubicacion_eliminar(
  	inId BIGINT UNSIGNED
)

BEGIN 
	DELETE FROM  
		Ubicacion
	WHERE 
		inId = Id ;
END
$$