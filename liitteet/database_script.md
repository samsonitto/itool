# Tietokannanluontiskripti

```sql
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema M3156_3
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema M3156_3
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `M3156_3` DEFAULT CHARACTER SET utf8 ;
USE `M3156_3` ;

-- -----------------------------------------------------
-- Table `M3156_3`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `M3156_3`.`user` (
  `userID` INT NOT NULL AUTO_INCREMENT,
  `userName` VARCHAR(45) NOT NULL,
  `userSurname` VARCHAR(45) NOT NULL,
  `userAddress` VARCHAR(128) NOT NULL,
  `userEmail` VARCHAR(128) NOT NULL,
  `userLocation` VARCHAR(128) NOT NULL,
  `paymentMethod` VARCHAR(128) NOT NULL,
  `userMobile` VARCHAR(45) NOT NULL,
  `userPassword` VARCHAR(45) NOT NULL,
  `userPicture` VARCHAR(128) NULL,
  PRIMARY KEY (`userID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `M3156_3`.`toolCategory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `M3156_3`.`toolCategory` (
  `toolCategoryID` INT NOT NULL AUTO_INCREMENT,
  `toolCategoryName` VARCHAR(128) NOT NULL,
  `toolCategoryDescription` VARCHAR(1000) NOT NULL,
  PRIMARY KEY (`toolCategoryID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `M3156_3`.`tool`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `M3156_3`.`tool` (
  `toolID` INT NOT NULL AUTO_INCREMENT,
  `toolName` VARCHAR(128) NOT NULL,
  `toolDescription` VARCHAR(1000) NOT NULL,
  `toolPrice` DECIMAL(10,2) NOT NULL,
  `toolCondition` VARCHAR(45) NOT NULL,
  `toolCategoryID` INT NOT NULL,
  `userOwnerID` INT NOT NULL,
  `toolPicture` VARCHAR(128) NULL,
  PRIMARY KEY (`toolID`),
  INDEX `fk_tool_toolCategory1_idx` (`toolCategoryID` ASC),
  INDEX `fk_tool_user1_idx` (`userOwnerID` ASC),
  CONSTRAINT `fk_tool_toolCategory1`
    FOREIGN KEY (`toolCategoryID`)
    REFERENCES `M3156_3`.`toolCategory` (`toolCategoryID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tool_user1`
    FOREIGN KEY (`userOwnerID`)
    REFERENCES `M3156_3`.`user` (`userID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `M3156_3`.`transaction`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `M3156_3`.`transaction` (
  `transactionID` INT NOT NULL AUTO_INCREMENT,
  `transactionStartDate` DATETIME NOT NULL,
  `transactionPlannedEndDate` DATETIME NOT NULL,
  `userOwnerID` INT NOT NULL,
  `userLesseeID` INT NOT NULL,
  `toolID` INT NOT NULL,
  `actualEndDate` DATETIME NULL,
  PRIMARY KEY (`transactionID`),
  INDEX `fk_transaction_user1_idx` (`userOwnerID` ASC),
  INDEX `fk_transaction_user2_idx` (`userLesseeID` ASC),
  INDEX `fk_transaction_tool1_idx` (`toolID` ASC),
  CONSTRAINT `fk_transaction_user1`
    FOREIGN KEY (`userOwnerID`)
    REFERENCES `M3156_3`.`user` (`userID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_transaction_user2`
    FOREIGN KEY (`userLesseeID`)
    REFERENCES `M3156_3`.`user` (`userID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_transaction_tool1`
    FOREIGN KEY (`toolID`)
    REFERENCES `M3156_3`.`tool` (`toolID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `M3156_3`.`comment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `M3156_3`.`comment` (
  `commentID` INT NOT NULL AUTO_INCREMENT,
  `commentDate` DATETIME NOT NULL,
  `commentText` VARCHAR(1000) NULL,
  `userID` INT NOT NULL,
  `commentParentID` INT NULL,
  `toolID` INT NOT NULL,
  PRIMARY KEY (`commentID`),
  INDEX `fk_return_tr_user1_idx` (`userID` ASC),
  INDEX `fk_return_tr_return_tr1_idx` (`commentParentID` ASC),
  INDEX `fk_comment_tool1_idx` (`toolID` ASC),
  CONSTRAINT `fk_return_tr_user1`
    FOREIGN KEY (`userID`)
    REFERENCES `M3156_3`.`user` (`userID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_return_tr_return_tr1`
    FOREIGN KEY (`commentParentID`)
    REFERENCES `M3156_3`.`comment` (`commentID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_comment_tool1`
    FOREIGN KEY (`toolID`)
    REFERENCES `M3156_3`.`tool` (`toolID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `M3156_3`.`rating`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `M3156_3`.`rating` (
  `ratingID` INT NOT NULL AUTO_INCREMENT,
  `rating` INT(1) NOT NULL,
  `ratingFeedback` VARCHAR(1000) NULL,
  `raterID` INT NOT NULL,
  `ratedID` INT NOT NULL,
  `transactionID` INT NOT NULL,
  PRIMARY KEY (`ratingID`),
  INDEX `fk_rating_user1_idx` (`raterID` ASC),
  INDEX `fk_rating_user2_idx` (`ratedID` ASC),
  INDEX `fk_rating_transaction1_idx` (`transactionID` ASC),
  CONSTRAINT `fk_rating_user1`
    FOREIGN KEY (`raterID`)
    REFERENCES `M3156_3`.`user` (`userID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_rating_user2`
    FOREIGN KEY (`ratedID`)
    REFERENCES `M3156_3`.`user` (`userID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_rating_transaction1`
    FOREIGN KEY (`transactionID`)
    REFERENCES `M3156_3`.`transaction` (`transactionID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
```