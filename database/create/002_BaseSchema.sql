if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Meetings_Facilities]') AND parent_object_id = OBJECT_ID('Meetings'))
alter table Meetings  drop constraint FK_Meetings_Facilities

if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD42E632FED2CAB7]') AND parent_object_id = OBJECT_ID('Attendees'))
alter table Attendees  drop constraint FKD42E632FED2CAB7

if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD42E632FBCA706C4]') AND parent_object_id = OBJECT_ID('Attendees'))
alter table Attendees  drop constraint FKD42E632FBCA706C4

if exists (select * from dbo.sysobjects where id = object_id(N'Meetings') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Meetings
if exists (select * from dbo.sysobjects where id = object_id(N'Attendees') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Attendees
if exists (select * from dbo.sysobjects where id = object_id(N'Members') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Members
if exists (select * from dbo.sysobjects where id = object_id(N'Facilities') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Facilities
create table Meetings (
  Id INT IDENTITY NOT NULL,
   Title NVARCHAR(255) not null,
   StartsAt DATETIME not null,
   EndsAt DATETIME not null,
   Description NVARCHAR(255) not null,
   Presenter NVARCHAR(255) not null,
   FacilityId INT not null,
   primary key (Id)
)
create table Attendees (
  Id INT IDENTITY NOT NULL,
   AttendeeType varchar(25) not null,
   MeetingId INT not null,
   DateRegistered DATETIME not null,
   Email NVARCHAR(256) not null,
   FirstName NVARCHAR(50) null,
   LastName NVARCHAR(50) null,
   MemberId INT null,
   DatePromoted DATETIME null,
   primary key (Id)
)
create table Members (
  MemberId INT IDENTITY NOT NULL,
   Username NVARCHAR(50) not null unique,
   Password NVARCHAR(255) not null,
   PasswordSalt NVARCHAR(255) not null,
   First NVARCHAR(50) not null,
   Last NVARCHAR(50) not null,
   EmailAddress NVARCHAR(100) not null,
   primary key (MemberId)
)
create table Facilities (
  Id INT IDENTITY NOT NULL,
   Name NVARCHAR(255) not null,
   ImageUrl NVARCHAR(255) not null,
   Description NVARCHAR(255) not null,
   Address NVARCHAR(255) null,
   City NVARCHAR(255) null,
   Region NVARCHAR(255) null,
   PostalCode NVARCHAR(255) null,
   primary key (Id)
)
alter table Meetings add constraint FK_Meetings_Facilities foreign key (FacilityId) references Facilities
alter table Attendees add constraint FKD42E632FED2CAB7 foreign key (MeetingId) references Meetings
alter table Attendees add constraint FKD42E632FBCA706C4 foreign key (MemberId) references Members
create index IX_Username on Members (Username)
