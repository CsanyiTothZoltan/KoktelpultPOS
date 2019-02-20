USE [KoktelPOS];

-- Készlet tábla feltöltés

INSERT INTO [Keszlet] VALUES ('BacardiLight', 5.41, 20000);
INSERT INTO [Keszlet] VALUES ('BacardiBlack', 2.12, 20000);
INSERT INTO [Keszlet] VALUES ('CaptainMorganSpiced', 2.08, 22500);
INSERT INTO [Keszlet] VALUES ('AbsolutVodka', 5.12, 22500);
INSERT INTO [Keszlet] VALUES ('BeefeaterGin', 2.08, 20000);
INSERT INTO [Keszlet] VALUES ('SierraSilver', 2.25, 20000);
INSERT INTO [Keszlet] VALUES ('JackDaniels', 2, 25000);
INSERT INTO [Keszlet] VALUES ('TripleSec', 2.04, 15000);
INSERT INTO [Keszlet] VALUES ('Pitu', 2.06, 20000);
INSERT INTO [Keszlet] VALUES ('MartiniExtraDry', 2.02, 15000);
INSERT INTO [Keszlet] VALUES ('Baileys', 2.02, 17500);
INSERT INTO [Keszlet] VALUES ('Kahlua', 2.02, 17500);
INSERT INTO [Keszlet] VALUES ('Cointreau', 2.06, 25000);
INSERT INTO [Keszlet] VALUES ('CremeDeCassis', 2.02, 17500);
INSERT INTO [Keszlet] VALUES ('PeachTree', 2.04, 15000);
INSERT INTO [Keszlet] VALUES ('HungariaExtraDry', 10.1, 10000);
INSERT INTO [Keszlet] VALUES ('CocaCola', 11, 2000);
INSERT INTO [Keszlet] VALUES ('KinleyTonic', 10.3, 2000);
INSERT INTO [Keszlet] VALUES ('KinleyGinger', 10.1, 2000);
INSERT INTO [Keszlet] VALUES ('Narancsle', 10.9, 2000);
INSERT INTO [Keszlet] VALUES ('Ananaszle', 11.1, 2000);
INSERT INTO [Keszlet] VALUES ('Afonyale', 10.2, 2000);
INSERT INTO [Keszlet] VALUES ('Paradicsomle', 10.2, 2000);


-- Receptura tábla feltöltése

INSERT INTO [Receptura] VALUES ('CubaLibre', 1800, 'BacardiLight', 0.06, 'CocaCola', 0.15, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('LongIslandIcedTea', 3600, 'BacardiLight', 0.02, 'AbsolutVodka', 0.02, 'BeefeaterGin', 0.02, 'SierraSilver', 0.02, 'TripleSec', 0.02, 'CocaCola', 0.10, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('Margarita', 2200, 'SierraSilver', 0.04, 'Cointreau', 0.02, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('Mojito', 1800, 'BacardiLight', 0.06, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('Bellini', 1800, 'HungariaExtraDry', 0.10, 'PeachTree', 0.02, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('KirRoyal', 1800, 'HungariaExtraDry', 0.10, 'CremeDeCassis', 0.02, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('Mimosa', 1800, 'HungariaExtraDry', 0.10, 'Narancsle', 0.05, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('Kamikaze', 2200, 'AbsolutVodka', 0.06, 'Cointreau', 0.02, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('B52', 2200, 'Baileys', 0.02, 'Kahlua', 0.02, 'Cointreau', 0.02, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('Caipirinha', 2200, 'Pitu', 0.06, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('Cosmopolitan', 2500, 'AbsolutVodka', 0.04, 'TripleSec', 0.02, 'Afonyale', 0.05, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('SexOnTheBeach', 2500, 'AbsolutVodka', 0.04, 'PeachTree', 0.02, 'Narancsle', 0.10, 'Afonyale', 0.05, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('PinaColada', 2200, 'BacardiLight', 0.06, 'Ananaszle', 0.15, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('BloodyMary', 1800, 'AbsolutVodka', 0.06, 'Paradicsomle', 0.10, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('Daiquiri', 1800, 'BacardiLight', 0.06, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('WhiskeySour', 2200, 'JackDaniels', 0.06, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('MaiTai', 2500, 'BacardiLight', 0.02, 'BacardiBlack', 0.02, 'CaptainMorganSpiced', 0.02, 'Ananaszle', 0.10, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('TequilaSunrise', 1800, 'SierraSilver', 0.06, 'Narancsle', 0.10, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('Martini', 2500, 'BeefeaterGin', 0.08, 'MartiniExtraDry', 0.02, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('GinFizz', 1800, 'BeefeaterGin', 0.06, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('WhiteRussian', 2200, 'AbsolutVodka', 0.04, 'Kahlua', 0.02, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);
INSERT INTO [Receptura] VALUES ('Satu', 2500, 'CaptainMorganSpiced', 0.06, 'KinleyGinger', 0.05, '', 0, '', 0, '', 0, '', 0, '', 0, '', 0);