<p align="center">
  <img src="https://user-images.githubusercontent.com/44586411/110249754-f6009080-7f77-11eb-9148-ff56c1f26c50.gif" width="80%">
</p>

# DataProccesing
<p>Welcome to my school project for the class dataproccesing.</p>

## Introduction
<p>This project is made for a school assignment where I needed to process data from a database to a consumer application.</p><br>
<p>The goal is to make a REST API that uses XML and JSON.
We need to make an application that uses the REST API, the apps need to switch between XML and JSON.</p>

## Table of Contents
* [Introduction](#introduction)
* [Table of Contents](#table-of-contents)
* [Tools used](#tools-used)
* [Database Import](#database-import)

## Tools used
| Tool            |  Used for                         | Website                                                                                                   |
| :-------------: | :-------------:                   | :-----------------------:                                                                                 |
| Xampp           |  Hosting local MySQL DB           | <a href="https://www.apachefriends.org/index.html" target="_blank" rel="noopener noreferrer">Website</a>  |
| HeidiSQL        |  Importing SQL dump               | <a href="https://www.heidisql.com/" target="_blank" rel="noopener noreferrer">Website</a>                 |
| EmEditor        |  Editing and splitting .sql file  | <a href="https://www.emeditor.com/" target="_blank" rel="noopener noreferrer">Website</a>                 |



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

<p>The SQL file (160 GB) is to big even tho HeidiSQL splits the file into multiple queries.<br>
I solved this issue by using <a href="https://www.emeditor.com/" target="_blank" rel="noopener noreferrer">EmEditor</a>. EmEditor is made to load big files and also works great to edit big files. But the feuture I used the most is the splitting tool, with this I was able to spilt the SQL file down in 8 files. Each file consist out of 1 table, except for some small tables.</p>

<p>With the smaller SQL files I was able to import the tables I need into MySQL with the help of HeidiSQL.</p>
