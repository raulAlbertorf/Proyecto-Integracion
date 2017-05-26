--DELIMITER $$

DROP PROCEDURE IF EXISTS sp_ubicacion_seleccionar $$

CREATE PROCEDURE sp_ubicacion_seleccionar(
  	inId BIGINT UNSIGNED
)

BEGIN 
	SELECT 
		Id,
		Latitude,
        Longitude,
        Delegacion,
        CodigoPostal
    FROM 
		Ubicacion
	WHERE 
		Id = inId ;
END
$$