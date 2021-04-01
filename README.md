<p align="center">
  <img src="https://user-images.githubusercontent.com/44586411/110249754-f6009080-7f77-11eb-9148-ff56c1f26c50.gif" width="80%">
</p>

# DataProccesing
<p>Welcome to my school project for the class dataproccesing.</p>

## Introduction
<p>This project is made for a school assignment where I needed to process data from a database to a consumer application.<br>
The goal is to make a REST API that uses XML and JSON.
We need to make an application that uses the REST API, the apps need to switch between XML and JSON.</p>

## Table of Contents
* [Introduction](#introduction)
* [Table of Contents](#table-of-contents)
* [Tools used](#tools-used)
* [Database Import](#database-import)
* [REST API](#rest-api)
* [Consumer application](#consumer-application)
* [How to install the database](#how-to-install-the-database)


## Tools used
| Tool            |  Used for                         | Website                                                                                                   |
| :-------------: | :-------------:                   | :-----------------------:                                                                                 |
| XAMPP           |  Hosting local MySQL DB           | <a href="https://www.apachefriends.org/index.html" target="_blank" rel="noopener noreferrer">Website</a>  |
| HeidiSQL        |  Importing SQL dump               | <a href="https://www.heidisql.com/" target="_blank" rel="noopener noreferrer">Website</a>                 |
| EmEditor        |  Editing and splitting .sql file  | <a href="https://www.emeditor.com/" target="_blank" rel="noopener noreferrer">Website</a>                 |
| SSMA            |  Migration tool from MySQL to MSSQL | <a href="https://www.microsoft.com/en-us/download/details.aspx?id=54257" target="_blank" rel="noopener noreferrer">Website</a>                               |
| SSMS            |  Management Studio for MSSQL      | <a href="https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15" target="_blank" rel="noopener noreferrer">Website</a> |
| Swagger         |  REST API Documentation           | <a href="https://swagger.io/" target="_blank" rel="noopener noreferrer">Website</a>                       |


## Database Import
<p>I downloaded the Dataset here: https://steam.internet.byu.edu/ </p>
<p>After downloading the dataset I found out that importing a 160 GB dataset is a challenge in itself, not even talking about making a MySQL Dump into a working MS SQL Database.</p>

I used the following command to import it into PhpMyAdmin
```
mysql --init-command="SET SESSION FOREIGN_KEY_CHECKS=0;SET UNIQUE_CHECKS=0;" -u root -p DataBaseNamePlaceholder < C:\NameOfTheSqlFile
```
<br>
<p>But quickly switched to <a href="https://www.heidisql.com/" target="_blank" rel="noopener noreferrer">HeidiSQL</a> mainly to check the progress. HeidiSQL also splits the file into multiple queries, see the GIF for an example.</p>

<p><img src="https://user-images.githubusercontent.com/44586411/110246660-c302d080-7f68-11eb-9403-fcaa29c3c854.gif"></img></p>

<p>The SQL file (160 GB) is too big, even tho HeidiSQL splits the file into multiple queries.<br>
I solved this issue by using <a href="https://www.emeditor.com/" target="_blank" rel="noopener noreferrer">EmEditor</a>.<br> 
EmEditor is made to load big files and also works great to edit big files.<br> 
But the feature I used the most is the splitting tool, with this I was able to split the SQL file down into 8 files.<br> 
Each file consists out of 1 table, except for some small tables.</p>

<p>With the smaller SQL files I was able to import the tables I need into MySQL with the help of HeidiSQL.</p>

<p>The SQL file is imported in MySQL, but the end goal is to have it in MSSQL.<br>
  I used <a href="https://www.microsoft.com/en-us/download/details.aspx?id=54257" target="_blank" rel="noopener noreferrer">SSMA (SQL Server Migration Assistant)</a> to migrate the MySQL datbase into MSSQL

## REST API
<p>I used ASP.NET Core Web API for the API. It was the first time using Core instead of Net and the first time I made a REST API.<br>
  I used <a href="https://swagger.io/" target="_blank" rel="noopener noreferrer">Swagger</a> to create documentation for my REST API which saved me a lot of time which is really great.<br>
    - First step was making models so I could scaffold them to create controllers.<br>
    - Second step was to add pagination so the API wouldn't crash with the huge amount of rows in the database.<br>
    - As of last I created one GET, POST, PUT and DELETE for each database table as are the requirements from school.<br></p>

## Consumer application
(W.I.P.) An application made in .net forms which uses the REST API.

## How to install the database
<img align="right" src="https://user-images.githubusercontent.com/44586411/113137878-62904780-9225-11eb-91ca-7d19ca978e76.gif" alt="Gif that shows the process to import a SSMS back-up"></img>
