--DELIMITER $$

DROP PROCEDURE IF EXISTS sp_perfil_crear $$

CREATE PROCEDURE sp_perfil_crear(
	inNombre VARCHAR(256),
	inUrlImagen VARCHAR(256),
	inEmail VARCHAR(256),
    inUbicacion BIGINT UNSIGNED,
	OUT outId BIGINT
)
BEGIN
	INSERT INTO Perfil 
		(Nombre,UrlImagen,Cuenta_Email, Ubicacion_Id)
	VALUES
		(inNombre,inUrlImagen,inEmail, inUbicacion);
	SET outId = LAST_INSERT_ID();
END
$$
 