create database ProyectoFinal;

create table Empleados
(
id int identity(1,1) primary key,
CodigoEmpleado int,
Nombres varchar(100),
Apellidos varchar(100),
Telefono bigint,
Departarmento Text,
Cargo varchar(50),
FechaI date,
Salario money,
Estatus varchar(10)
)

--drop table Empleados;
select * from Empleados;
--Prueba para insertar datos
insert into Empleados 
values(01, 'Rounger', 'Sanchez Morla', 8094754839, 'Finanzas', 'Inspector', '23/05/2015', 15000, 'Activo');
--truncate table Empleados;

select nombres, DATEPART(MM, FechaI) as Fecha from Empleados;

select * from Empleados where DATEPART(MM, FechaI) = 10;

select SUM(salario) as 'Salario Total' from Empleados where DATEPART(YYYY, FechaI) = 2017 and DATEPART(MM, FechaI) = 5;
select SUM(salario) as 'Salario Total' from Empleados where Estatus = 'Activo' ;


create table Departamentos
(
Id int identity(1,1) primary key,
CodigoDepartamento int,
Nombre varchar(50)
)

select * from Departamentos;
--drop table Departamentos;
--Prueba de insetar Datos
insert into Departamentos values(05, 'Isael');
--truncate table Departamentos;


create table Cargos
(
Id int identity(1,1) primary key,
Cargo varchar(50)
)


--drop table Nominas;
create table Nominas
(
Id int identity(1,1) primary key,
Año int,
Mes int,
Total money
)

--drop table Salidas;
create table Salidas
(
id int identity(1,1) primary key,
Empleado varchar(50) not null,
TipoSalida varchar(50),
Motivo text,
Fecha date
)


insert into Salidas values( 'Rounger', 'Renucia', 'Por un trabajo mejor', '28/09/2012');


select * from Salidas;

--drop table Vacaciones;
Create table Vacaciones
(

id int identity(1,1) primary key,
Empleado varchar(50) not null,
Desde date,
Hasta date,
Año int,
Comentarios text
)

--drop table Permisos;
Create table Permisos
(

id int identity(1,1) primary key,
Empleado varchar(50) not null,
Desde date,
Hasta date,
Comentarios text
)


--drop table Licencias;
Create table Licencias
(

id int identity(1,1) primary key,
Empleado varchar(50) not null,
Desde date,
Hasta date,
Motivo text,
Comentarios text
)








