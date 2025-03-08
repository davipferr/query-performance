# 🧪 Scientific - Performance in Read operation in ASP.NET MVC

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

Access the link -> [SQL Server](https://www.microsoft.com/en/sql-server/sql-server-downloads)

Scroll the page until you find the options, "Developer" and "Express". Click to download the SQL Server Express

Follow the steps to install

2 - SQL Server Management Studio (SSMS)

Access the link -> [SSMS](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

Scroll until the topic "Download SSMS"

click on the link, "Download SQL Server Management Studio (SSMS) 20.2", to start the download

Follow the steps to install

# 🎲 Setting up the Databases

1 - Create the data base

query_performance

2 - Create the tables

| Table Names               | Rows       |
|---------------------------|------------|
| OneThousandRows           | 1,000      |
| TenThousandRows           | 10,000     |
| OneHundredThousandRows    | 100,000    |
| OneMillionRowws           | 1,000,000  |

Use this command:

```bash
CREATE TABLE QueryPerformance.dbo.TableName (
    Id             INT            PRIMARY KEY IDENTITY(1,1),  -- Auto-incrementing primary key
    Nome           VARCHAR(255)   NOT NULL,                   -- Maps to JSON "nome"
    Idade          INT            NOT NULL,                   -- Maps to JSON "idade"
    Cpf            VARCHAR(14)    NOT NULL,                   -- Format "528.108.758-47" (14 chars)
    Rg             VARCHAR(12)    NOT NULL,                   -- Format "25.044.006-4" (12 chars)
    DataNasc       DATE           NOT NULL,                   -- Convert "18/01/2004" to DATE
    Sexo           VARCHAR(10)    NOT NULL,                   -- "Masculino" or "Feminino"
    Signo          VARCHAR(20)    NOT NULL,                   -- Zodiac sign
    Mae            VARCHAR(255)   NOT NULL,                   -- Mother's name
    Pai            VARCHAR(255)   NOT NULL,                   -- Father's name
    Email          VARCHAR(255)   NOT NULL,                   -- Email address
    Senha          VARCHAR(255)   NOT NULL,                   -- Password
    Cep            VARCHAR(9)     NOT NULL,                   -- Format
    Endereco       VARCHAR(255)   NOT NULL,                   -- Street address
    Numero         INT            NOT NULL,                   -- Address number
    Bairro         VARCHAR(255)   NOT NULL,                   -- Neighborhood
    Cidade         VARCHAR(255)   NOT NULL,                   -- City
    Estado         CHAR(2)        NOT NULL,                   -- State abbreviation
    TelefoneFixo   VARCHAR(14)    NOT NULL,                   -- Landline phone
    Celular        VARCHAR(15)    NOT NULL,                   -- Mobile phone
    Altura         DECIMAL(3,2)   NOT NULL,                   -- Height as decimal
    Peso           INT            NOT NULL,                   -- Weight
    TipoSanguineo  VARCHAR(3)     NOT NULL,                   -- Blood type
    Cor            VARCHAR(50)    NOT NULL                    -- Color
);
```

👀 remember to change the "TableName" on the query

2 - Insert data in bulk

OBS: [This data was generated on the 4devs website](https://www.4devs.com.br/gerador_de_pessoas)

```bash
DECLARE @Counter INT = 1;
BEGIN TRANSACTION;

WHILE @Counter <= NumberOfRows
	BEGIN
	    INSERT INTO TableName
		VALUES (
		    'Henrique Daniel Vitor da Silva', 
		    21, 
		    '555.111.777-33', 
		    '22.333.222-5', 
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
		    'dourado'
		);
	    
		SET @Counter += 1;
		
		-- Commit in batches (e.g., 10,000 rows) to avoid transaction log bloat
		IF @Counter % 300 = 0
			BEGIN
			COMMIT;

		BEGIN TRANSACTION;
	END
END
```

👀  Remember to change the, "TableName" for each one that you create on the step 2, and the number of rows for the respective data base on "NumberOfRows" (1000, 10000, 100000, 1000000)

3 - Check if the data was entered correctly

```bash
SELECT 'OneThousandRows' AS TableName, COUNT(*) AS TotalRows FROM OneThousandRows
UNION ALL
SELECT 'TenThousandRows' AS TableName, COUNT(*) AS TotalRows FROM TenThousandRows
UNION ALL
SELECT 'OneHundredThousandRows' AS TableName, COUNT(*) AS TotalRows FROM OneHundredThousandRows
UNION ALL
SELECT 'OneMillionRowws' AS TableName, COUNT(*) AS TotalRows FROM OneMillionRowws;
```
