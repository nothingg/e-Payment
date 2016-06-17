create table b_test_gam (
    acid VARCHAR2 (11 Char) PRIMARY KEY  ,
    sol_id VARCHAR2 (8 Char), 
    foracid  VARCHAR2 (16 Char)   , 
    acct_name VARCHAR2 (80 Char) , 
    schm_code VARCHAR2 (5 Char), 
    clr_bal_amt NUMBER (20,4)
);

insert into b_test_gam 
(
    select acid , sol_id , foracid , acct_name , schm_code , clr_bal_amt  from tbaadm.gam where foracid = '001150436382'
    )    