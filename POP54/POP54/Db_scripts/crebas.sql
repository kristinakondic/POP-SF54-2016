-- crebas.sql
CREATE TABLE FurnitureType (
	ID INT PRIMARY KEY IDENTITY(1,1),
	Namee VARCHAR(80),
	Deleted BIT
)

CREATE TABLE Furniture (
	ID INT PRIMARY KEY IDENTITY(1,1),
	FurnitureTypeId INT,
	Namee VARCHAR(100),
	ProductCode VARCHAR(20),
	Quantity INT,
	Price NUMERIC(9,2),
	Deleted BIT
	FOREIGN KEY (FurnitureTypeId) REFERENCES FurnitureType(ID)
)