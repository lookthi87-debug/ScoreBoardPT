--
-- PostgreSQL database dump
--

\restrict KRxe71bmYQ6TXkMyoLp1yW70gkbFvMsKS3mr0NUSSAo5CIB5L1h9WMSdfg4JgR1

-- Dumped from database version 18.0
-- Dumped by pg_dump version 18.0

-- Started on 2025-10-18 10:47:17

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 233 (class 1255 OID 16648)
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
-- TOC entry 219 (class 1259 OID 16519)
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
-- TOC entry 220 (class 1259 OID 16526)
-- Name: activities_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.activities_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.activities_id_seq OWNER TO postgres;

--
-- TOC entry 5095 (class 0 OID 0)
-- Dependencies: 220
-- Name: activities_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.activities_id_seq OWNED BY public.activities.id;


--
-- TOC entry 221 (class 1259 OID 16527)
-- Name: classsets; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.classsets (
    id integer NOT NULL,
    name character varying(150) NOT NULL,
    match_class_id integer
);


ALTER TABLE public.classsets OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 16532)
-- Name: classsets_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.classsets_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.classsets_id_seq OWNER TO postgres;

--
-- TOC entry 5096 (class 0 OID 0)
-- Dependencies: 222
-- Name: classsets_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.classsets_id_seq OWNED BY public.classsets.id;


--
-- TOC entry 223 (class 1259 OID 16533)
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
-- TOC entry 224 (class 1259 OID 16538)
-- Name: matchclass_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.matchclass_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.matchclass_id_seq OWNER TO postgres;

--
-- TOC entry 5097 (class 0 OID 0)
-- Dependencies: 224
-- Name: matchclass_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.matchclass_id_seq OWNED BY public.matchclass.id;


--
-- TOC entry 225 (class 1259 OID 16539)
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
-- TOC entry 226 (class 1259 OID 16548)
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
-- TOC entry 5098 (class 0 OID 0)
-- Dependencies: 226
-- Name: COLUMN matchsets.classsetsname; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public.matchsets.classsetsname IS 'Tên hiệp/set (e.g., Hiệp 1, Hiệp 2, Set 1, etc.)';


--
-- TOC entry 227 (class 1259 OID 16557)
-- Name: roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.roles (
    id integer NOT NULL,
    name character varying(100) NOT NULL
);


ALTER TABLE public.roles OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 16562)
-- Name: roles_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.roles_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.roles_id_seq OWNER TO postgres;

--
-- TOC entry 5099 (class 0 OID 0)
-- Dependencies: 228
-- Name: roles_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.roles_id_seq OWNED BY public.roles.id;


--
-- TOC entry 229 (class 1259 OID 16563)
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
-- TOC entry 230 (class 1259 OID 16570)
-- Name: tournaments_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tournaments_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.tournaments_id_seq OWNER TO postgres;

--
-- TOC entry 5100 (class 0 OID 0)
-- Dependencies: 230
-- Name: tournaments_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tournaments_id_seq OWNED BY public.tournaments.id;


--
-- TOC entry 231 (class 1259 OID 16571)
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
-- TOC entry 232 (class 1259 OID 16581)
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.users_id_seq OWNER TO postgres;

--
-- TOC entry 5101 (class 0 OID 0)
-- Dependencies: 232
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- TOC entry 4890 (class 2604 OID 16582)
-- Name: activities id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.activities ALTER COLUMN id SET DEFAULT nextval('public.activities_id_seq'::regclass);


--
-- TOC entry 4892 (class 2604 OID 16583)
-- Name: classsets id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.classsets ALTER COLUMN id SET DEFAULT nextval('public.classsets_id_seq'::regclass);


--
-- TOC entry 4893 (class 2604 OID 16584)
-- Name: matchclass id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matchclass ALTER COLUMN id SET DEFAULT nextval('public.matchclass_id_seq'::regclass);


--
-- TOC entry 4904 (class 2604 OID 16585)
-- Name: roles id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roles ALTER COLUMN id SET DEFAULT nextval('public.roles_id_seq'::regclass);


--
-- TOC entry 4905 (class 2604 OID 16586)
-- Name: tournaments id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tournaments ALTER COLUMN id SET DEFAULT nextval('public.tournaments_id_seq'::regclass);


--
-- TOC entry 4906 (class 2604 OID 16587)
-- Name: users id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- TOC entry 5076 (class 0 OID 16519)
-- Dependencies: 219
-- Data for Name: activities; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.activities (id, user_id, activity, date) FROM stdin;
\.


--
-- TOC entry 5078 (class 0 OID 16527)
-- Dependencies: 221
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
-- TOC entry 5080 (class 0 OID 16533)
-- Dependencies: 223
-- Data for Name: matchclass; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.matchclass (id, name, period_type, standard_periods, periods_to_win, allow_overtime, max_overtime_periods, allow_tie, created_at, updated_at) FROM stdin;
1	Bóng đá	half	2	\N	t	2	t	2025-10-17 01:49:07.415816	2025-10-17 01:49:20.180465
2	Bóng chuyền	set	5	3	f	0	f	2025-10-17 01:49:07.415816	2025-10-17 01:49:20.180465
3	Cầu lông	set	3	2	f	0	f	2025-10-17 01:49:07.415816	2025-10-17 01:49:20.180465
4	Bóng rổ	quarter	4	\N	t	1	f	2025-10-17 01:49:07.415816	2025-10-17 01:49:20.180465
\.


--
-- TOC entry 5082 (class 0 OID 16539)
-- Dependencies: 225
-- Data for Name: matches; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.matches (id, team1, team2, score1, score2, start, "end", "time", referee_id, note, show_toggle, status, tournament_id, match_class_id) FROM stdin;
20251017-00006	xcv	xcvxxx	4	5	\N	\N	01:10	6	[Referees:6:trongtai01]	0	1	8	\N
20251017-00003	ẻt	dfg	0	0	\N	\N	22:25	3	[Referees:3:hoangad]	0	1	8	\N
\.


--
-- TOC entry 5083 (class 0 OID 16548)
-- Dependencies: 226
-- Data for Name: matchsets; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.matchsets (id, match_id, score1, score2, start, "end", "time", note, status, classsets_id, referee_id, classsetsname) FROM stdin;
1	20251017-00003	0	0	\N	\N	00:00		1	1	3	Hiệp 1
8	20251017-00006	3	3	\N	\N	00:19		2	1	6	Hiệp 1
\.


--
-- TOC entry 5084 (class 0 OID 16557)
-- Dependencies: 227
-- Data for Name: roles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.roles (id, name) FROM stdin;
1	Admin
2	Referee
3	Khác
\.


--
-- TOC entry 5086 (class 0 OID 16563)
-- Dependencies: 229
-- Data for Name: tournaments; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tournaments (id, name, start, "end", description, match_class_id) FROM stdin;
8	Bong đá VN	2025-10-17	2025-10-27		1
9	Cau long	2025-10-18	2025-10-28		3
\.


--
-- TOC entry 5088 (class 0 OID 16571)
-- Dependencies: 231
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (id, name, password, role_id, fullname, phone, email, isactive) FROM stdin;
2	Admin	302e703144ab44ae:6E39jp/2XQjh3EvPGFdtZvQl0HT/AZiXaIpP1lCL2Dg=	1	Administrator			1
3	hoangad	723c88f231ba498a:Jj26qq4S9NVrVmk5Ig653cVhWXm1YaGA/ax6DF4liLA=	1	Hoàng	\N	\N	1
4	congvc	96715e1761174a67:dGPWU4uY2PjQrc69kjN+dLU3rMH0szuaWPQ9MNqIlgc=	2	Công	\N	\N	1
5	binhnv	dedc3d3d496e4014:hsaN91KBNr+pi3sOjByc0WX3UQdZOpBwcCxF9jIUXqU=	2	Bình	\N	\N	0
6	trongtai01	94b178880f68474d:aQhPfcrZWylMebq+zaODEzbQ8lKclL4uBIT3u8hbxPw=	2	trong tai3333	\N	\N	1
\.


--
-- TOC entry 5102 (class 0 OID 0)
-- Dependencies: 220
-- Name: activities_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.activities_id_seq', 1, false);


--
-- TOC entry 5103 (class 0 OID 0)
-- Dependencies: 222
-- Name: classsets_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.classsets_id_seq', 11, true);


--
-- TOC entry 5104 (class 0 OID 0)
-- Dependencies: 224
-- Name: matchclass_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.matchclass_id_seq', 4, true);


--
-- TOC entry 5105 (class 0 OID 0)
-- Dependencies: 228
-- Name: roles_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.roles_id_seq', 3, true);


--
-- TOC entry 5106 (class 0 OID 0)
-- Dependencies: 230
-- Name: tournaments_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tournaments_id_seq', 9, true);


--
-- TOC entry 5107 (class 0 OID 0)
-- Dependencies: 232
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 6, true);


--
-- TOC entry 4909 (class 2606 OID 16589)
-- Name: activities activities_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.activities
    ADD CONSTRAINT activities_pkey PRIMARY KEY (id);


--
-- TOC entry 4911 (class 2606 OID 16591)
-- Name: classsets classsets_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.classsets
    ADD CONSTRAINT classsets_pkey PRIMARY KEY (id);


--
-- TOC entry 4913 (class 2606 OID 16593)
-- Name: matchclass matchclass_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matchclass
    ADD CONSTRAINT matchclass_pkey PRIMARY KEY (id);


--
-- TOC entry 4915 (class 2606 OID 16595)
-- Name: matches matches_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matches
    ADD CONSTRAINT matches_pkey PRIMARY KEY (id);


--
-- TOC entry 4917 (class 2606 OID 16597)
-- Name: matchsets matchsets_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matchsets
    ADD CONSTRAINT matchsets_pkey PRIMARY KEY (id, match_id);


--
-- TOC entry 4919 (class 2606 OID 16599)
-- Name: roles roles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_pkey PRIMARY KEY (id);


--
-- TOC entry 4921 (class 2606 OID 16601)
-- Name: tournaments tournaments_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tournaments
    ADD CONSTRAINT tournaments_pkey PRIMARY KEY (id);


--
-- TOC entry 4923 (class 2606 OID 16603)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- TOC entry 4924 (class 2606 OID 16680)
-- Name: matches fk_matches_match_class; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matches
    ADD CONSTRAINT fk_matches_match_class FOREIGN KEY (match_class_id) REFERENCES public.matchclass(id);


--
-- TOC entry 4925 (class 2606 OID 16604)
-- Name: matches matches_tournament_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matches
    ADD CONSTRAINT matches_tournament_id_fkey FOREIGN KEY (tournament_id) REFERENCES public.tournaments(id) ON DELETE CASCADE;


--
-- TOC entry 4926 (class 2606 OID 16609)
-- Name: matchsets matchsets_classsets_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matchsets
    ADD CONSTRAINT matchsets_classsets_id_fkey FOREIGN KEY (classsets_id) REFERENCES public.classsets(id) ON DELETE SET NULL;


--
-- TOC entry 4927 (class 2606 OID 16614)
-- Name: matchsets matchsets_match_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.matchsets
    ADD CONSTRAINT matchsets_match_id_fkey FOREIGN KEY (match_id) REFERENCES public.matches(id) ON DELETE CASCADE;


--
-- TOC entry 4928 (class 2606 OID 16619)
-- Name: users users_role_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_role_id_fkey FOREIGN KEY (role_id) REFERENCES public.roles(id) ON DELETE SET NULL;


-- Completed on 2025-10-18 10:47:17

--
-- PostgreSQL database dump complete
--

\unrestrict KRxe71bmYQ6TXkMyoLp1yW70gkbFvMsKS3mr0NUSSAo5CIB5L1h9WMSdfg4JgR1

