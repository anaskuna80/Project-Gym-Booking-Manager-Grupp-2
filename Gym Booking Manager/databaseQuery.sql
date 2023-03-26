CREATE TABLE sportsequipment (
	uniqueID SERIAL,
	name TEXT,
	isRestricted BOOL,
	PRIMARY KEY(uniqueID)
);
CREATE TABLE customer (
	id SERIAL,
	name TEXT,
	email TEXT,
	phone TEXT,
	password TEXT,
	PRIMARY KEY(id)
);
CREATE TABLE largeequipment (
	uniqueID SERIAL,
	name TEXT,
	isRestricted BOOL,
	PRIMARY KEY(uniqueID)
);
create table PersonalTrainer(
	uniqueID SERIAL,
	name TEXT,
	Consultation TEXT,
	id INT,
	isBooked BOOL,
	PRIMARY KEY(uniqueID),
	FOREIGN KEY (id) REFERENCES customer(id)
);
CREATE TABLE groupactivity (
	ID SERIAL,
	name TEXT,
	participantLimit INT,
	instructor INT,
	PRIMARY KEY (ID),
	FOREIGN KEY (instructor) REFERENCES Personaltrainer(uniqueID)
);
Create table staff (
		id SERIAL,
		name TEXT,
		email TEXT,
		phone TEXT,
		password TEXT,
		PRIMARY KEY (id)
);
create table space(
		uniqueID SERIAL,
		category TEXT,
		id INT,
		isRestricted BOOl,
		FOREIGN KEY (id) REFERENCES customer(id) ON DELETE CASCADE,
		FOREIGN KEY (id) REFERENCES staff(id) ON DELETE CASCADE
);
create table calendar(
		uniqueID SERIAL,
		name TEXT,
		description TEXT,
		id INT,
		timeSlot TEXT,
		PRIMARY KEY (uniqueID),
		FOREIGN KEY (id) REFERENCES customer(id) ON DELETE CASCADE,
		FOREIGN KEY (id) REFERENCES staff(id) ON DELETE CASCADE
);
insert into PersonalTrainer(name,Consultation,isBooked)
VALUES ('Emil E', 'none',false);
insert into PersonalTrainer(name,Consultation,isBooked)
VALUES ('Andreas', 'none',false);
insert into PersonalTrainer(name,Consultation,isBooked)
VALUES ('Alex', 'none',false);
insert into PersonalTrainer(name,Consultation,isBooked)
VALUES ('Emil J', 'none',false);
--data for space
insert into space(category,isRestricted)
VALUES ('hall',false);
insert into space(category,isRestricted)
VALUES ('lane',false);
insert into space(category,isRestricted)
VALUES ('studio',false);
insert into space(category,isRestricted)
VALUES ('hall',false);
insert into space(category,isRestricted)
VALUES ('lane',false);
-- data for LargeEquipment
insert into LargeEquipment(name,isRestricted)
VALUES ('bench',false);
insert into LargeEquipment(name,isRestricted)
VALUES ('bench',false);
insert into LargeEquipment(name,isRestricted)
VALUES ('Legpress',false);
insert into LargeEquipment(name,isRestricted)
VALUES ('Legpress',false);
insert into LargeEquipment(name,isRestricted)
VALUES ('rowmachine',false);
insert into LargeEquipment(name,isRestricted)
VALUES ('rowmachine',false);
insert into LargeEquipment(name,isRestricted)
VALUES ('boxningsack',false);
insert into LargeEquipment(name,isRestricted)
VALUES ('boxningsack',false);
--data for sportequipment
insert into sportsequipment(name,isRestricted)
VALUES ('racket',false);
insert into sportsequipment(name,isRestricted)
VALUES ('racket',false);
insert into sportsequipment(name,isRestricted)
VALUES ('floorballstick',false);
insert into sportsequipment(name,isRestricted)
VALUES ('floorballstick',false);
insert into sportsequipment(name,isRestricted)
VALUES ('football',false);
insert into sportsequipment(name,isRestricted)
VALUES ('football',false);
insert into sportsequipment(name,isRestricted)
VALUES ('basketball',false);
insert into sportsequipment(name,isRestricted)
VALUES ('basketball',false);	
--data for staff
insert into staff(name,email,phone,password)
VALUES ('Emil','hej@hej','hej12345','hej123');
insert into staff(name,email,phone,password)
VALUES ('Erik','hej@hej','hej12345','hej1231');	
insert into staff(name,email,phone,password)
VALUES ('Andreas','hej@hej','hej12345','hej1232');	
insert into staff(name,email,phone,password)
VALUES ('Mikael','hej@hej','hej12345','hej1233');	
insert into staff(name,email,phone,password)
VALUES ('Kurt','hej@hej','hej12345','hej1234');	
--data for groupactivity
insert into groupactivity(instructor,name,participantLimit)
VALUES (2,'Badminton', 20);
--data for customer
insert into customer(name,email,phone,password)
VALUES ('Kalle','hej@hej','hej12345','hej1234');
insert into customer(name,email,phone,password)
VALUES ('Adam','hej@hej','hej12345','hej1234');
insert into customer(name,email,phone,password)
VALUES ('Sven','hej@hej','hej12345','hej1234');
insert into customer(name,email,phone,password)
VALUES ('Rasmus','hej@hej','hej12345','hej1234');
insert into customer(name,email,phone,password)
VALUES ('Pelle','hej@hej','hej12345','hej1234');
--data for calendar
insert into calendar(uniqueID,name,description,id,timeSlot)
VALUES (1, 'hall', 'basket', 1, '2023-05-25 15:00-16:00');