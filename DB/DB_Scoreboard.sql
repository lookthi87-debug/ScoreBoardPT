--
-- PostgreSQL database dump
--

\restrict y7qAMwNo561Z93ueIPW1yuWsHsd5rD5xa2pURqW1TQftHAhPgC3RiPRdCs57N9H

-- Dumped from database version 14.19
-- Dumped by pg_dump version 14.19

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: update_updated_at_column(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.update_updated_at_column() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
                        BEGIN
                            NEW.updated_at = CURRENT_TIMESTAMP;
                            RETURN NEW;
                        END;
                        $$;


ALTER FUNCTION public.update_updated_at_column() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: activities; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.activities (
    id integer NOT NULL,
    user_id integer,
    machine_name text,
    ip_address text,
    login_time timestamp without time zone DEFAULT now(),
    last_ping timestamp without time zone DEFAULT now(),
    is_active boolean DEFAULT true
);


ALTER TABLE public.activities OWNER TO postgres;

--
-- Name: activities_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.activities_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.activities_id_seq OWNER TO postgres;

--
-- Name: activities_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.activities_id_seq OWNED BY public.activities.id;


--
-- Name: classsets; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.classsets (
    id integer NOT NULL,
    name character varying(150) NOT NULL,
    match_class_id integer
);


ALTER TABLE public.classsets OWNER TO postgres;

--
-- Name: classsets_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.classsets_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.classsets_id_seq OWNER TO postgres;

--
-- Name: classsets_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.classsets_id_seq OWNED BY public.classsets.id;


--
-- Name: matchclass; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.matchclass (
    id integer NOT NULL,
    name character varying(150) NOT NULL,
    period_type character varying(50),
    standard_periods integer,
    periods_to_win integer,
    allow_overtime boolean DEFAULT false,
    max_overtime_periods integer DEFAULT 0,
    allow_tie boolean DEFAULT false,
    created_at timestamp without time zone DEFAULT now(),
    updated_at timestamp without time zone DEFAULT now()
);


ALTER TABLE public.matchclass OWNER TO postgres;

--
-- Name: matchclass_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.matchclass_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.matchclass_id_seq OWNER TO postgres;

--
-- Name: matchclass_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.matchclass_id_seq OWNED BY public.matchclass.id;


--
-- Name: matches; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.matches (
    id text NOT NULL,
    team1 character varying(100),
    team2 character varying(100),
    score1 integer DEFAULT 0,
    score2 integer DEFAULT 0,
    start timestamp without time zone,
    "end" timestamp without time zone,
    "time" text,
    referee_id integer,
    note text,
    show_toggle integer DEFAULT 0,
    status character varying(50),
    tournament_id integer,
    match_class_id integer
);


ALTER TABLE public.matches OWNER TO postgres;

--
-- Name: matchsets; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.matchsets (
    id integer NOT NULL,
    match_id text NOT NULL,
    score1 integer DEFAULT 0,
    score2 integer DEFAULT 0,
    start timestamp without time zone,
    "end" timestamp without time zone,
    "time" text,
    note text,
    status character varying(50),
    classsets_id integer,
    referee_id integer,
    classsetsname character varying(100)
);


ALTER TABLE public.matchsets OWNER TO postgres;

--
-- Name: COLUMN matchsets.classsetsname; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public.matchsets.classsetsname IS 'Tên hiệp/set (e.g., Hiệp 1, Hiệp 2, Set 1, etc.)';


--
-- Name: roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.roles (
    id integer NOT NULL,
    name character varying(100) NOT NULL
);


ALTER TABLE public.roles OWNER TO postgres;

--
-- Name: roles_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.roles_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.roles_id_seq OWNER TO postgres;

--
-- Name: roles_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.roles_id_seq OWNED BY public.roles.id;


--
-- Name: systemsecrs; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.systemsecrs (
    id integer NOT NULL,
    license_data text NOT NULL,
    license_hash character varying(128) NOT NULL,
    last_update timestamp without time zone DEFAULT now(),
    updated_by integer
);


ALTER TABLE public.systemsecrs OWNER TO postgres;

--
-- Name: systemsecrs_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.systemsecrs_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.systemsecrs_id_seq OWNER TO postgres;

--
-- Name: systemsecrs_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.systemsecrs_id_seq OWNED BY public.systemsecrs.id;


--
-- Name: tournaments; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tournaments (
    id integer NOT NULL,
    name character varying(150) NOT NULL,
    start date,
    "end" date,
    description text,
    match_class_id integer
);


ALTER TABLE public.tournaments OWNER TO postgres;

--
-- Name: tournaments_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tournaments_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tournaments_id_seq OWNER TO postgres;

--
-- Name: tournaments_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tournaments_id_seq OWNED BY public.tournaments.id;


--
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    id integer NOT NULL,
    name character varying(100) NOT NULL,
    password character varying(255) NOT NULL,
    role_id integer,
    fullname character varying(150),
    phone character varying(30),
    email character varying(150),
    isactive character varying(1) DEFAULT '1'::character varying NOT NULL
);


ALTER TABLE public.users OWNER TO postgres;

--
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.users_id_seq OWNER TO postgres;

--
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- Name: activities id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.activities ALTER COLUMN id SET DEFAULT nextval('public.activities_id_seq'::regclass);


--
-- Name: classsets id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.classsets ALTER COLUMN id SET DEFAULT nextval('public.classsets_id_seq'::regclass);


--
-- Name: matchclass id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matchclass ALTER COLUMN id SET DEFAULT nextval('public.matchclass_id_seq'::regclass);


--
-- Name: roles id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roles ALTER COLUMN id SET DEFAULT nextval('public.roles_id_seq'::regclass);


--
-- Name: systemsecrs id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.systemsecrs ALTER COLUMN id SET DEFAULT nextval('public.systemsecrs_id_seq'::regclass);


--
-- Name: tournaments id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tournaments ALTER COLUMN id SET DEFAULT nextval('public.tournaments_id_seq'::regclass);


--
-- Name: users id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- Data for Name: activities; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.activities (id, user_id, machine_name, ip_address, login_time, last_ping, is_active) FROM stdin;
3	6	THI-NV-LAPTOP	192.168.100.91	2025-10-21 17:13:22.578151	2025-10-21 17:13:22.578151	f
2	4	THI-NV-LAPTOP	192.168.100.91	2025-10-21 17:13:13.359991	2025-10-21 17:13:13.359991	f
1	2	THI-NV-LAPTOP	192.168.100.91	2025-10-21 17:13:04.624607	2025-10-21 17:13:04.624607	f
\.


--
-- Data for Name: classsets; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.classsets (id, name, match_class_id) FROM stdin;
1	Hiệp 1	1
2	Hiệp 2	1
3	Hiệp phụ 1	1
4	Hiệp phụ 2	1
6	Set 1	2
7	Set 2	2
8	Set 1	3
9	Set 2	3
10	Set 1	4
11	Set 2	4
5	Đá luân lưu	1
\.


--
-- Data for Name: matchclass; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.matchclass (id, name, period_type, standard_periods, periods_to_win, allow_overtime, max_overtime_periods, allow_tie, created_at, updated_at) FROM stdin;
1	Bóng đá	half	2	\N	t	2	t	2025-10-17 01:49:07.415816	2025-10-17 01:49:20.180465
2	Bóng chuyền	set	5	3	f	0	f	2025-10-17 01:49:07.415816	2025-10-17 01:49:20.180465
3	Cầu lông	set	3	2	f	0	f	2025-10-17 01:49:07.415816	2025-10-17 01:49:20.180465
4	Bóng rổ	quarter	4	\N	t	1	f	2025-10-17 01:49:07.415816	2025-10-17 01:49:20.180465
\.


--
-- Data for Name: matches; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.matches (id, team1, team2, score1, score2, start, "end", "time", referee_id, note, show_toggle, status, tournament_id, match_class_id) FROM stdin;
\.


--
-- Data for Name: matchsets; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.matchsets (id, match_id, score1, score2, start, "end", "time", note, status, classsets_id, referee_id, classsetsname) FROM stdin;
\.


--
-- Data for Name: roles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.roles (id, name) FROM stdin;
1	Admin
2	Referee
3	Khác
\.


--
-- Data for Name: systemsecrs; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.systemsecrs (id, license_data, license_hash, last_update, updated_by) FROM stdin;
2	{\n  "iv": "u98UGWEi/BQH0lRsgEuNfw==",\n  "cipher": "nbcR4A2xM+5hJKYXQPjhfP6KSurPVhrGVnty+Iv4bhs=",\n  "mac": "M+46gELyoOYgDcN3TqCs8CkArGjYi/NsaNIu+ifpt3U="\n}	f5dff8feeb7be1d2d4fef6e2e66499800cb31d8c7755894f73da466dae9527ed	2025-10-21 17:03:06.041771	2
3	{\n  "iv": "8sP+dHKLP0YCtr+CFUYFSA==",\n  "cipher": "VnXWBeXEsQeYDImnlIpN4tPZanYNSkAMDK0zvd/D//0=",\n  "mac": "ANT22E/uYt1e5iAhmSodupRGl9gsjlUjrV7x8VuScv4="\n}	a244acd4704cf48472b4e51d89ed907fd85f3f454f139016068319211ad7caf0	2025-10-21 17:12:31.127768	2
\.


--
-- Data for Name: tournaments; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tournaments (id, name, start, "end", description, match_class_id) FROM stdin;
9	Giải vô địch cầu lông FAD	2025-10-18	2025-10-28		3
8	Giải vô địch bóng đá FLeague	2025-10-17	2025-10-27		1
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (id, name, password, role_id, fullname, phone, email, isactive) FROM stdin;
2	Admin	302e703144ab44ae:6E39jp/2XQjh3EvPGFdtZvQl0HT/AZiXaIpP1lCL2Dg=	1	Administrator			1
5	binhnv	dedc3d3d496e4014:hsaN91KBNr+pi3sOjByc0WX3UQdZOpBwcCxF9jIUXqU=	2	Bình	\N	\N	0
6	trongtai01	94b178880f68474d:aQhPfcrZWylMebq+zaODEzbQ8lKclL4uBIT3u8hbxPw=	2	Nguyễn Minh Tuấn			1
4	congvc	ada004f2a88e43d7:PUeS2GWpUYypA8oRpTSU94cGzfdKVW4RVeG8fEoQ+Y8=	2	Võ Chí Công			1
3	hoangad	723c88f231ba498a:Jj26qq4S9NVrVmk5Ig653cVhWXm1YaGA/ax6DF4liLA=	1	Hoàng	\N	\N	0
7	trongnv	ad77000eb45c4636:xUffI/NFMUecgArOnmsXspuDIPlQXf74iqHFABzOxts=	2	Nguyễn Văn Trọng			1
\.


--
-- Name: activities_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.activities_id_seq', 14, true);


--
-- Name: classsets_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.classsets_id_seq', 11, true);


--
-- Name: matchclass_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.matchclass_id_seq', 4, true);


--
-- Name: roles_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.roles_id_seq', 3, true);


--
-- Name: systemsecrs_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.systemsecrs_id_seq', 3, true);


--
-- Name: tournaments_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tournaments_id_seq', 9, true);


--
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 7, true);


--
-- Name: activities activities_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.activities
    ADD CONSTRAINT activities_pkey PRIMARY KEY (id);


--
-- Name: classsets classsets_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.classsets
    ADD CONSTRAINT classsets_pkey PRIMARY KEY (id);


--
-- Name: matchclass matchclass_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matchclass
    ADD CONSTRAINT matchclass_pkey PRIMARY KEY (id);


--
-- Name: matches matches_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matches
    ADD CONSTRAINT matches_pkey PRIMARY KEY (id);


--
-- Name: matchsets matchsets_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matchsets
    ADD CONSTRAINT matchsets_pkey PRIMARY KEY (id, match_id);


--
-- Name: roles roles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_pkey PRIMARY KEY (id);


--
-- Name: systemsecrs systemsecrs_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.systemsecrs
    ADD CONSTRAINT systemsecrs_pkey PRIMARY KEY (id);


--
-- Name: tournaments tournaments_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tournaments
    ADD CONSTRAINT tournaments_pkey PRIMARY KEY (id);


--
-- Name: activities uq_machine_ip; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.activities
    ADD CONSTRAINT uq_machine_ip UNIQUE (user_id, machine_name, ip_address);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- Name: activities activities_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.activities
    ADD CONSTRAINT activities_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- Name: matches fk_matches_match_class; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matches
    ADD CONSTRAINT fk_matches_match_class FOREIGN KEY (match_class_id) REFERENCES public.matchclass(id);


--
-- Name: matches matches_tournament_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matches
    ADD CONSTRAINT matches_tournament_id_fkey FOREIGN KEY (tournament_id) REFERENCES public.tournaments(id) ON DELETE CASCADE;


--
-- Name: matchsets matchsets_classsets_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matchsets
    ADD CONSTRAINT matchsets_classsets_id_fkey FOREIGN KEY (classsets_id) REFERENCES public.classsets(id) ON DELETE SET NULL;


--
-- Name: matchsets matchsets_match_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matchsets
    ADD CONSTRAINT matchsets_match_id_fkey FOREIGN KEY (match_id) REFERENCES public.matches(id) ON DELETE CASCADE;


--
-- Name: users users_role_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_role_id_fkey FOREIGN KEY (role_id) REFERENCES public.roles(id) ON DELETE SET NULL;


--
-- PostgreSQL database dump complete
--

\unrestrict y7qAMwNo561Z93ueIPW1yuWsHsd5rD5xa2pURqW1TQftHAhPgC3RiPRdCs57N9H

