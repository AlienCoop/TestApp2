--
-- PostgreSQL database dump
--

-- Dumped from database version 14.5
-- Dumped by pg_dump version 14.5

-- Started on 2022-08-30 18:59:59

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
-- TOC entry 3325 (class 1262 OID 16881)
-- Name: TestDb; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "TestDb" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Russian_Russia.1251';


ALTER DATABASE "TestDb" OWNER TO postgres;

\connect "TestDb"

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
-- TOC entry 212 (class 1259 OID 16891)
-- Name: Tasks; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Tasks" (
    "TaskID" integer NOT NULL,
    "Name" character varying(100) NOT NULL,
    "Description" text NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "UpdatedDate" timestamp without time zone,
    "TaskStatus" integer,
    "TaskCreaterID" integer NOT NULL,
    "TaskWorkerID" integer NOT NULL
);


ALTER TABLE public."Tasks" OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 16890)
-- Name: Tasks_TaskID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Tasks" ALTER COLUMN "TaskID" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Tasks_TaskID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 210 (class 1259 OID 16883)
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "UserID" integer NOT NULL,
    "Name" character varying(100) NOT NULL,
    "Surname" text NOT NULL,
    "DateOfCreation" timestamp without time zone NOT NULL,
    "DateOfModification" timestamp without time zone,
    "Status" integer
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- TOC entry 209 (class 1259 OID 16882)
-- Name: Users_UserID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Users" ALTER COLUMN "UserID" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Users_UserID_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 3319 (class 0 OID 16891)
-- Dependencies: 212
-- Data for Name: Tasks; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (6, 'Programming', 'You need to programme something', '2022-08-20 16:48:00', '2022-08-21 16:48:00', 1, 10, 12);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (9, 'Programming', 'OneTwoThree', '2022-08-29 19:42:00', '2022-08-29 19:42:00', 1, 10, 14);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (11, 'Abcabc', 'Some description', '2022-08-30 15:47:00', '2022-08-30 15:48:00', 1, 9, 11);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (12, 'Module', 'ThreeFourFive', '2022-08-12 16:56:00', '2022-08-12 16:56:00', 0, 9, 8);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (13, 'Module', 'FourFiveSix', '2022-08-27 16:57:00', '2022-08-27 16:57:00', 1, 12, 7);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (14, 'Jaja', 'Jajajaja', '2022-08-14 16:58:00', '2022-08-15 16:58:00', 1, 15, 10);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (15, 'Paint', 'Paint something', '2022-08-26 16:59:00', '2022-08-26 16:59:00', 1, 8, 9);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (10, 'Paint', 'Do some paint', '2022-08-30 14:56:00', '2022-08-30 14:56:00', 1, 15, 9);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (7, 'Programming', 'Do it again', '2022-08-28 16:50:00', '2022-08-28 16:50:00', 4, 15, 9);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (16, 'logic', 'Just do something', '2022-08-06 17:43:00', '2022-08-07 17:43:00', 1, 8, 14);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (17, 'Paint', 'Do it again', '2022-08-07 17:44:00', '2022-08-13 17:44:00', 0, 15, 12);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (18, 'logic', 'ThreeFourFive', '2022-08-13 17:45:00', '2022-08-13 17:45:00', 4, 11, 7);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (19, 'Module', 'FourFiveSix', '2022-08-11 17:46:00', '2022-08-12 17:46:00', 0, 9, 14);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (20, 'Bob1231', 'FourFiveSix', '2022-08-13 17:46:00', '2022-08-14 17:46:00', 1, 15, 15);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (21, 'Testing', 'ThreeFourFive', '2022-08-13 17:47:00', '2022-08-14 17:47:00', 2, 9, 14);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (22, 'ASDASD', 'Do some paint', '2022-08-26 17:48:00', '2022-08-27 17:48:00', 2, 7, 14);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (23, 'ASDASD', 'SevenEleven', '2022-08-29 17:48:00', '2022-08-30 17:48:00', 4, 10, 12);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (24, 'Programming', 'SevenEleven', '2022-08-30 17:49:00', '2022-08-30 17:49:00', 1, 12, 14);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (25, 'Programming', 'ThreeFourFive', '2022-08-30 17:50:00', '2022-08-29 17:50:00', 0, 15, 15);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (26, 'Module', 'Once again plz', '2022-08-26 17:50:00', '2022-08-27 17:50:00', 2, 10, 14);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (27, 'Jajaja', 'jajajajaja', '2022-08-21 17:51:00', '2022-08-21 17:51:00', 2, 14, 7);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (28, 'lastone', 'lastone', '2022-08-25 17:51:00', '2022-08-25 17:51:00', 1, 9, 11);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (29, 'lastone', 'jaja', '2022-08-03 17:51:00', '2022-08-03 17:51:00', 2, 14, 12);
INSERT INTO public."Tasks" ("TaskID", "Name", "Description", "CreatedDate", "UpdatedDate", "TaskStatus", "TaskCreaterID", "TaskWorkerID") VALUES (30, 'Paint', 'FourFiveSix', '2022-08-12 17:52:00', '2022-08-12 17:52:00', 0, 8, 8);


--
-- TOC entry 3317 (class 0 OID 16883)
-- Dependencies: 210
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Users" ("UserID", "Name", "Surname", "DateOfCreation", "DateOfModification", "Status") VALUES (8, 'Elvis', 'Presley', '2022-08-20 16:31:00', '2022-08-20 16:31:00', 0);
INSERT INTO public."Users" ("UserID", "Name", "Surname", "DateOfCreation", "DateOfModification", "Status") VALUES (11, 'Bobby', 'Sobaken', '2022-08-21 16:32:00', '2022-08-22 16:32:00', 0);
INSERT INTO public."Users" ("UserID", "Name", "Surname", "DateOfCreation", "DateOfModification", "Status") VALUES (9, 'James', 'Brown', '2022-08-25 16:31:00', '2022-08-26 16:31:00', 0);
INSERT INTO public."Users" ("UserID", "Name", "Surname", "DateOfCreation", "DateOfModification", "Status") VALUES (7, 'Bob', 'Marley', '2022-08-12 16:31:00', '2022-08-29 19:32:24.323262', 0);
INSERT INTO public."Users" ("UserID", "Name", "Surname", "DateOfCreation", "DateOfModification", "Status") VALUES (12, 'Bob1231', 'Presley32323', '2022-08-06 17:30:00', '2022-08-29 19:33:45.984807', 0);
INSERT INTO public."Users" ("UserID", "Name", "Surname", "DateOfCreation", "DateOfModification", "Status") VALUES (14, 'Allow11', 'Dies', '2022-08-29 19:34:00', '2022-08-29 19:40:23.145713', 0);
INSERT INTO public."Users" ("UserID", "Name", "Surname", "DateOfCreation", "DateOfModification", "Status") VALUES (10, 'Jackie', 'Wilson123', '2022-08-07 16:32:00', '2022-08-29 21:47:28.478459', 0);
INSERT INTO public."Users" ("UserID", "Name", "Surname", "DateOfCreation", "DateOfModification", "Status") VALUES (15, 'Матье', 'Marley', '2022-08-29 21:47:00', '2022-08-29 21:52:00', 0);


--
-- TOC entry 3326 (class 0 OID 0)
-- Dependencies: 211
-- Name: Tasks_TaskID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Tasks_TaskID_seq"', 30, true);


--
-- TOC entry 3327 (class 0 OID 0)
-- Dependencies: 209
-- Name: Users_UserID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Users_UserID_seq"', 15, true);


--
-- TOC entry 3174 (class 2606 OID 16897)
-- Name: Tasks PK_Tasks; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Tasks"
    ADD CONSTRAINT "PK_Tasks" PRIMARY KEY ("TaskID");


--
-- TOC entry 3170 (class 2606 OID 16889)
-- Name: Users PK_Users; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "PK_Users" PRIMARY KEY ("UserID");


--
-- TOC entry 3171 (class 1259 OID 16908)
-- Name: IX_Tasks_TaskCreaterID; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Tasks_TaskCreaterID" ON public."Tasks" USING btree ("TaskCreaterID");


--
-- TOC entry 3172 (class 1259 OID 16909)
-- Name: IX_Tasks_TaskWorkerID; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Tasks_TaskWorkerID" ON public."Tasks" USING btree ("TaskWorkerID");


--
-- TOC entry 3175 (class 2606 OID 16898)
-- Name: Tasks FK_Tasks_Users_TaskCreaterID; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Tasks"
    ADD CONSTRAINT "FK_Tasks_Users_TaskCreaterID" FOREIGN KEY ("TaskCreaterID") REFERENCES public."Users"("UserID") ON DELETE CASCADE;


--
-- TOC entry 3176 (class 2606 OID 16903)
-- Name: Tasks FK_Tasks_Users_TaskWorkerID; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Tasks"
    ADD CONSTRAINT "FK_Tasks_Users_TaskWorkerID" FOREIGN KEY ("TaskWorkerID") REFERENCES public."Users"("UserID") ON DELETE CASCADE;


-- Completed on 2022-08-30 18:59:59

--
-- PostgreSQL database dump complete
--

