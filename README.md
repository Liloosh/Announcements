# Deployment Guide for Announcement App
This project consists of two main components:
1. **ASP.NET Web API** - The backend providing APIs for data access.
2. **Blazor App** - The frontend enabling user interactions through the interface.

## Steps to Deploy

### 1. Environment Setup

Ensure the following tools are installed:
- **.NET SDK**: Version 8.0.
- **SQL Server**
- **Visual Studio** or **Visual Studio Code** for development.

### 2. Database Setup

1. Run the script below to create some procedures, datatable, database. For example:
    ```sql
    CREATE DATABASE MyDatabase;
    GO
    
    USE MyDatabase;
    GO
    
    CREATE TABLE Announcements (
      Id INT IDENTITY(1,1) PRIMARY KEY,
      Title NVARCHAR(255) NOT NULL,
      Description NVARCHAR(MAX) NOT NULL,
      CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
      Status NVARCHAR(50) NOT NULL,
      Category NVARCHAR(100) NOT NULL,
      SubCategory NVARCHAR(100) NULL
    );
    GO

    CREATE PROCEDURE DeleteAnnouncement
      @Id INT
    AS
    BEGIN
        DELETE FROM Announcements WHERE Id = @Id;
    END;
    GO

    PROCEDURE InsertAnnouncement
      @Title NVARCHAR(255),
      @Description NVARCHAR(MAX),
      @Status NVARCHAR(50),
      @Category NVARCHAR(100),
      @SubCategory NVARCHAR(100)
    AS
    BEGIN
        INSERT INTO Announcements(Title, Description, Status, Category, SubCategory)
        VALUES (@Title, @Description, @Status, @Category, @SubCategory);
    END;
    GO

    PROCEDURE SelectAnnouncementById
	    @Id INT
    AS
    BEGIN
    	SELECT * FROM Announcements
    	WHERE Id = @Id
    END;
    GO

    PROCEDURE [dbo].[SelectAnnouncements]
    	@CategoryId INT = NULL,
    	@SubcategoryId INT = NULL
    AS
    BEGIN
        SELECT 
            Id,
            Title,
            Description,
            CreatedDate,
            Status,
            Category,
            SubCategory
        FROM Announcements
    	WHERE (@CategoryId IS NULL or Category = @CategoryId)
    	AND (@SubcategoryId IS NULL or SubCategory = @SubcategoryId)
    END;
    GO

    PROCEDURE UpdateAnnouncement
      @Id INT,
      @Title NVARCHAR(255),
      @Description NVARCHAR(MAX),
      @Status NVARCHAR(50),
      @Category NVARCHAR(100),
      @SubCategory NVARCHAR(100)
    AS
    BEGIN
        UPDATE Announcements
        SET Title = @Title,
            Description = @Description,
            Status = @Status,
            Category = @Category,
            SubCategory = @SubCategory
        WHERE Id = @Id;
    END;
    ```

2. Verify that the stored procedures are set up correctly. Use SQL Server Management Studio (SSMS) or any other tool to confirm.

### 3. Configuring Web API

1. Open the ASP.NET Web API project in Visual Studio or another code editor.
2. Set the connection string to database in the `appsettings.json` file. Example:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=myServerAddress;Database=MyDatabase;User Id=myUsername;Password=myPassword;"
      }
    }
    ```

3. Complete the database configuration running the command below:
   ```bash
    dotnet database update
    ```
4. Run the API project using the command:

    ```bash
    dotnet run
    ```

    The API will be accessible at, for example, `https://localhost:7064`.

### 4. Configuring Blazor App

1. Open the Blazor project in Visual Studio or another code editor.
2. Set the URL to back-end in `appsettings.json` file. Example:
   ```bash
   "ConnectionStrings": {
     "ApiConnectionString": "https://localhost:7064"
   }
   ```

4. Run the Blazor App using the command:

    ```bash
    dotnet run
    ```

    The Blazor app will be accessible at, for example, `https://localhost:5002`.

### 5. You are Welcome! Enjoy It😊
