create table if not exists category
(
    id   serial
        primary key,
    name varchar(150)
);

create table if not exists type
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
    id   serial
        primary key,
    name varchar(150)
);

create table if not exists client_role
(
    id   serial
        primary key,
    name varchar(500)
);

create table if not exists client
(
    id            serial
        primary key,
    role_id       integer
        references client_role,
    login         varchar(150)
        unique,
    password_hash varchar(150),
    description   varchar(5000),
    name          varchar(500),
    email         varchar(500),
    image_path    varchar(500)
);

create table if not exists recipe
(
    id              serial
        primary key,
    owner_client_id integer
        references client,
    header          varchar(150) not null,
    code            varchar(500)
);

create table if not exists recipe_type
(
    id        serial                                 not null
        constraint recipe_types_pkey
            primary key,
    recipe_id integer
        constraint recipe_types_recipe_id_fkey
            references recipe,
    type_id   integer
        constraint recipe_types_type_id_fkey
            references type,
    timestamp timestamp with time zone default now() not null
);

create table if not exists recipe_info
(
    id           integer not null
        primary key
        references recipe,
    image_path   varchar(500),
    source_url   varchar(500),
    description  varchar(200),
    portions     integer default 1,
    cooking_time timestamp with time zone
);

create table if not exists recipe_bju
(
    id            integer
        references recipe,
    fats          numeric,
    squirrels     numeric,
    carbohydrates numeric,
    kilocalories  numeric
);

create table if not exists recipe_ingredient
(
    id            serial not null
        constraint recipe_ingredients_pkey
            primary key,
    recipe_id     integer
        references recipe,
    ingredient_id integer
        references ingredient,
    measure_id    integer
        references measure,
    count         numeric
);

create table if not exists favorite_recipe
(
    id        serial not null
        primary key,
    recipe_id integer
        references recipe,
    client_id integer
        references client
);

create table if not exists recipe_category
(
    id          serial not null
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
    number    integer not null,
    text      text    not null
);

create table if not exists recipe_view
(
    id        serial
        primary key,
    recipe_id integer
        references recipe,
    timestamp timestamp with time zone default now()
);

