-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema demo
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema demo
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `demo` DEFAULT CHARACTER SET utf8 ;
USE `demo` ;

-- -----------------------------------------------------
-- Table `demo`.`Company`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `demo`.`Company` (
  `CompanyId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(200) NOT NULL,
  `CreatedBy` VARCHAR(50) NOT NULL,
  `ModifiedBy` VARCHAR(50) NULL,
  `CreatedOn` DATETIME NOT NULL,
  `ModifiedOn` DATETIME NULL,
  `Enabled` BIT NOT NULL DEFAULT true,
  PRIMARY KEY (`CompanyId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `demo`.`Interview`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `demo`.`Interview` (
  `InterviewId` INT NOT NULL AUTO_INCREMENT,
  `StartDateTime` DATETIME NOT NULL,
  `EndDateTime` DATETIME NULL,
  `RoomName` VARCHAR(200) NOT NULL,
  `CompanyId` INT NOT NULL,
  `Comments` MEDIUMTEXT NULL,
  `Selected` BIT NULL,
  `CreatedBy` VARCHAR(50) NOT NULL,
  `ModifiedBy` VARCHAR(50) NULL,
  `CreatedOn` DATETIME NOT NULL,
  `ModifiedOn` DATETIME NULL,
  `Enabled` BIT NOT NULL DEFAULT true,
  PRIMARY KEY (`InterviewId`),
  INDEX `Interview_CompanyId_idx` (`CompanyId` ASC),
  CONSTRAINT `Interview_CompanyId`
    FOREIGN KEY (`CompanyId`)
    REFERENCES `demo`.`Company` (`CompanyId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `demo`.`Interviewer`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `demo`.`Interviewer` (
  `InterviewerId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(150) NOT NULL,
  `Role` VARCHAR(150) NOT NULL,
  `CreatedBy` VARCHAR(50) NOT NULL,
  `ModifiedBy` VARCHAR(50) NULL,
  `CreatedOn` DATETIME NOT NULL,
  `ModifiedOn` DATETIME NULL,
  `Enabled` BIT NOT NULL DEFAULT true,
  `InterviewId` INT NOT NULL,
  PRIMARY KEY (`InterviewerId`),
  INDEX `Interview_interviewId_idx` (`InterviewId` ASC),
  CONSTRAINT `Interview_interviewId`
    FOREIGN KEY (`InterviewId`)
    REFERENCES `demo`.`Interview` (`InterviewId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `demo`.`Interviewee`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `demo`.`Interviewee` (
  `IntervieweeId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(150) NOT NULL,
  `ApplyingRole` VARCHAR(150) NOT NULL,
  `CreatedBy` VARCHAR(50) NOT NULL,
  `ModifiedBy` VARCHAR(50) NULL,
  `CreatedOn` DATETIME NOT NULL,
  `ModifiedOn` DATETIME NULL,
  `Enabled` BIT NOT NULL DEFAULT true,
  `InterviewId` INT NOT NULL,
  PRIMARY KEY (`IntervieweeId`),
  INDEX `Interviewee_InterviewId_idx` (`InterviewId` ASC),
  CONSTRAINT `Interviewee_InterviewId`
    FOREIGN KEY (`InterviewId`)
    REFERENCES `demo`.`Interview` (`InterviewId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
