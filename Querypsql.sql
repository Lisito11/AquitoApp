CREATE TABLE useraquito (
    useraquitoid  int NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    cedula varchar(11),
    firstname varchar(80),
    lastname varchar(80),
    email varchar(150),
    userpassword varchar(650),
    userrole varchar(650),
    phone varchar(15),
    status int
);

CREATE TABLE client (
    clientid  int NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    cedula varchar(11),
    firstname varchar(80),
    lastname varchar(80),
    email varchar(150),
    licence varchar(25),
    nacionality varchar(80),
    typeblood varchar(10),
    userpic varchar(650),
    licencepic varchar(650),
    useraquitoid int, constraint fk_useraquito_client foreign key (useraquitoid) references useraquito(useraquitoid),
    status int
);

CREATE TABLE typevehicle (
    typevehicleid  int NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    namevehicle varchar(150),
    status int
);

CREATE TABLE vehicle (
    vehicleid  int NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    brand varchar(150),
    model varchar(150),
    age int,
    priceday decimal,
    weightcapacity decimal,
    passengers int,
    matricula varchar(25),
    securitynum varchar(25),
    vehiclepic varchar(650),
    latitude decimal,
    longitude decimal,
    typevehicleid int, constraint fk_typevehicle_vehicle foreign key (typevehicleid) references typevehicle(typevehicleid),
    useraquitoid int, constraint fk_useraquito_vehicle foreign key (useraquitoid) references useraquito(useraquitoid),
    status int
);


CREATE TABLE reservation (
    reservationid  int NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    startdate date,
    enddate date,
    totalpay decimal,
    vehicleid int, constraint fk_vehicle_reservation foreign key (vehicleid) references vehicle(vehicleid),
    clientid int, constraint fk_client_reservation foreign key (clientid) references client(clientid),
    useraquitoid int, constraint fk_useraquito_reservation foreign key (useraquitoid) references useraquito(useraquitoid),
    status int
);