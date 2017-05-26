--Delimiter $$
DROP PROCEDURE IF EXISTS sp_cuenta_crear $$

CREATE PROCEDURE sp_cuenta_crear(
	inEmail VARCHAR(256),
	inContrasena VARCHAR(256)
)

BEGIN
	INSERT INTO Cuenta
		(Email, Contrasena)
	VALUES
		(inEmail,inContrasena);
END
$$
