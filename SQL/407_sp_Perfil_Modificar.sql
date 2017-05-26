--DELIMITER $$

DROP PROCEDURE IF EXISTS sp_perfil_modificar $$

CREATE PROCEDURE sp_perfil_modificar(
	inId BIGINT UNSIGNED,
	inNombre VARCHAR(256),
	inUrl VARCHAR(256),
	inEmail VARCHAR(256),
    inUbicacion BIGINT UNSIGNED
    
)
BEGIN
	UPDATE Perfil 
	SET
	 	Nombre = inNombre,
	 	UrlImagen = inUrl,
	 	Cuenta_Email = inEmail,
        Ubicacion_Id = inUbicacion
	WHERE
		Id = inId;
END
$$