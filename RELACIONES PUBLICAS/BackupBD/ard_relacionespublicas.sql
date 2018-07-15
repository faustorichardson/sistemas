/*
Navicat MySQL Data Transfer

Source Server         : LOCALSERVER
Source Server Version : 50715
Source Host           : localhost:3306
Source Database       : ard_relacionespublicas

Target Server Type    : MYSQL
Target Server Version : 50715
File Encoding         : 65001

Date: 2016-11-15 19:31:58
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `actividades`
-- ----------------------------
DROP TABLE IF EXISTS `actividades`;
CREATE TABLE `actividades` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipoactividad` int(11) NOT NULL,
  `actividad` varchar(150) NOT NULL,
  `fecha` date NOT NULL,
  `nota` mediumtext,
  `status` varchar(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of actividades
-- ----------------------------
INSERT INTO `actividades` VALUES ('1', '2', 'MINISTRO DE RELACIONES EXTERIORES', '2016-11-15', 'Visito las instalaciones de esta Base Naval \"27 de Febrero\" el Ministro de Relaciones Exteriores, en visita al Comandante General de la ARD.', '0');
INSERT INTO `actividades` VALUES ('2', '3', 'DONACIONES DE UTILES ADEOMA', '2016-11-14', 'Donacion de utiles escolares a oficiales y alistados de la ARD.', '1');
INSERT INTO `actividades` VALUES ('3', '2', 'VISITA DEL CONSUL DE HONDURAS', '2016-11-15', 'Prueba.', '0');
INSERT INTO `actividades` VALUES ('4', '1', 'VISITA DEL MINISTRO DE DEFENSA', '2016-11-17', 'Otra prueba.-', '0');

-- ----------------------------
-- Table structure for `tipoactividad`
-- ----------------------------
DROP TABLE IF EXISTS `tipoactividad`;
CREATE TABLE `tipoactividad` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipo` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tipoactividad
-- ----------------------------
INSERT INTO `tipoactividad` VALUES ('1', 'VISITA MILITAR');
INSERT INTO `tipoactividad` VALUES ('2', 'VISITA DIPLOMATICA');
INSERT INTO `tipoactividad` VALUES ('3', 'DONACIONES');
INSERT INTO `tipoactividad` VALUES ('4', 'ACTIVIDADES DEPORTIVAS');

-- ----------------------------
-- Table structure for `usuarios`
-- ----------------------------
DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE `usuarios` (
  `idusuarios` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(25) NOT NULL,
  `clave` varchar(25) NOT NULL,
  `status` bit(1) NOT NULL DEFAULT b'0',
  `nivelpermiso` int(1) DEFAULT '0',
  PRIMARY KEY (`idusuarios`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of usuarios
-- ----------------------------
INSERT INTO `usuarios` VALUES ('1', 'frichardson', 'frrh0414', '', '1');
INSERT INTO `usuarios` VALUES ('2', 'neder', 'neder1234', '', '3');
