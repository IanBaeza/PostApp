-- Database: TestPostDB

-- DROP DATABASE IF EXISTS "TestPostDB";

CREATE DATABASE "PostsDB"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Spanish_Spain.1252'
    LC_CTYPE = 'Spanish_Spain.1252'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

-- SEQUENCE: public.post_id_seq

-- DROP SEQUENCE IF EXISTS public.post_id_seq;

CREATE SEQUENCE IF NOT EXISTS public.post_id_seq
    INCREMENT 1
    START 0
    MINVALUE 0
    MAXVALUE 9223372036854775807
    CACHE 1;

-- Table: public.post

-- DROP TABLE IF EXISTS public.post;

CREATE TABLE IF NOT EXISTS public.post
(
    id integer NOT NULL DEFAULT nextval('post_id_seq'::regclass),
    nombre character varying(50) COLLATE pg_catalog."default" NOT NULL,
    descripcion character varying(50) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Post_pkey" PRIMARY KEY (id),
    CONSTRAINT "Post_unombre" UNIQUE (nombre)
);

ALTER TABLE IF EXISTS public.post
    OWNER to postgres;

ALTER SEQUENCE public.post_id_seq
    OWNED BY public.post.id;

ALTER SEQUENCE public.post_id_seq
    OWNER TO postgres;































