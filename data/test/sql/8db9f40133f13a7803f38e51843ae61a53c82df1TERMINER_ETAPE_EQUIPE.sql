--------------------------------------------------------
--  DDL for Table TERMINER_ETAPE_EQUIPE
--------------------------------------------------------

  CREATE TABLE "G11_FLIGHT"."TERMINER_ETAPE_EQUIPE" 
   (	"TOUR_ANNEE" NUMBER(4,0), 
	"EQUIPE_NUM" NUMBER(2,0), 
	"ETAPE_NUM" NUMBER(2,0), 
	"EQUIPE_NOM" VARCHAR2(50 BYTE), 
	"EQUIPE_PAYS" VARCHAR2(50 BYTE), 
	"ETAPE_EQUI_TPS" NUMBER(10,0), 
	"ETAPE_EQUI_CLASS" NUMBER(2,0), 
	"GENE_EQUI_TPS" NUMBER(10,0), 
	"GENE_EQUI_CLASS" NUMBER(2,0), 
	 CONSTRAINT "PK_TERMINER_ETAPE_EQUIPE" PRIMARY KEY ("TOUR_ANNEE", "EQUIPE_NUM", "ETAPE_NUM") ENABLE
   ) ORGANIZATION INDEX NOCOMPRESS PCTFREE 10 INITRANS 2 MAXTRANS 255 LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "BD50_DATA" 
 PCTTHRESHOLD 50;
