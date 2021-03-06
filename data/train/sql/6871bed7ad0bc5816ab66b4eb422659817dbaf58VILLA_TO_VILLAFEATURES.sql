
  CREATE TABLE "SYSTEM"."VILLA_TO_VILLAFEATURES" 
   (	"VILLA_ID" VARCHAR2(20 BYTE) NOT NULL ENABLE, 
	"FEATURE_ID" VARCHAR2(20 BYTE) NOT NULL ENABLE, 
	 CONSTRAINT "VILLA_TO_VILLAFEATURES_PK" PRIMARY KEY ("VILLA_ID", "FEATURE_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE, 
	 CONSTRAINT "FK_VILLA_ID" FOREIGN KEY ("VILLA_ID")
	  REFERENCES "SYSTEM"."VILLA" ("VILLA_ID") ON DELETE CASCADE ENABLE, 
	 CONSTRAINT "FK_FEATURE_ID" FOREIGN KEY ("FEATURE_ID")
	  REFERENCES "SYSTEM"."VILLA_FEATURES" ("FEATURE_ID") ON DELETE CASCADE ENABLE
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
 
