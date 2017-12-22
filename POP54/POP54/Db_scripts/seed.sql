-- seed.sql
INSERT INTO FurnitureType (Namee, Deleted) VALUES ('Polica', 0)
INSERT INTO FurnitureType (Namee, Deleted) VALUES ('Garnitura', 0)
INSERT INTO FurnitureType (Namee, Deleted) VALUES ('Stolica', 0)
INSERT INTO FurnitureType (Namee, Deleted) VALUES ('Krevet', 0)

INSERT INTO Furniture (FurnitureTypeId, Namee, ProductCode, Price, Quantity, Deleted) 
VALUES (1, 'Mila polica', 'UCJ65', 1253, 5, 0)

INSERT INTO Furniture (FurnitureTypeId, Namee, ProductCode, Price, Quantity, Deleted) 
VALUES (3, 'Stolica Sanja', 'DSC526', 5240, 16, 0)

INSERT INTO Furniture (FurnitureTypeId, Namee, ProductCode, Price, Quantity, Deleted) 
VALUES (2, 'Stoja garnitura', '5151LK', 9033, 2, 0)

INSERT INTO Furniture (FurnitureTypeId, Namee, ProductCode, Price, Quantity, Deleted) 
VALUES (4, 'Krevet ina', '652sa', 20001, 3, 0)