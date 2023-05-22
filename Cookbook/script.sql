create table if not exists category
(
    id   serial
        primary key,
    name varchar(150)
);

create table if not exists measure
(
    id   serial
        primary key,
    name varchar(150)
);

create table if not exists ingredient
(
    id         serial
        primary key,
    measure_id integer
        references measure,
    name       varchar(150)
);

create table if not exists client
(
    id          serial
        primary key,
    login       varchar(150),
    password    varchar(150),
    token       varchar(500),
    description varchar(5000),
    name        varchar(500),
    email       varchar(500),
    image_path  varchar(500)
);

create table if not exists recipe
(
    id          serial
        primary key,
    client_id   integer
        references client,
    header      varchar(500) not null,
    code        varchar(500),
    image_path  varchar(500),
    source_url  varchar(500),
    description varchar(200)
);

create table if not exists recipe_stats
(
    id            integer not null
        primary key
        references recipe,
    fats          numeric,
    squirrels     numeric,
    carbohydrates numeric,
    kilocalories  numeric,
    portions      integer default 1,
    cooking_time  timestamp with time zone
);

create table if not exists recipe_ingredients
(
    id            serial
        primary key,
    recipe_id     integer
        references recipe,
    ingredient_id integer
        references ingredient,
    count         numeric
);

create table if not exists favorite_recipes
(
    id        serial
        primary key,
    recipe_id integer
        references recipe,
    client_id integer
        references client
);

create table if not exists recipe_categories
(
    id          serial
        primary key,
    recipe_id   integer
        references recipe,
    category_id integer
        references category
);

create table if not exists recipe_step
(
    id        serial
        primary key,
    recipe_id integer not null
        references recipe,
    text      text    not null
);

create table if not exists recipe_views
(
    id        serial
        primary key,
    recipe_id integer
        references recipe,
    datetime  timestamp with time zone default now() not null
);

