# DataProccesing
Welcome to my school project for the class dataproccesing.

## Introduction
This project is made for a school assignment where I needed to process data from a database to a consumer application.<br><br>
The goal is to make a REST API which uses XML and JSON.
We need to make an application which uses the REST API, the apps needs to switch between XML and JSON.

## Database Import
I downloaded the Dataset here: https://steam.internet.byu.edu/ <br>
After downloading the dataset I found out that importing a 160GB dataset is a challenge on itself, not even talking about making a MySQL Dump into a working MS SQL Database.<br>
<br>
I Used the following command to import it into PHPMyAdmin
```
mysql --init-command="SET SESSION FOREIGN_KEY_CHECKS=0;SET UNIQUE_CHECKS=0;" -u root -p DataBaseNamePlaceholder < C:\NameOfTheSqlFile
```
