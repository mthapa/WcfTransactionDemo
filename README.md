# WcfTransactionDemo
How to do transactions in WCF.


##Query to create neccessary files##

```sql
CREATE TABLE [Employee](
	[Eid] [int] IDENTITY(1,1) NOT NULL,
	[EName] [varchar](50) NOT NULL,
	[ESalary] [float] NOT NULL
	)


CREATE TABLE [dbo].[SalaryHistory](
	[SNo] [int] IDENTITY(1000,1) NOT NULL,
	[Eid] [int] NULL,
	[ESalary] [float] NULL,
	[StDate] [date] NULL,
	[EdDate] [date] NULL
	)


CREATE TABLE [Transactions](
	[Tid] [int] IDENTITY(1,1) NOT NULL,
	[TInfo] [varchar] (50),	
  [TDate] [datetime]	
	)
```
