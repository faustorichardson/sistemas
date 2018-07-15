/*
Navicat MySQL Data Transfer

Source Server         : LOCALSERVER
Source Server Version : 50715
Source Host           : localhost:3306
Source Database       : ard_combarcos

Target Server Type    : MYSQL
Target Server Version : 50715
File Encoding         : 65001

Date: 2016-09-29 21:44:00
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `actividad`
-- ----------------------------
DROP TABLE IF EXISTS `actividad`;
CREATE TABLE `actividad` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `actividad` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of actividad
-- ----------------------------
INSERT INTO `actividad` VALUES ('1', 'NAVEGACION');
INSERT INTO `actividad` VALUES ('2', 'FONDEADO');

-- ----------------------------
-- Table structure for `condiciones`
-- ----------------------------
DROP TABLE IF EXISTS `condiciones`;
CREATE TABLE `condiciones` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `condicion` varchar(25) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of condiciones
-- ----------------------------
INSERT INTO `condiciones` VALUES ('1', 'CONDICION \"A\"');
INSERT INTO `condiciones` VALUES ('2', 'CONDICION \"B\"');
INSERT INTO `condiciones` VALUES ('3', 'CONDICION \"C\"');
INSERT INTO `condiciones` VALUES ('4', 'CONDICION \"D\"');
INSERT INTO `condiciones` VALUES ('5', 'CONDICION \"E\"');

-- ----------------------------
-- Table structure for `existencia`
-- ----------------------------
DROP TABLE IF EXISTS `existencia`;
CREATE TABLE `existencia` (
  `id_unidad` int(11) NOT NULL,
  `cantidad` decimal(9,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of existencia
-- ----------------------------
INSERT INTO `existencia` VALUES ('1', '10500');
INSERT INTO `existencia` VALUES ('2', '4044');
INSERT INTO `existencia` VALUES ('3', '2778');
INSERT INTO `existencia` VALUES ('4', '0');
INSERT INTO `existencia` VALUES ('5', '1150');
INSERT INTO `existencia` VALUES ('6', '0');
INSERT INTO `existencia` VALUES ('7', '0');
INSERT INTO `existencia` VALUES ('8', '750');
INSERT INTO `existencia` VALUES ('9', '1342');
INSERT INTO `existencia` VALUES ('10', '0');
INSERT INTO `existencia` VALUES ('11', '0');
INSERT INTO `existencia` VALUES ('12', '0');
INSERT INTO `existencia` VALUES ('13', '0');
INSERT INTO `existencia` VALUES ('14', '0');
INSERT INTO `existencia` VALUES ('15', '0');
INSERT INTO `existencia` VALUES ('16', '0');
INSERT INTO `existencia` VALUES ('17', '0');
INSERT INTO `existencia` VALUES ('18', '0');
INSERT INTO `existencia` VALUES ('19', '100');
INSERT INTO `existencia` VALUES ('20', '0');
INSERT INTO `existencia` VALUES ('21', '0');
INSERT INTO `existencia` VALUES ('22', '0');
INSERT INTO `existencia` VALUES ('23', '0');
INSERT INTO `existencia` VALUES ('24', '0');
INSERT INTO `existencia` VALUES ('25', '0');
INSERT INTO `existencia` VALUES ('26', '0');
INSERT INTO `existencia` VALUES ('27', '0');
INSERT INTO `existencia` VALUES ('28', '0');

-- ----------------------------
-- Table structure for `movimientocombustible`
-- ----------------------------
DROP TABLE IF EXISTS `movimientocombustible`;
CREATE TABLE `movimientocombustible` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL,
  `unidadnaval` int(11) NOT NULL,
  `cantidad` decimal(9,0) NOT NULL,
  `mov` varchar(1) NOT NULL,
  `actividad` int(11) NOT NULL DEFAULT '0',
  `millas` decimal(9,0) DEFAULT '0',
  `actividad_detalle` mediumtext,
  `status` bit(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of movimientocombustible
-- ----------------------------
INSERT INTO `movimientocombustible` VALUES ('1', '2016-09-22', '1', '11805', 'E', '0', '0', null, '');
INSERT INTO `movimientocombustible` VALUES ('2', '2016-09-22', '1', '2500', 'E', '0', '0', null, '');
INSERT INTO `movimientocombustible` VALUES ('3', '2016-09-22', '1', '6500', 'E', '0', '0', null, '');
INSERT INTO `movimientocombustible` VALUES ('4', '2016-09-23', '2', '4044', 'E', '0', '0', null, '');
INSERT INTO `movimientocombustible` VALUES ('5', '2016-09-23', '3', '2778', 'E', '0', '0', null, '');
INSERT INTO `movimientocombustible` VALUES ('6', '2016-09-23', '5', '156', 'S', '2', '0', 'DE TAL SITIO AL OTRO SITIO.-', '');
INSERT INTO `movimientocombustible` VALUES ('7', '2016-09-23', '3', '1500', 'S', '1', '125', 'adasdasdosjdoasdsaodadsihuasdiahisdas', '');
INSERT INTO `movimientocombustible` VALUES ('8', '2016-09-23', '5', '1500', 'E', '0', '0', null, '');
INSERT INTO `movimientocombustible` VALUES ('9', '2016-09-23', '5', '350', 'S', '1', '265', 'DESDE LA ROMANA A SAN PEDRO.', '');
INSERT INTO `movimientocombustible` VALUES ('10', '2016-09-25', '19', '100', 'E', '0', '0', null, '');
INSERT INTO `movimientocombustible` VALUES ('11', '2016-09-26', '1', '350', 'S', '1', '100', 'De tal punto al otro punto.-', '');
INSERT INTO `movimientocombustible` VALUES ('12', '2016-09-26', '1', '8350', 'E', '0', '0', null, '');
INSERT INTO `movimientocombustible` VALUES ('13', '2016-09-29', '9', '1500', 'E', '0', '0', null, '');
INSERT INTO `movimientocombustible` VALUES ('14', '2016-09-29', '8', '750', 'E', '0', '0', null, '');
INSERT INTO `movimientocombustible` VALUES ('15', '2016-09-29', '9', '8', 'S', '2', '0', '', '');
INSERT INTO `movimientocombustible` VALUES ('16', '2016-09-29', '9', '150', 'S', '1', '25', 'SUPERVISION DE LA COSTA.-', '');
INSERT INTO `movimientocombustible` VALUES ('17', '2016-09-29', '1', '6500', 'S', '1', '328', 'Crucero de guardiamarinas.', '');

-- ----------------------------
-- Table structure for `tiposcombustibles`
-- ----------------------------
DROP TABLE IF EXISTS `tiposcombustibles`;
CREATE TABLE `tiposcombustibles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `combustible` varchar(100) NOT NULL,
  `medida` varchar(25) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tiposcombustibles
-- ----------------------------
INSERT INTO `tiposcombustibles` VALUES ('1', 'GASOIL', 'GLS.');
INSERT INTO `tiposcombustibles` VALUES ('2', 'GASOLINA', 'GLS.');

-- ----------------------------
-- Table structure for `tipounidades`
-- ----------------------------
DROP TABLE IF EXISTS `tipounidades`;
CREATE TABLE `tipounidades` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipo` varchar(25) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tipounidades
-- ----------------------------
INSERT INTO `tipounidades` VALUES ('1', 'UNIDADES MAYORES');
INSERT INTO `tipounidades` VALUES ('2', 'UNIDADES MENORES');

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
  `condicion` varchar(15) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of unidades
-- ----------------------------
INSERT INTO `unidades` VALUES ('1', 'PA-301 \"DIDIEZ BURGOS\"', '1', '1', '28594', '1');
INSERT INTO `unidades` VALUES ('2', 'PM-204 \"CAPOTILLO\"', '1', '1', '11500', '1');
INSERT INTO `unidades` VALUES ('3', 'PM-203 \"TORTUGUERO\"', '1', '1', '11500', '1');
INSERT INTO `unidades` VALUES ('4', 'LD-31 \"NEYBA\"', '1', '1', '3290', '1');
INSERT INTO `unidades` VALUES ('5', 'GC-103 \"PROCION\"', '2', '1', '2883', '1');
INSERT INTO `unidades` VALUES ('6', 'GC-104 \"ALDEBARAN\"', '2', '1', '2883', '1');
INSERT INTO `unidades` VALUES ('7', 'GC-106 \"BELLATRIX\"', '2', '1', '2883', '1');
INSERT INTO `unidades` VALUES ('8', 'GC-107 \"CANOPUS\"', '2', '1', '4650', '1');
INSERT INTO `unidades` VALUES ('9', 'GC-108 \"CAPELLA\"', '2', '1', '2883', '1');
INSERT INTO `unidades` VALUES ('10', 'GC-109 \"ORION\"', '2', '1', '4650', '1');
INSERT INTO `unidades` VALUES ('11', 'GC-112 \"ALTAIR\"', '2', '1', '10260', '1');
INSERT INTO `unidades` VALUES ('12', 'LR-154 \"ACAMAR\"', '2', '1', '850', '1');
INSERT INTO `unidades` VALUES ('13', 'LR-153 \"DENEB\"', '2', '1', '850', '1');
INSERT INTO `unidades` VALUES ('14', 'LR-151 \"HAMAL\"', '2', '1', '850', '1');
INSERT INTO `unidades` VALUES ('15', 'LI-155 \"CASTOR\"', '2', '2', '450', '1');
INSERT INTO `unidades` VALUES ('16', 'LI-156 \"POLLUX\"', '2', '2', '425', '1');
INSERT INTO `unidades` VALUES ('17', 'LI-159 \"ENIF\"', '2', '2', '450', '1');
INSERT INTO `unidades` VALUES ('18', 'LI-161 \"ELNATH\"', '2', '2', '300', '1');
INSERT INTO `unidades` VALUES ('19', 'LI-162 \"POLARIS\"', '2', '2', '300', '1');
INSERT INTO `unidades` VALUES ('20', 'LI-165 \"REGULUS\"', '2', '2', '300', '1');
INSERT INTO `unidades` VALUES ('21', 'LI-166 \"DENEBOLA\"', '2', '2', '300', '1');
INSERT INTO `unidades` VALUES ('22', 'LI-169 \"ALGENIB\"', '2', '2', '450', '1');
INSERT INTO `unidades` VALUES ('23', 'LI-170 \"ARNEB\"', '2', '2', '150', '1');
INSERT INTO `unidades` VALUES ('24', 'GC-110 \"SIRIUS\"', '2', '1', '2158', '2');
INSERT INTO `unidades` VALUES ('25', 'LI-167 \"ACRUX\"', '2', '2', '300', '3');
INSERT INTO `unidades` VALUES ('26', 'LI-164 \"DUBHE\"', '2', '2', '300', '3');
INSERT INTO `unidades` VALUES ('27', 'LI-163 \"NUNKI\"', '2', '2', '300', '3');
INSERT INTO `unidades` VALUES ('28', 'GC-105 \"ANTARES\"', '2', '1', '2158', '4');

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
