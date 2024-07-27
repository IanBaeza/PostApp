-- Table: public.Post

-- DROP TABLE IF EXISTS public."Post";

CREATE TABLE IF NOT EXISTS public."Post"
(
    "Id" integer NOT NULL,
    "Nombre" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "Descripcion" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Post_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Post"
    OWNER to postgres;