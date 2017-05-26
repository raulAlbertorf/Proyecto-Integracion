--DELIMITER $$
DROP PROCEDURE IF EXISTS sp_cuenta_eliminar $$

CREATE PROCEDURE sp_cuenta_eliminar(
	inEmail VARCHAR(256)
)
BEGIN 
	DELETE FROM Cuenta
		WHERE 
			Email = inEmail;

END 
$$