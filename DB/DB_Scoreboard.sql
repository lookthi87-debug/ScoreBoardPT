--
-- PostgreSQL database dump
--

\restrict TjgvxMagHAX8VdMkkNyipEVddRFxlbW9o4m1W0SFcRTALwt15jO3UK0QdQE7D4T

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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: activities; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.activities (
    id integer NOT NULL,
    user_id integer,
    activity text,
    date timestamp without time zone DEFAULT now()
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
    name character varying(150) NOT NULL
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
    tournament_id integer
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
    referee_id integer
);


ALTER TABLE public.matchsets OWNER TO postgres;

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

COPY public.activities (id, user_id, activity, date) FROM stdin;
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

COPY public.matchclass (id, name) FROM stdin;
1	Bóng đá
2	Bóng chuyền
3	Cầu lông
4	Bóng rổ
\.


--
-- Data for Name: matches; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.matches (id, team1, team2, score1, score2, start, "end", "time", referee_id, note, show_toggle, status, tournament_id) FROM stdin;
20251009-00001	SG1	TN1	1	0	\N	\N	00:30	4		1	2	1
20251010-00003	Nam Định	Bình Dương	0	0	\N	\N	00:00	4		0	0	1
20251010-00001	DT3	SG2	1	0	\N	\N	00:00	5		1	1	1
20251010-00002	CAHN	HP	0	1	\N	\N	00:00	4		2	1	1
\.


--
-- Data for Name: matchsets; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.matchsets (id, match_id, score1, score2, start, "end", "time", note, status, classsets_id, referee_id) FROM stdin;
1	20251009-00001	1	0	\N	\N	00:05		2	1	4
4	20251010-00001	0	0	\N	\N	00:00		0	2	5
2	20251010-00002	0	0	\N	\N	00:00		0	2	4
1	20251010-00001	1	0	\N	\N	00:00		1	1	5
1	20251010-00002	0	1	\N	\N	00:00		1	1	4
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
-- Data for Name: tournaments; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tournaments (id, name, start, "end", description, match_class_id) FROM stdin;
1	Đại hội TDTT	2025-10-01	2025-10-15		1
2	Đại hội thao cấp leader (Đông Á)	2025-10-08	2025-10-15		1
3	Đại hội trường Nguyễn Khuyến	2025-10-16	2025-10-20		1
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (id, name, password, role_id, fullname, phone, email, isactive) FROM stdin;
2	Admin	302e703144ab44ae:6E39jp/2XQjh3EvPGFdtZvQl0HT/AZiXaIpP1lCL2Dg=	1	Administrator			1
3	hoangad	723c88f231ba498a:Jj26qq4S9NVrVmk5Ig653cVhWXm1YaGA/ax6DF4liLA=	1	Hoàng	\N	\N	1
4	congvc	96715e1761174a67:dGPWU4uY2PjQrc69kjN+dLU3rMH0szuaWPQ9MNqIlgc=	2	Công	\N	\N	1
5	binhnv	dedc3d3d496e4014:hsaN91KBNr+pi3sOjByc0WX3UQdZOpBwcCxF9jIUXqU=	2	Bình	\N	\N	1
\.


--
-- Name: activities_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.activities_id_seq', 1, false);


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
-- Name: tournaments_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tournaments_id_seq', 3, true);


--
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 5, true);


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
-- Name: tournaments tournaments_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tournaments
    ADD CONSTRAINT tournaments_pkey PRIMARY KEY (id);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


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

\unrestrict TjgvxMagHAX8VdMkkNyipEVddRFxlbW9o4m1W0SFcRTALwt15jO3UK0QdQE7D4T

