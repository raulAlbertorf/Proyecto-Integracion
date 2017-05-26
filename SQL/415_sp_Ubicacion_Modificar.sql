--DELIMITER $$

DROP PROCEDURE IF EXISTS sp_ubicacion_modificar $$

CREATE PROCEDURE sp_ubicacion_modificar(
	inId 	BIGINT UNSIGNED,
	inLatitude FLOAT( 10, 6 ),
  	inLongitude FLOAT( 10, 6 ),
    inDelegacion VARCHAR(256),
    inCodigoPostal INT
    
)

BEGIN 
	UPDATE  
		Ubicacion
    SET
		Latitude 		= 	inLatitude,
        Longitude 		= 	inLongitude, 
        Delegacion 		=	inDelegacion,
		CodigoPostal 	=	inCodigoPostal
	WHERE 
		Id = inId;
END
$$