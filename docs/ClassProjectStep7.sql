use ClassProject

go

-- ADDING TABLES TO CLASSPROJECT
-- ADD CATEGORY TABLE. NEEDS FOREIGN KEY IMPLEMENTATION
drop table if exists dbo.CATEGORY
create table dbo.CATEGORY
  (
   catID      int primary key not null,
   exerciseID int             not null,
   catName	  nvarchar(50)    not null,
   catDesc	  ntext			  not null
  )
go

-- ADD CUSTOMERS TABLE.
drop table if exists dbo.CUSTOMERS
create table dbo.CUSTOMERS
  (
   custID	  int primary key not null,
   custName	  nvarchar(50)    not null,
   custAge 	  int			  not null,
   custWeight int			  not null
  )
go

-- ADD EXERCISEMAX TABLE. NEEDS FOREIGN KEY IMPLEMENTATION
drop table if exists dbo.EXERCISEMAX
create table dbo.EXERCISEMAX
  (
   exerciseMax int primary key not null,
   exerciseID  int             not null
  )
go

-- ADD EXERCISES TABLE. NEEDS FOREIGN KEY IMPLEMENTATION
drop table if exists dbo.EXERCISES
create table dbo.EXERCISES
  (
   exerciseID    int primary key not null,
   exerciseName  nvarchar(50)    not null,
   exercisePic   image			 null,
   exerciseDesc  ntext			 not null,
   exerciseMax   int			 null,
   catID		 int			 null,
   custID		 int			 null
  )
go

-- ADD PLATES TABLE.
drop table if exists dbo.PLATES
create table dbo.PLATES
  (
   plateID     int primary key not null,
   plateWeight float           not null
  )
go

-- INSERTING DATA INTO EXERCISES TABLE COLUMNS.
insert dbo.EXERCISES (exerciseID, exerciseName, exerciseDesc, exerciseMax, catID, custID)
  Values (1, 'BenchPress', 'Laying flat on a bench, using a 45lb bar for exercise'
		   , null, null, null)
go

insert dbo.EXERCISES (exerciseID, exerciseName, exerciseDesc, exerciseMax, catID, custID)
  Values (2, 'DeadLift', '45lb bar flat on ground, lifting straight up'
		   , null, null, null)
go

insert dbo.EXERCISES (exerciseID, exerciseName, exerciseDesc, exerciseMax, catID, custID)
  Values (3, 'Squat (Front)', '45lb bar on shoulders, keeping good form squating down and back up'
		   , null, null, null)
go

insert dbo.EXERCISES (exerciseID, exerciseName, exerciseDesc, exerciseMax, catID, custID)
  Values (4, 'Military Press', '45lb bar in hands at shoulder hieght, hands shoulder width'
		   , null, null, null)
go

select *
  from EXERCISES;

-- INSERTING DATA INTO CATEGORY TABLE COLUMNS.
insert dbo.CATEGORY (catID, exerciseID, catName, catDesc)
  Values (1, 1, 'Chest', 'Exercises involving the Chest')
go

insert dbo.CATEGORY (catID, exerciseID, catName, catDesc)
  Values (2, 2, 'Back', 'Exercises involving the Back')
go

insert dbo.CATEGORY (catID, exerciseID, catName, catDesc)
  Values (3, 3, 'Legs', 'Exercises involving the Legs')
go

insert dbo.CATEGORY (catID, exerciseID, catName, catDesc)
  Values (4, 4, 'Shoulders', 'Exercises involving the Shoulders')
go

select *
  from CATEGORY;

-- INSERTING DATA INTO PLATES TABLE COLUMNS.
insert dbo.PLATES (plateID, plateWeight)
  Values (1, 45)
go

insert dbo.PLATES (plateID, plateWeight)
  Values (2, 35)
go

insert dbo.PLATES (plateID, plateWeight)
  Values (3, 25)
go

insert dbo.PLATES (plateID, plateWeight)
  Values (4, 10)
go

insert dbo.PLATES (plateID, plateWeight)
  Values (5, 5)
go

insert dbo.PLATES (plateID, plateWeight)
  Values (6, 2.5)
go

select * from CATEGORY;
select * from CUSTOMERS;   -- Will be entered by user
select * from EXERCISEMAX; -- Will be entered by user
select * from EXERCISES;
select * from PLATES;