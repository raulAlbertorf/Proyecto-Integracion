--DELIMITER $$

DROP PROCEDURE IF EXISTS sp_ubicacion_crear $$

CREATE PROCEDURE sp_ubicacion_crear(
	inLatitude FLOAT( 10, 6 ),
  	inLongitude FLOAT( 10, 6 ),
    inDelegacion VARCHAR(256),
    inCodigoPostal INT,
	OUT outId BIGINT
    
)

BEGIN 
	INSERT INTO Ubicacion
    (Latitude, Longitude, Delegacion, CodigoPostal)
    VALUES
    (inLatitude, inLongitude, inDelegacion, inCodigoPostal);
	SET outId = LAST_INSERT_ID();
END
$$