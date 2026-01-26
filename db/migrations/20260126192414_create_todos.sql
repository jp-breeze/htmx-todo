-- migrate:up
create table if not exists todos (
    id uuid primary key,
    title varchar(255) not null,
    description varchar(1000) not null,
    is_active bit not null default true,
    created_at timestamptz not null default now(),
    updated_at timestamptz not null default now()
);

create index idx_todos_title on todos(title);
create index idx_todos_is_active on todos(is_active);

-- migrate:down
drop table if exists todos;
