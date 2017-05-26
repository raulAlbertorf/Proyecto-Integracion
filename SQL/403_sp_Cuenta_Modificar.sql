--Delimiter $$
DROP PROCEDURE IF EXISTS sp_cuenta_modificar $$

CREATE PROCEDURE sp_cuenta_modificar(
	inEmail VARCHAR(256),
	inContrasena VARCHAR(256)
)

BEGIN
	UPDATE Cuenta
	SET 
		Contrasena = inContrasena
	WHERE
		inEmail = Email;
END
$$
