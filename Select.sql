select * from USER_TYPES
select * from USERS
SELECT * FROM ACCOUNTS
SELECT * FROM CARDS
select * from USERS where USERS_ID=
select CARD_STATUS_ID,CARD_STATUS_NAME from CARD_STATUS
select CARD_TYPE_ID as TYPE,CARD_TYPE_NAME as NAME from CARD_TYPES
select CARD_STATUS_ID as ID,CARD_STATUS_NAME as NAME from CARD_STATUS
select CARD_ID as ID, CARD_TYPE as TYPE, CARD_STATUS as STATUS, CARD_DESCRIPTION as DESCRIPTION from CARDS
insert into CARDS(CARD_ID,CARD_TYPE,CARD_STATUS) values ('002','NhanVien','CSD')
SELECT * FROM USERS WHERE USERS_NAME LIKE 'L%'
select * from USERS where USERS_ID='NV_001'
exec STORE_CARD_UPDATE '1438495269','DSD'
select ACCOUNT_ID,ACCOUNT_CARD_ID from ACCOUNTS where ACCOUNT_USERS_ID='NV001'
