CREATE OR REPLACE PROCEDURE B_P_GAM (  OUT_CURSOR    OUT SYS_REFCURSOR)
IS
BEGIN
    OPEN OUT_CURSOR FOR
         SELECT 
            acid , sol_id , foracid , acct_name , schm_code , clr_bal_amt
          FROM tbaadm.gam where foracid = '001150436382';
    END B_P_GAM;