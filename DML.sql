USE arq_per_db;
GO

-- Profesiones
INSERT INTO profesion (nombre, descripcion) VALUES
('Ingeniería de Sistemas', 'Desarrollo de software'),
('Medicina', 'Salud y clínica'),
('Arquitectura', 'Diseño y construcción');

-- Personas
INSERT INTO persona (cc, nombre, apellido, genero, edad) VALUES
(1010, 'Daniel', 'González', 'M', 20),
(2020, 'Ruth', 'Pérez', 'F', 21);

-- Teléfonos
INSERT INTO telefono (num, oper, dueno_cc) VALUES
('+57-3001111111', 'Claro', 1010),
('+57-3012222222', 'Tigo', 2020);

-- Estudios
INSERT INTO estudio (persona_cc, profesion_id, fecha, universidad) VALUES
(1010, 1, '2023-06-01', 'Pontificia Universidad Javeriana'),
(2020, 2, '2024-05-10', 'Universidad Nacional');
