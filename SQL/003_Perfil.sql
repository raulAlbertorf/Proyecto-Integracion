CREATE TABLE IF NOT EXISTS Perfil(
	Id BIGINT UNSIGNED AUTO_INCREMENT NOT NULL PRIMARY KEY,
    Nombre	VARCHAR(256),
    UrlImagen VARCHAR(256),
    Cuenta_Email VARCHAR(256) NOT NULL,
    Ubicacion_Id BIGINT UNSIGNED NOT NULL,
    FOREIGN KEY(Cuenta_Email) REFERENCES Cuenta(Email) ON DELETE CASCADE,
    FOREIGN KEY(Ubicacion_Id) REFERENCES Ubicacion(Id) ON DELETE RESTRICT
);