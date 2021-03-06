CREATE TABLE IF NOT EXISTS Reporte(
	Id BIGINT UNSIGNED AUTO_INCREMENT NOT NULL PRIMARY KEY,
  	Perfil_Id BIGINT UNSIGNED NOT NULL,
    Fecha DATETIME,
    Incidente INT NOT NULL,
    Descripcion TEXT,
    Ubicacion_Id BIGINT UNSIGNED NOT NULL,
    UltimaModificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  	FOREIGN KEY (Perfil_Id) REFERENCES Perfil(Id) ON DELETE CASCADE,
    FOREIGN KEY (Ubicacion_Id) REFERENCES Ubicacion(Id) ON DELETE RESTRICT
);