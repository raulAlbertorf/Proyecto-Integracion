--DELIMITER $$

DROP PROCEDURE IF EXISTS sp_perfil_seleccionar_email $$

CREATE PROCEDURE sp_perfil_seleccionar_email(
	inEmail VARCHAR(256)
)
BEGIN
	SELECT 
		Id,Nombre,UrlImagen,Cuenta_Email, Ubicacion_Id
	FROM
		Perfil
	WHERE
		Cuenta_Email = inEmail;
END

$$