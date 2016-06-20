DROP VIEW CUSTOM.B_VIEW_GAM;

CREATE OR REPLACE FORCE VIEW B_VIEW_GAM
(
     acid ,
      sol_id , foracid , acct_name , schm_code , clr_bal_amt,
      CONSTRAINT id_acid PRIMARY KEY (acid)  RELY DISABLE NOVALIDATE 
) as
    select acid , sol_id , foracid , acct_name , schm_code , clr_bal_amt  from tbaadm.gam
    