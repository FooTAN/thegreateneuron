DROP DATABASE IF EXISTS `auth`;
CREATE DATABASE `auth`;
USE `auth`;

CREATE TABLE `Users` (
  `Id` char(38) NOT NULL,
  `UserName` varchar(99) CHARACTER SET utf8 NOT NULL,
  `PasswordHash` BLOB,
  `PasswordSalt` BLOB,
  `IsAdmin` tinyint(1),
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UC_User` (`Id`,`UserName`)
);

