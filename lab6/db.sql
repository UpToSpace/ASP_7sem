create database WSKVS;
go;

use WSKVS;
go;

create table Student
(
    id   int          not null IDENTITY (1,1) primary key,
    name varchar(255) not null,
);
go;

create table Note
(
    id         int          not null IDENTITY (1,1) primary key,
    student_id int          not null,
    subject    varchar(255) not null,
    note       int,
    foreign key (student_id) references Student (id)
);
go;

    insert into Student (name) values ('Student1');
go;
    insert into Student (name) values ('Student2');
go;
    insert into Student (name) values ('Student3');
go;
    
    insert into Note (student_id, subject, note) values (1, 'Subject1', 1);
go;
    insert into Note (student_id, subject, note) values (1, 'Subject2', 2);
go;
    insert into Note (student_id, subject, note) values (1, 'Subject3', 3);
go;
    insert into Note (student_id, subject, note) values (2, 'Subject1', 4);
go;
    insert into Note (student_id, subject, note) values (2, 'Subject2', 5);
go;
    insert into Note (student_id, subject, note) values (2, 'Subject3', 6);
go;
    insert into Note (student_id, subject, note) values (3, 'Subject1', 7);
go;
    insert into Note (student_id, subject, note) values (3, 'Subject2', 8);
go;
    insert into Note (student_id, subject, note) values (3, 'Subject3', 9);
go;

select * from Student;
go;
select * from Note;
go;