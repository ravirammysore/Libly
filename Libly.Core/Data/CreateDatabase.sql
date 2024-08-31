USE master;
GO

CREATE DATABASE LibraryDB;
GO

USE LibraryDB;
GO

CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    CreatedOn DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedOn DATETIME NULL
);
GO

INSERT INTO Categories (Name)
VALUES ('Fiction'), ('Science Fiction');
GO

CREATE TABLE Books (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Dop DATETIME NOT NULL,
    CategoryId INT NOT NULL,
    CreatedOn DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedOn DATETIME NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);
GO

INSERT INTO Books (Title, Dop, CategoryId)
VALUES 
('The Great Gatsby', '1925-04-10', 1),
('To Kill a Mockingbird', '1960-07-11', 1),
('1984', '1949-06-08', 2),
('Pride and Prejudice', '1813-01-28', 1);
GO
