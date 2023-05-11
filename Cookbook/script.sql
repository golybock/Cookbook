create table measure
(
    id   serial primary key,
    name varchar(15)
);

create table category
(
    id   serial primary key,
    name varchar(15)
);

create table ingredient
(
    id         serial primary key,
    name       varchar(150),
    measure_id int references measure
);

create table client
(
    id            serial primary key,
    login         varchar(150) unique not null,
    password_hash text,
    name          varchar(250),
    email         varchar(500),
    image_path    varchar(500)
);

create table recipe
(
    id          serial primary key,
    category_id int references category not null,
    header      varchar(75)             not null,
    code        varchar(500),
    image_path  varchar(500),
    source_url  varchar(500),
    description varchar(200)
);

create table recipe_stats
(
    id                   serial primary key references recipe,
    portions             int,
    cooking_time_minutes int,
    reviews              int not null default 0
);

create table recipe_step
(
    id        serial primary key,
    recipe_id int references recipe,
    text      text
);

create table recipe_ingredient
(
    id            serial primary key,
    recipe_id     int references recipe,
    ingredient_id int references ingredient
);


