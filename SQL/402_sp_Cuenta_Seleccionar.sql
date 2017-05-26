--Delimiter $$
DROP PROCEDURE IF EXISTS sp_cuenta_seleccionar $$

CREATE PROCEDURE sp_cuenta_seleccionar(
	inEmail VARCHAR(256)
)

BEGIN
	SELECT Email, Contrasena 
    FROM Cuenta
    WHERE inEmail = Email;
END
$$