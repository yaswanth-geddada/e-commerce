
CREATE DATABASE ECOMM;

CREATE TABLE USERS
(

  USER_ID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  USER_FULLNAME VARCHAR(50) NOT NULL,
  USER_EMAIL VARCHAR(255) NOT NULL,
  USER_USERNAME VARCHAR(10) NOT NULL,
  USER_PASSWORD VARCHAR(255) NOT NULL,

);


CREATE TABLE PRODUCTS
(

  PRO_ID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  PRO_NAME VARCHAR(255) NOT NULL,
  PRO_QUANTITY INT NOT NULL,
  PRO_VENDERID BIGINT NOT NULL,


);

CREATE TABLE CART (

  CART_ID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  CART_ITEMID BIGINT NOT NULL,
  CART_USERID BIGINT NOT NULL,
  CART_ITEMNAME VARCHAR(255) NOT NULL,
  CART_ITEMQUANTITY INT NOT NULL,
  CART_ITEMPRICE FLOAT NOT NULL,
  FOREIGN KEY (CART_ITEMID) REFERENCES PRODUCTS(PRO_ID) ON DELETE CASCADE,
  FOREIGN KEY (CART_USERID) REFERENCES USERS(USER_ID) ON DELETE CASCADE

);

CREATE TABLE ORDERS(

);