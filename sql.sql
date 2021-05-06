create database election
use election

create table application(applicantname varchar(20),fathername varchar(20),aadhar varchar(20),dob datetime,enroll int,emailid varchar(20),gender varchar(20),mobilenum numeric,constituency varchar(20))
select*from application

create table candidates ( name varchar(20),fathersname varchar(20),party varchar (20), age int,gender varchar(20),address varchar(20),constituency varchar(20))
select * from candidates

create table results ( constituency varchar(20),winner varchar(20),gender varchar(20),party varchar(20))
select * from results