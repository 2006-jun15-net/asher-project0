CREATE TABLE Customer
(customerID INT IDENTITY(1, 1) NOT NULL, 
 FirstName  NVARCHAR(200) NOT NULL, 
 LastName   NVARCHAR(200) NOT NULL, 
 UserName   NVARCHAR(26)
 PRIMARY KEY NOT NULL
);
CREATE TABLE Location
(locationID INT IDENTITY(1, 1) NOT NULL, 
 Address    NVARCHAR(200) NOT NULL PRIMARY KEY, 
 City       NVARCHAR(200), 
 State      NVARCHAR(200)
);
CREATE TABLE Inventory
(inventoryID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
 inStock     INT NOT NULL
);
CREATE TABLE Merchandise
(locationAddress NVARCHAR(200) FOREIGN KEY REFERENCES Location(Address) NOT NULL, 
 inventoryID     INT FOREIGN KEY REFERENCES Inventory(inventoryID) NOT NULL
);
CREATE TABLE PlacedOrders
(orderID          INT IDENTITY(1, 1) NOT NULL, 
 CustomerUsername NVARCHAR(26) FOREIGN KEY REFERENCES Customer(UserName) NOT NULL, 
 locationAddress  NVARCHAR(200) FOREIGN KEY REFERENCES Location(Address) NOT NULL, 
 TimeOrdered      DATETIME2 NOT NULL, 
 TotalAmount      DECIMAL(10, 2) NOT NULL, 
 PRIMARY KEY(TimeOrdered, CustomerUsername)
);
CREATE TABLE Product
(productID   INT IDENTITY(1, 1) NOT NULL, 
 Name        NVARCHAR(200) NOT NULL PRIMARY KEY, 
 Price       DECIMAL(10, 2) NOT NULL, 
 maxPerOrder INT NOT NULL
);
CREATE TABLE Purchased
(timeOrdered      DATETIME2 NOT NULL, 
 CustomerUsername NVARCHAR(26) NOT NULL, 
 productName      NVARCHAR(200) FOREIGN KEY REFERENCES Product(Name), 
 FOREIGN KEY(timeOrdered, CustomerUsername) REFERENCES PlacedOrders(TimeOrdered, 
                                                                    CustomerUsername)
);
CREATE TABLE Stock
(inventoryID INT FOREIGN KEY REFERENCES Inventory(inventoryID), 
 productName NVARCHAR(200) FOREIGN KEY REFERENCES Product(Name)
);  
INSERT INTO Location
(Address, 
 City, 
 State
)
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
('7147 Grand Avenue', 
 'Los Angeles', 
 'California'
),
('7291 Primrose Road', 
 'New Orleans', 
 'Louisiana'
);
INSERT INTO Product
(Name, 
 Price, 
 maxPerOrder
)
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
('Jackbox Partypack 6', 
 30.00, 
 1
),
('Xbox One Controller', 
 30.00, 
 6
),
('Xbox Elite Controller', 
 150.00, 
 4
),
('Console Headset', 
 20.00, 
 10
),
('USB Wireless Mouse', 
 25.00, 
 7
),
('Alienware Desktop', 
 2000.00, 
 2
),
('PC Monitor', 
 150.00, 
 5
);
INSERT INTO Inventory(inStock)
VALUES(45), (34), (76), (82), (235), (175), (24), (13), (34), (72), (75), (96), (23), (65), (69), (62), (52), (16), (73), (49), (52), (61), (84), (93), (58), (61), (77), (69), (96), (81), (70), (126), (66), (84), (99), (51), (47), (39), (40), (20), (33), (73), (72), (93), (87), (96), (18), (25), (29), (32), (76), (56), (65), (38), (97), (19), (22), (39), (42), (45), (84), (90), (124), (53), (67), (83), (38), (71), (40), (59);
INSERT INTO Merchandise
(locationAddress, 
 inventoryID
)
VALUES
('624 Central Dr.', 
 1
),
('624 Central Dr.', 
 2
),
('624 Central Dr.', 
 3
),
('624 Central Dr.', 
 4
),
('624 Central Dr.', 
 5
),
('624 Central Dr.', 
 6
),
('624 Central Dr.', 
 7
),
('624 Central Dr.', 
 8
),
('624 Central Dr.', 
 9
),
('624 Central Dr.', 
 10
),
('624 Central Dr.', 
 11
),
('624 Central Dr.', 
 12
),
('624 Central Dr.', 
 13
),
('624 Central Dr.', 
 14
),
('835 Oakwood Blvd.', 
 15
),
('835 Oakwood Blvd.', 
 16
),
('835 Oakwood Blvd.', 
 17
),
('835 Oakwood Blvd.', 
 18
),
('835 Oakwood Blvd.', 
 19
),
('835 Oakwood Blvd.', 
 20
),
('835 Oakwood Blvd.', 
 21
),
('835 Oakwood Blvd.', 
 22
),
('835 Oakwood Blvd.', 
 23
),
('835 Oakwood Blvd.', 
 24
),
('835 Oakwood Blvd.', 
 25
),
('835 Oakwood Blvd.', 
 26
),
('835 Oakwood Blvd.', 
 27
),
('835 Oakwood Blvd.', 
 28
),
('294 Harwood Dr.', 
 29
),
('294 Harwood Dr.', 
 30
),
('294 Harwood Dr.', 
 31
),
('294 Harwood Dr.', 
 32
),
('294 Harwood Dr.', 
 33
),
('294 Harwood Dr.', 
 34
),
('294 Harwood Dr.', 
 35
),
('294 Harwood Dr.', 
 36
),
('294 Harwood Dr.', 
 37
),
('294 Harwood Dr.', 
 38
),
('294 Harwood Dr.', 
 39
),
('294 Harwood Dr.', 
 40
),
('294 Harwood Dr.', 
 41
),
('294 Harwood Dr.', 
 42
),
('7147 Grand Avenue', 
 43
),
('7147 Grand Avenue', 
 44
),
('7147 Grand Avenue', 
 45
),
('7147 Grand Avenue', 
 46
),
('7147 Grand Avenue', 
 47
),
('7147 Grand Avenue', 
 48
),
('7147 Grand Avenue', 
 49
),
('7147 Grand Avenue', 
 50
),
('7147 Grand Avenue', 
 51
),
('7147 Grand Avenue', 
 52
),
('7147 Grand Avenue', 
 53
),
('7147 Grand Avenue', 
 54
),
('7147 Grand Avenue', 
 55
),
('7147 Grand Avenue', 
 56
),
('7291 Primrose Road', 
 57
),
('7291 Primrose Road', 
 58
),
('7291 Primrose Road', 
 59
),
('7291 Primrose Road', 
 60
),
('7291 Primrose Road', 
 61
),
('7291 Primrose Road', 
 62
),
('7291 Primrose Road', 
 63
),
('7291 Primrose Road', 
 64
),
('7291 Primrose Road', 
 65
),
('7291 Primrose Road', 
 66
),
('7291 Primrose Road', 
 67
),
('7291 Primrose Road', 
 68
),
('7291 Primrose Road', 
 69
),
('7291 Primrose Road', 
 70
);
INSERT INTO Stock
(inventoryID, 
 productName
)
VALUES
(1, 
 'Xbox One X'
),
(2, 
 'Playstation 4'
),
(3, 
 'Nintendo Switch'
),
(4, 
 'Halo 5'
),
(5, 
 'Dead Space'
),
(6, 
 'Spider-Man'
),
(7, 
 'Fire Emblem Three Houses'
),
(8, 
 'Jackbox Partypack 6'
),
(9, 
 'Xbox One Controller'
),
(10, 
 'Xbox Elite Controller'
),
(11, 
 'Console Headset'
),
(12, 
 'USB Wireless Mouse'
),
(13, 
 'Alienware Desktop'
),
(14, 
 'PC Monitor'
),
(15, 
 'Xbox One X'
),
(16, 
 'Playstation 4'
),
(17, 
 'Nintendo Switch'
),
(18, 
 'Halo 5'
),
(19, 
 'Dead Space'
),
(20, 
 'Spider-Man'
),
(21, 
 'Fire Emblem Three Houses'
),
(22, 
 'Jackbox Partypack 6'
),
(23, 
 'Xbox One Controller'
),
(24, 
 'Xbox Elite Controller'
),
(25, 
 'Console Headset'
),
(26, 
 'USB Wireless Mouse'
),
(27, 
 'Alienware Desktop'
),
(28, 
 'PC Monitor'
),
(29, 
 'Xbox One X'
),
(30, 
 'Playstation 4'
),
(31, 
 'Nintendo Switch'
),
(32, 
 'Halo 5'
),
(33, 
 'Dead Space'
),
(34, 
 'Spider-Man'
),
(35, 
 'Fire Emblem Three Houses'
),
(36, 
 'Jackbox Partypack 6'
),
(37, 
 'Xbox One Controller'
),
(38, 
 'Xbox Elite Controller'
),
(39, 
 'Console Headset'
),
(40, 
 'USB Wireless Mouse'
),
(41, 
 'Alienware Desktop'
),
(42, 
 'PC Monitor'
),
(43, 
 'Xbox One X'
),
(44, 
 'Playstation 4'
),
(45, 
 'Nintendo Switch'
),
(46, 
 'Halo 5'
),
(47, 
 'Dead Space'
),
(48, 
 'Spider-Man'
),
(49, 
 'Fire Emblem Three Houses'
),
(50, 
 'Jackbox Partypack 6'
),
(51, 
 'Xbox One Controller'
),
(52, 
 'Xbox Elite Controller'
),
(53, 
 'Console Headset'
),
(54, 
 'USB Wireless Mouse'
),
(55, 
 'Alienware Desktop'
),
(56, 
 'PC Monitor'
),
(57, 
 'Xbox One X'
),
(58, 
 'Playstation 4'
),
(59, 
 'Nintendo Switch'
),
(60, 
 'Halo 5'
),
(61, 
 'Dead Space'
),
(62, 
 'Spider-Man'
),
(63, 
 'Fire Emblem Three Houses'
),
(64, 
 'Jackbox Partypack 6'
),
(65, 
 'Xbox One Controller'
),
(66, 
 'Xbox Elite Controller'
),
(67, 
 'Console Headset'
),
(68, 
 'USB Wireless Mouse'
),
(69, 
 'Alienware Desktop'
),
(70, 
 'PC Monitor'
);