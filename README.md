# Query Performance

# 👀 Overview

# 📖 About

Query Performance is a project that focuses on making database queries as performant as possible in the stack of this project. Each database has a specific number of rows that I separate by levels:

| Level   | Rows       |
|---------|------------|
| Level 1 | 1,000      |
| Level 2 | 10,000     |
| Level 3 | 100,000    |
| Level 4 | 1,000,000  |

# 🧱 This project was built with:

- [.NET Framework 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472)
- [SQL Server](https://www.microsoft.com/en/sql-server/sql-server-downloads)
- [Entity Framework 6](https://learn.microsoft.com/en-us/ef/ef6/)
- [Bootstrap 5](https://getbootstrap.com/)

# ⬇️ Downloading the tools to use the database

1 - SQL Server Express

Access the link => [SQL Server](https://www.microsoft.com/en/sql-server/sql-server-downloads)

Scroll the page until you find the options, "Developer" and "Express". Click to download the SQL Server Express

Follow the steps to install

2 - SQL Server Management Studio (SSMS)

Access the link => [SSMS](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

Scroll until the topic "Download SSMS"

click on the link, "Download SQL Server Management Studio (SSMS) 20.2", to start the download

Follow the steps to install

# 🎲 Setting up the Databases

1 - Create the data base

query_performance

2 - Create the tables

| Table Names          | Rows       |
|----------------------|------------|
| 1mil_rows_table      | 1,000      |
| 10mil_rows_table     | 10,000     |
| 100mil_rows_table    | 100,000    |
| 1mi_rows_table       | 1,000,000  |


Use this command:

```bash
CREATE TABLE [query_performance].dbo.[table_name] (
    id INT PRIMARY KEY IDENTITY(1,1),  -- Auto-incrementing primary key
    nome VARCHAR(255) NOT NULL,        -- Maps to JSON "nome"
    idade INT NOT NULL,                -- Maps to JSON "idade"
    cpf VARCHAR(14) NOT NULL,          -- Format "528.108.758-47" (14 chars)
    rg VARCHAR(12) NOT NULL,           -- Format "25.044.006-4" (12 chars)
    data_nasc DATE NOT NULL,           -- Convert "18/01/2004" to DATE
    sexo VARCHAR(10) NOT NULL,         -- "Masculino" or "Feminino"
    signo VARCHAR(20) NOT NULL,        -- Zodiac sign
    mae VARCHAR(255) NOT NULL,         -- Mother's name
    pai VARCHAR(255) NOT NULL,         -- Father's name
    email VARCHAR(255) NOT NULL,       -- Email address
    senha VARCHAR(255) NOT NULL,       -- Password
    cep VARCHAR(9) NOT NULL,           -- Format
    endereco VARCHAR(255) NOT NULL,    -- Street address
    numero INT NOT NULL,               -- Address number
    bairro VARCHAR(255) NOT NULL,      -- Neighborhood
    cidade VARCHAR(255) NOT NULL,      -- City
    estado CHAR(2) NOT NULL,           -- State abbreviation
    telefone_fixo VARCHAR(14) NOT NULL,-- Landline phone
    celular VARCHAR(15) NOT NULL,      -- Mobile phone
    altura DECIMAL(3,2) NOT NULL,      -- Height as decimal
    peso INT NOT NULL,                 -- Weight
    tipo_sanguineo VARCHAR(3) NOT NULL,-- Blood type
    cor VARCHAR(50) NOT NULL           -- Color
);
```

👀 remember to change the "table_name" on the query

2 - Insert data in bulk

OBS: [This data was generated on the 4devs website](https://www.4devs.com.br/gerador_de_pessoas)

```bash
DECLARE @Counter INT = 1;
BEGIN TRANSACTION;

WHILE @Counter <= number_of_rows
BEGIN
    INSERT INTO [table_name] (
	    nome, 
	    idade, 
	    cpf, 
	    rg, 
	    data_nasc, 
	    sexo, 
	    signo, 
	    mae, 
	    pai, 
	    email, 
	    senha, 
	    cep, 
	    endereco, 
	    numero, 
	    bairro, 
	    cidade, 
	    estado, 
	    telefone_fixo, 
	    celular, 
	    altura, 
	    peso, 
	    tipo_sanguineo, 
	    cor
	)
	VALUES (
	    'Henrique Daniel Vitor da Silva', 
	    21, 
	    '528.108.758-47', 
	    '25.044.006-4', 
	    CONVERT(DATE, '18/01/2004', 103),
	    'Masculino', 
	    'Capricórnio', 
	    'Sophia Laís Natália', 
	    'Miguel Kevin da Silva', 
	    'henriquedanieldasilva@tecvap.com.br', 
	    'zECEP9qnp3', 
	    '06843-448', 
	    'Rua dos Ex-Combatentes', 
	    870, 
	    'Chácaras Lidia', 
	    'Embu das Artes', 
	    'SP', 
	    '(11) 2509-4050', 
	    '(11) 99594-8429', 
	    CAST(REPLACE('1,97', ',', '.') AS DECIMAL(3,2)),
	    53, 
	    'B-', 
	    'amarelo'
	);
    
    SET @Counter += 1;
    
    -- Commit in batches (e.g., 10,000 rows) to avoid transaction log bloat
    IF @Counter % 100 = 0
    BEGIN
        COMMIT;
        BEGIN TRANSACTION;
    END
END
```

👀  Remember to change the, "table_name" for each one that you create on the step 2, and the number of rows for the respective data base on "number_of_rows" (1000, 10000, 100000, 1000000)

3 - Check if the data was entered correctly

```bash
SELECT '1mil_rows_table' AS TableName, COUNT(*) AS TotalRows FROM [1mil_rows_table]
UNION ALL
SELECT '10mil_rows_table' AS TableName, COUNT(*) AS TotalRows FROM [10mil_rows_table]
UNION ALL
SELECT '100mil_rows_table' AS TableName, COUNT(*) AS TotalRows FROM [100mil_rows_table]
UNION ALL
SELECT '1mi_rows_table' AS TableName, COUNT(*) AS TotalRows FROM [1mi_rows_table];
```
