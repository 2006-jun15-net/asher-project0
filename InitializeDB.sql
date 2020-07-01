CREATE TABLE Customer
(CustomerID INT IDENTITY(1, 1) NOT NULL, 
 FirstName  NVARCHAR(200) NOT NULL, 
 LastName   NVARCHAR(200) NOT NULL, 
 UserName   NVARCHAR(26) UNIQUE NOT NULL,
 PRIMARY KEY(CustomerID)
);
CREATE TABLE Location
(LocationID INT IDENTITY(1, 1) NOT NULL, 
 Address    NVARCHAR(200) UNIQUE NOT NULL, 
 City       NVARCHAR(200) NOT NULL, 
 State      NVARCHAR(200) NOT NULL,
 PRIMARY KEY(LocationID)
);
CREATE TABLE Product
(ProductID   INT IDENTITY(1, 1) NOT NULL, 
 Name        NVARCHAR(200) UNIQUE NOT NULL, 
 Price       DECIMAL(10, 2) NOT NULL, 
 MaxPerOrder INT NOT NULL,
 PRIMARY KEY(ProductID)
);
CREATE TABLE Inventory
(InventoryID INT IDENTITY(1, 1) NOT NULL, 
 LocationID  INT FOREIGN KEY REFERENCES Location(LocationID) ON DELETE CASCADE ON UPDATE CASCADE, 
 ProductID   INT FOREIGN KEY REFERENCES Product(ProductID) ON DELETE CASCADE ON UPDATE CASCADE, 
 InStock     INT NOT NULL,
 PRIMARY KEY(InventoryID)
);
CREATE TABLE OrderHistory
(OrderHistoryID INT IDENTITY(1, 1) NOT NULL, 
 CustomerID     INT FOREIGN KEY REFERENCES Customer(CustomerID) ON DELETE CASCADE ON UPDATE CASCADE, 
 LocationID     INT FOREIGN KEY REFERENCES Location(LocationID) ON DELETE CASCADE ON UPDATE CASCADE, 
 TimeOrdered    DATETIME2 NOT NULL,
 PRIMARY KEY(OrderHistoryID)
);
CREATE TABLE Orders
(OrderID        INT IDENTITY(1, 1) NOT NULL, 
 ProductID      INT FOREIGN KEY REFERENCES Product(ProductID) ON DELETE CASCADE ON UPDATE CASCADE, 
 OrderHistoryID INT FOREIGN KEY REFERENCES OrderHistory(OrderHistoryID) ON DELETE CASCADE ON UPDATE CASCADE, 
 AmountOrdered  INT NOT NULL,
 PRIMARY KEY(OrderID)
);
INSERT INTO Location
(Address, City, State)
VALUES
('624 Central Dr.', 
 'Austin', 
 'Texas'
),
('835 Oakwood Blvd.', 
 'Chicago', 
 'Illinois'
),
('294 Harwood Dr.', 
 'New York City', 
 'New York'
),
('9162 Grand Avenue',
 'Houston',
 'Texas'
),
('361 Trinity Rd.',
 'Seattle',
 'Washington'
);
INSERT INTO Product
(Name, Price, MaxPerOrder)
VALUES
('Xbox One X', 
 500.00, 
 3
),
('Playstation 4', 
 550.00, 
 3
),
('Nintendo Switch', 
 500.00, 
 3
),
('Halo 5', 
 60.00, 
 5
),
('Dead Space', 
 20.00, 
 5
),
('Spider-Man', 
 60.00, 
 5
),
('Fire Emblem Three Houses', 
 60.00, 
 5
),
('Xbox Elite Controller', 
 150.00, 
 4
),
('Console Headset', 
 20.00, 
 10
),
('Alienware Desktop', 
 2000.00, 
 2
);
INSERT INTO Inventory
(LocationID, ProductID, InStock)
VALUES
(1, 1, 45), 
(1, 2, 34), 
(1, 3, 76), 
(1, 4, 82), 
(1, 5, 235), 
(1, 6, 175), 
(1, 7, 24), 
(1, 8, 13), 
(1, 9, 34), 
(1, 10, 72),  
(2, 1, 65), 
(2, 2, 69), 
(2, 3, 62), 
(2, 4, 52), 
(2, 5, 16), 
(2, 6, 73), 
(2, 7, 49), 
(2, 8, 52), 
(2, 9, 61), 
(2, 10, 84), 
(3, 1, 69), 
(3, 2, 96), 
(3, 3, 81), 
(3, 4, 70), 
(3, 5, 126), 
(3, 6, 66), 
(3, 7, 84), 
(3, 8, 99), 
(3, 9, 51), 
(3, 10, 47),
(4, 1, 69), 
(4, 2, 96), 
(4, 3, 81), 
(4, 4, 70), 
(4, 5, 126), 
(4, 6, 66), 
(4, 7, 84), 
(4, 8, 99), 
(4, 9, 51), 
(4, 10, 47),
(5, 1, 69), 
(5, 2, 96), 
(5, 3, 81), 
(5, 4, 70), 
(5, 5, 126), 
(5, 6, 66), 
(5, 7, 84), 
(5, 8, 99), 
(5, 9, 51), 
(5, 10, 47);
INSERT INTO Customer
(FirstName, LastName, UserName)
VALUES
('Asher', 
 'Williams', 
 'Trasher571'
),
('Michael', 
 'Beckett', 
 'AngryGamer19'
),
('Christian', 
 'Roberts', 
 'EpicConsole123'
),
('Alex', 
 'Smith', 
 'CoolR3pt4r'
),
('Luke', 
 'Skywalker', 
 'R3b3lJedi420'
);