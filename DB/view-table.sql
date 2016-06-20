drop table B_Table_EntitiesVIEW_GAM;

create table B_Table_EntitiesVIEW_GAM  (
    ACID VARCHAR2 (11 Char) PRIMARY KEY not null,
    SOL_ID VARCHAR2 (8 Char),
    FORACID VARCHAR2 (16 Char),
    ACCT_NAME VARCHAR2 (80 Char),
    SCHM_CODE VARCHAR2 (5 Char),
    CLR_BAL_AMT NUMBER (20,4) 
);                