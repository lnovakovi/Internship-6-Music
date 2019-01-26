CREATE DATABASE MUSIC
BEGIN TRANSACTION

CREATE TABLE Artists
( ArtistId INT  IDENTITY (1,1) PRIMARY KEY,
Name NVARCHAR(30) NOT NULL,
Nationality NVARCHAR(20) NOT NULL
)

CREATE TABLE Albums
( AlbumId INT IDENTITY(1,1) PRIMARY KEY ,
ArtistId INT not null,
Name NVARCHAR(40) NOT NULL,
YearOfIssue INT NOT NULL,
)

CREATE TABLE Songs
( SongId INT IDENTITY(1,1) PRIMARY KEY ,
Name NVARCHAR(50) NOT NULL,
Duration time NOT NULL
)

CREATE TABLE AlbumSongs
(
AlbumId INT NOT NULL,
SongId INT NOT NULL
)
COMMIT

BEGIN TRANSACTION 
ALTER TABLE Albums
ADD FOREIGN KEY (ArtistId) REFERENCES Artists(ArtistId)

ALTER TABLE AlbumSongs
ADD FOREIGN KEY (AlbumId) REFERENCES Albums(AlbumId)

ALTER TABLE AlbumSongs
ADD FOREIGN KEY (SongId) REFERENCES Songs(SongId)

ALTER TABLE Songs
ALTER COLUMN Duration time;

COMMIT

BEGIN TRANSACTION
INSERT INTO Artists VALUES
('Lopez Jennifer','American'),
('Furler Sia','Australian'),
('Guetta David','French')

INSERT INTO Albums VALUES
(3,'Nothing but the Beat',2011),
(3,'One Love',2009),
(2,'This is Acting',2016),
(2, '1000 forms of fear',2014),
(1,'Love?',2011),
(1,'Brave',2007)
--> David Guetta
INSERT INTO Songs VALUES
('When Love Takes Over', '00:03:10'),
('Gettin Over', '00:03:10'),
('Memories','00:03:30'),
('Missing You','00:03:07'),
('Where Them Girls At','00:03:47'),
('Where Them Girls At','00:03:47'),
('Without You','00:03:31'),
('Titanium','00:04:06'),
('I Can Only Imagine','00:03:55'),
('Just One Last Time','00:04:16'),
--> Sia Furler
('Bird Set Free','00:04:12'),
('Alive','00:04:23'),
('One Million Bullets','00:04:12'),
('Move Your Body','00:04:07'),
('Cheap Thrills','00:03:31'),
('Chandelier','00:03:36'),
('Big Girls Cry','00:03:31'),
('Burn The Pages','00:03:15'),
('Eye of the Needle','00:04:09'),
('Fair Game','00:03:52'),
-->Jennifer
('On the Floor','00:03:52'),
('Papi','00:03:35'),
('Hypnotico','00:03:00'),
('One Love','00:04:21'),
('Unit It Beats No More','00:03:38'),
('Stay Together','00:03:30'),
('Forever','00:03:40'),
('Do It Well','00:03:06'),
('Gotta Be There','00:03:58'),
('The Way It Is','00:03:08')

INSERT INTO AlbumSongs VALUES
(1,1),(1,2),(1,3),(1,4),(1,5),
(2,6),(2,7),(2,8),(2,9),(2,10),
(3,11),(3,12),(3,13),(3,14),(3,15),
(4,16),(4,17),(4,18),(4,19),(4,20),
(5,21),(5,22),(5,23),(5,24),(5,25),
(6,26),(6,27),(6,28),(6,29),(6,30)

COMMIT

