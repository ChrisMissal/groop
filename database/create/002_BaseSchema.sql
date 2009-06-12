if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Meetings_Facilities]') AND parent_object_id = OBJECT_ID('Meetings'))
alter table Meetings  drop constraint FK_Meetings_Facilities

if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_UsersRoles_Roles]') AND parent_object_id = OBJECT_ID('UserRoles'))
alter table UserRoles  drop constraint FK_UsersRoles_Roles

if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_UserRoles_Members]') AND parent_object_id = OBJECT_ID('UserRoles'))
alter table UserRoles  drop constraint FK_UserRoles_Members

if exists (select * from dbo.sysobjects where id = object_id(N'Meetings') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Meetings
if exists (select * from dbo.sysobjects where id = object_id(N'Roles') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Roles
if exists (select * from dbo.sysobjects where id = object_id(N'Members') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Members
if exists (select * from dbo.sysobjects where id = object_id(N'UserRoles') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table UserRoles
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
create table Roles (
  RoleId INT IDENTITY NOT NULL,
   Name NVARCHAR(255) not null,
   primary key (RoleId)
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
create table UserRoles (
  MemberId INT not null,
   RoleId INT not null,
   primary key (MemberId, RoleId)
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
create index IX_Username on Members (Username)
alter table UserRoles add constraint FK_UsersRoles_Roles foreign key (RoleId) references Roles
alter table UserRoles add constraint FK_UserRoles_Members foreign key (MemberId) references Members
