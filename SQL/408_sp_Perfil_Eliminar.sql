--DELIMITER $$

DROP PROCEDURE IF EXISTS sp_perfil_eliminar $$

CREATE PROCEDURE sp_perfil_eliminar(
	inId BIGINT UNSIGNED
)
BEGIN
	DELETE FROM 
		Perfil 
	WHERE
		Id = inId;
END
$$