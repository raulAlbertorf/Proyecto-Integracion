--DELIMITER $$

DROP PROCEDURE IF EXISTS sp_perfil_seleccionar $$

CREATE PROCEDURE sp_perfil_seleccionar(
	inId BIGINT
)
BEGIN
	SELECT 
		Id,Nombre,UrlImagen,Cuenta_Email, Ubicacion_Id
	FROM
		Perfil
	WHERE
		Id = inId;
END

$$