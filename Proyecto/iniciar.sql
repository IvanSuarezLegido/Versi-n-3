DROP DATABASE IF EXISTS juego;
CREATE DATABASE juego;
USE juego;

CREATE TABLE Jugadores (
    ID int not null primary key,
    nombre VARCHAR(25),
    contrasenya VARCHAR(25)
);

CREATE TABLE Partida (
    ID int not null primary key,
    Fecha VARCHAR(25),
    HoraFinal VARCHAR(25),
    Turnos int,
    Ganador int, 
    foreign key (Ganador) references Jugadores(ID)
);

CREATE TABLE Participaciones (
    Jugador int,
    Partida int,
    Turnos int,
    foreign key (Jugador) references Jugadores(ID),
    foreign key (Partida) references Partida(ID)
);

CREATE TABLE RankingGanadores (
    Jugador int not null primary key,
    Wins int,
    foreign key (Jugador) references Jugadores(ID)
);

CREATE TABLE Cementerio (
    Jugador int not null primary key,
    Muertes int,
    foreign key (Jugador) references Jugadores(ID)
);


INSERT INTO Jugadores VALUES (1, 'Marc', 'zanahoria77');
INSERT INTO Jugadores VALUES (2, 'Xavi', 'patata89');
INSERT INTO Jugadores VALUES (3, 'Ivan', 'berenjena14');
INSERT INTO Jugadores VALUES (4, 'David', 'espinaca34');

INSERT INTO Partida VALUES (1, '28/02/2024', '14:00', 17, 1);
INSERT INTO Partida VALUES (2, '28/02/2024', '15:00', 33, 2);

INSERT INTO Participaciones VALUES (1, 1, 17);
INSERT INTO Participaciones VALUES (3, 1, 17);

INSERT INTO Participaciones VALUES (1, 2, 33);
INSERT INTO Participaciones VALUES (2, 2, 33);
INSERT INTO Participaciones VALUES (3, 2, 33);
INSERT INTO Participaciones VALUES (4, 2, 33);

INSERT INTO RankingGanadores VALUES (1, 1);
INSERT INTO RankingGanadores VALUES (2, 1);
INSERT INTO RankingGanadores VALUES (3, 0);
INSERT INTO RankingGanadores VALUES (4, 0);

INSERT INTO Cementerio VALUES (1, 1);
INSERT INTO Cementerio VALUES (3, 1);
