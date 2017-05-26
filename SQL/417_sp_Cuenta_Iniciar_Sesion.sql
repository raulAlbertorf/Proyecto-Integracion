--Delimiter $$
DROP PROCEDURE IF EXISTS sp_cuenta_inicio_sesion $$
CREATE PROCEDURE sp_cuenta_inicio_sesion(
	inEmail VARCHAR(256),
    inContrasena VARCHAR(256)
)
BEGIN 
	SELECT 
		Email,
        Contrasena
    FROM 
		Cuenta
	WHERE
		Contrasena = inContrasena AND
        Email = inEmail;
END $$