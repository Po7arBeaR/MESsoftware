/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 80032
Source Host           : localhost:3306
Source Database       : snk

Target Server Type    : MYSQL
Target Server Version : 80032
File Encoding         : 65001

Date: 2023-08-01 16:47:15
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for historydata
-- ----------------------------
DROP TABLE IF EXISTS `historydata`;
CREATE TABLE `historydata` (
  `sfc` varchar(40) NOT NULL,
  `InterFanceName` varchar(40) NOT NULL,
  `GroupBasis` varchar(20) DEFAULT NULL,
  `GroupCode` varchar(30) DEFAULT NULL,
  `labelRemarks` varchar(20) DEFAULT NULL,
  `Count` int DEFAULT NULL,
  `CreateTime` datetime NOT NULL,
  `Message` varchar(100) NOT NULL,
  `Code` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of historydata
-- ----------------------------

-- ----------------------------
-- Table structure for plclogparammap
-- ----------------------------
DROP TABLE IF EXISTS `plclogparammap`;
CREATE TABLE `plclogparammap` (
  `id` int NOT NULL AUTO_INCREMENT,
  `DB` varchar(20) DEFAULT NULL,
  `Address` int DEFAULT NULL,
  `Type` varchar(10) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `CurrentValue` varchar(40) DEFAULT NULL,
  `LastValue` varchar(40) DEFAULT NULL,
  `ChangeTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of plclogparammap
-- ----------------------------
INSERT INTO `plclogparammap` VALUES ('1', 'DB801', '100', 'Int', '轴A1111', '0', '5432', '2023-07-24 15:02:07');
INSERT INTO `plclogparammap` VALUES ('2', 'DB801', '300', 'Real', '离焦量111', '0', '444.555', '2023-07-24 15:02:07');

-- ----------------------------
-- Table structure for rolemanage
-- ----------------------------
DROP TABLE IF EXISTS `rolemanage`;
CREATE TABLE `rolemanage` (
  `RoleName` varchar(10) DEFAULT NULL,
  `MainFormPermissions` int DEFAULT NULL,
  `UserManageFormPermissions` int DEFAULT NULL,
  `GeneralSettingFormPermissions` int DEFAULT NULL,
  `InterFaceSettingFormPermissions` int DEFAULT NULL,
  `PLCVariableFormPermissions` int DEFAULT NULL,
  `ParameterMonitor` int DEFAULT NULL,
  `CheckPermissions` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of rolemanage
-- ----------------------------
INSERT INTO `rolemanage` VALUES ('OPN操作员', '1', '0', '0', '0', '0', '0', '1');
INSERT INTO `rolemanage` VALUES ('OPN技师', '1', '1', '0', '0', '0', '1', '1');
INSERT INTO `rolemanage` VALUES ('ME', '1', '1', '1', '0', '1', '1', '1');
INSERT INTO `rolemanage` VALUES ('PE', '1', '1', '1', '1', '0', '1', '1');
INSERT INTO `rolemanage` VALUES ('管理员', '1', '1', '1', '1', '1', '1', '1');

-- ----------------------------
-- Table structure for usermanagerment
-- ----------------------------
DROP TABLE IF EXISTS `usermanagerment`;
CREATE TABLE `usermanagerment` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `LoginName` varchar(50) NOT NULL,
  `PassWord` varchar(32) DEFAULT NULL,
  `CardId` varchar(64) DEFAULT NULL,
  `Character` varchar(20) NOT NULL,
  `FullName` varchar(30) DEFAULT NULL,
  `CreatTime` timestamp NULL DEFAULT NULL,
  `Creator` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of usermanagerment
-- ----------------------------
INSERT INTO `usermanagerment` VALUES ('1', 'zhangliang', '1', '3216486112', '管理员', '张良', '2023-06-13 09:36:53', '水兵');

-- ----------------------------
-- Procedure structure for AutoDeleteHistory
-- ----------------------------
DROP PROCEDURE IF EXISTS `AutoDeleteHistory`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AutoDeleteHistory`()
BEGIN
	#Routine body goes here...=
	DELETE FROM historydata WHERE CreateTime<DATE_SUB(CURDATE(),INTERVAL 90 DAY);
END
;;
DELIMITER ;

-- ----------------------------
-- Event structure for AutoDeleteEvent
-- ----------------------------
DROP EVENT IF EXISTS `AutoDeleteEvent`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` EVENT `AutoDeleteEvent` ON SCHEDULE EVERY 1 MONTH STARTS '2023-08-01 00:00:00' ON COMPLETION NOT PRESERVE ENABLE DO CALL AutoDeleteHistory
;;
DELIMITER ;
