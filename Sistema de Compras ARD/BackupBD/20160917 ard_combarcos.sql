/*
Navicat MySQL Data Transfer

Source Server         : LOCALSERVER
Source Server Version : 50715
Source Host           : localhost:3306
Source Database       : ard_combarcos

Target Server Type    : MYSQL
Target Server Version : 50715
File Encoding         : 65001

Date: 2016-09-17 17:50:13
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `combustible_entrada`
-- ----------------------------
DROP TABLE IF EXISTS `combustible_entrada`;
CREATE TABLE `combustible_entrada` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL,
  `unidadnaval` int(11) NOT NULL,
  `tipo_comb` int(11) NOT NULL,
  `cantidad` decimal(9,0) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of combustible_entrada
-- ----------------------------

-- ----------------------------
-- Table structure for `combustible_salida`
-- ----------------------------
DROP TABLE IF EXISTS `combustible_salida`;
CREATE TABLE `combustible_salida` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL,
  `unidadnaval` int(11) NOT NULL,
  `tipo_comb` int(11) NOT NULL,
  `cantidad` decimal(9,0) NOT NULL,
  `actividad` int(11) NOT NULL,
  `actividad_desc` varchar(100) DEFAULT '''''',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of combustible_salida
-- ----------------------------

-- ----------------------------
-- Table structure for `existencia`
-- ----------------------------
DROP TABLE IF EXISTS `existencia`;
CREATE TABLE `existencia` (
  `id_unidad` int(11) NOT NULL,
  `tipo_comb` int(11) NOT NULL,
  `cantidad` decimal(9,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of existencia
-- ----------------------------

-- ----------------------------
-- Table structure for `tiposcombustibles`
-- ----------------------------
DROP TABLE IF EXISTS `tiposcombustibles`;
CREATE TABLE `tiposcombustibles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `combustible` varchar(100) NOT NULL,
  `medida` varchar(25) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tiposcombustibles
-- ----------------------------

-- ----------------------------
-- Table structure for `unidades`
-- ----------------------------
DROP TABLE IF EXISTS `unidades`;
CREATE TABLE `unidades` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `unidad` varchar(100) NOT NULL,
  `tipo` int(11) NOT NULL,
  `tipo_comb` int(11) NOT NULL,
  `cap_comb` decimal(9,0) NOT NULL,
  `condicion` varchar(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of unidades
-- ----------------------------

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
INSERT INTO `usuarios` VALUES ('2', 'operaciones', 'operaciones1234', '', '3');
