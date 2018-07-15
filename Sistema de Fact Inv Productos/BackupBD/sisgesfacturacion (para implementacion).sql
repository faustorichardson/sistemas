/*
Navicat MySQL Data Transfer

Source Server         : LOCALSERVER
Source Server Version : 50715
Source Host           : localhost:3306
Source Database       : sisgesfacturacion

Target Server Type    : MYSQL
Target Server Version : 50715
File Encoding         : 65001

Date: 2017-03-10 11:50:36
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `categorias`
-- ----------------------------
DROP TABLE IF EXISTS `categorias`;
CREATE TABLE `categorias` (
  `idcategoria` int(11) NOT NULL AUTO_INCREMENT,
  `categoria` varchar(50) NOT NULL DEFAULT '""',
  PRIMARY KEY (`idcategoria`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of categorias
-- ----------------------------
INSERT INTO `categorias` VALUES ('1', 'FILTROS');
INSERT INTO `categorias` VALUES ('2', 'LUBRICANTES');
INSERT INTO `categorias` VALUES ('3', 'TORNILLOS');

-- ----------------------------
-- Table structure for `clientes`
-- ----------------------------
DROP TABLE IF EXISTS `clientes`;
CREATE TABLE `clientes` (
  `idcliente` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(150) NOT NULL,
  `rnc` varchar(25) DEFAULT NULL,
  `direccion` varchar(100) NOT NULL,
  `provincia` int(11) NOT NULL,
  `tipo` varchar(1) NOT NULL DEFAULT 'B',
  `telefono` varchar(25) DEFAULT '(000) 000-0000',
  `status` varchar(1) NOT NULL DEFAULT 'A',
  PRIMARY KEY (`idcliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of clientes
-- ----------------------------

-- ----------------------------
-- Table structure for `distritos_municipales`
-- ----------------------------
DROP TABLE IF EXISTS `distritos_municipales`;
CREATE TABLE `distritos_municipales` (
  `distrito_id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  `municipio_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`distrito_id`),
  KEY `municipio_id_idx` (`municipio_id`),
  CONSTRAINT `municipio_id` FOREIGN KEY (`municipio_id`) REFERENCES `municipios` (`municipio_id`)
) ENGINE=InnoDB AUTO_INCREMENT=229 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of distritos_municipales
-- ----------------------------
INSERT INTO `distritos_municipales` VALUES ('1', 'Barreras', '2');
INSERT INTO `distritos_municipales` VALUES ('2', 'Barro Arriba', '2');
INSERT INTO `distritos_municipales` VALUES ('3', 'Clavellina', '2');
INSERT INTO `distritos_municipales` VALUES ('4', 'Emma Balaguer Viuda Vallejo', '2');
INSERT INTO `distritos_municipales` VALUES ('5', 'Las Barías-La Estancia', '2');
INSERT INTO `distritos_municipales` VALUES ('6', 'Las Lomas', '2');
INSERT INTO `distritos_municipales` VALUES ('7', 'Los Jovillos', '2');
INSERT INTO `distritos_municipales` VALUES ('8', 'Puerto Viejo', '2');
INSERT INTO `distritos_municipales` VALUES ('9', 'Hatillo', '5');
INSERT INTO `distritos_municipales` VALUES ('10', 'Palmar de Ocoa', '5');
INSERT INTO `distritos_municipales` VALUES ('11', 'Villarpando', '6');
INSERT INTO `distritos_municipales` VALUES ('12', 'Hato Nuevo-Cortés', '6');
INSERT INTO `distritos_municipales` VALUES ('13', 'La Siembra', '7');
INSERT INTO `distritos_municipales` VALUES ('14', 'Las Lagunas', '7');
INSERT INTO `distritos_municipales` VALUES ('15', 'Los Fríos', '7');
INSERT INTO `distritos_municipales` VALUES ('16', 'El Rosario', '9');
INSERT INTO `distritos_municipales` VALUES ('17', 'Proyecto 4', '10');
INSERT INTO `distritos_municipales` VALUES ('18', 'Ganadero', '10');
INSERT INTO `distritos_municipales` VALUES ('19', 'Proyecto 2-C', '10');
INSERT INTO `distritos_municipales` VALUES ('20', 'Amiama Gómez', '11');
INSERT INTO `distritos_municipales` VALUES ('21', 'Los Toros', '11');
INSERT INTO `distritos_municipales` VALUES ('22', 'Tábara Abajo', '11');
INSERT INTO `distritos_municipales` VALUES ('23', 'El Palmar', '12');
INSERT INTO `distritos_municipales` VALUES ('24', 'El Salado', '13');
INSERT INTO `distritos_municipales` VALUES ('25', 'Las Clavellinas', '14');
INSERT INTO `distritos_municipales` VALUES ('26', 'Cabeza de Toro', '15');
INSERT INTO `distritos_municipales` VALUES ('27', 'Mena', '15');
INSERT INTO `distritos_municipales` VALUES ('28', 'Monserrat', '15');
INSERT INTO `distritos_municipales` VALUES ('29', 'Santa Bárbara-El 6', '15');
INSERT INTO `distritos_municipales` VALUES ('30', 'Santana', '15');
INSERT INTO `distritos_municipales` VALUES ('31', 'Uvilla', '15');
INSERT INTO `distritos_municipales` VALUES ('32', 'El Cachón', '17');
INSERT INTO `distritos_municipales` VALUES ('33', 'La Guázara', '17');
INSERT INTO `distritos_municipales` VALUES ('34', 'Villa Central', '17');
INSERT INTO `distritos_municipales` VALUES ('35', 'Arroyo Dulce', '20');
INSERT INTO `distritos_municipales` VALUES ('36', 'Pescadería', '21');
INSERT INTO `distritos_municipales` VALUES ('37', 'Palo Alto', '22');
INSERT INTO `distritos_municipales` VALUES ('38', 'Bahoruco', '23');
INSERT INTO `distritos_municipales` VALUES ('39', 'Los Patos', '25');
INSERT INTO `distritos_municipales` VALUES ('40', 'Canoa', '27');
INSERT INTO `distritos_municipales` VALUES ('41', 'Fondo Negro', '27');
INSERT INTO `distritos_municipales` VALUES ('42', 'Quita Coraza', '27');
INSERT INTO `distritos_municipales` VALUES ('43', 'Cañongo', '28');
INSERT INTO `distritos_municipales` VALUES ('44', 'Manuel Bueno', '4');
INSERT INTO `distritos_municipales` VALUES ('45', 'Capotillo', '30');
INSERT INTO `distritos_municipales` VALUES ('46', 'Santiago de la Cruz', '30');
INSERT INTO `distritos_municipales` VALUES ('47', 'Cenoví', '33');
INSERT INTO `distritos_municipales` VALUES ('48', 'Jaya', '33');
INSERT INTO `distritos_municipales` VALUES ('49', 'La Peña', '33');
INSERT INTO `distritos_municipales` VALUES ('50', 'Presidente Don Antonio Guzmán Fernández', '33');
INSERT INTO `distritos_municipales` VALUES ('51', 'Aguacate', '34');
INSERT INTO `distritos_municipales` VALUES ('52', 'Las Coles', '34');
INSERT INTO `distritos_municipales` VALUES ('53', 'Sabana Grande', '36');
INSERT INTO `distritos_municipales` VALUES ('54', 'Agua Santa del Yuna', '39');
INSERT INTO `distritos_municipales` VALUES ('55', 'Barraquito', '39');
INSERT INTO `distritos_municipales` VALUES ('56', 'Cristo Rey de Guaraguao', '39');
INSERT INTO `distritos_municipales` VALUES ('57', 'Las Táranas', '39');
INSERT INTO `distritos_municipales` VALUES ('58', 'Pedro Sánchez', '40');
INSERT INTO `distritos_municipales` VALUES ('59', 'San Francisco-Vicentillo', '40');
INSERT INTO `distritos_municipales` VALUES ('60', 'Santa Lucía', '41');
INSERT INTO `distritos_municipales` VALUES ('61', 'El Cedro', '41');
INSERT INTO `distritos_municipales` VALUES ('62', 'La Gina', '41');
INSERT INTO `distritos_municipales` VALUES ('63', 'Guayabo', '42');
INSERT INTO `distritos_municipales` VALUES ('64', 'Sabana Larga', '42');
INSERT INTO `distritos_municipales` VALUES ('65', 'Sabana Cruz', '43');
INSERT INTO `distritos_municipales` VALUES ('66', 'Sabana Higüero', '43');
INSERT INTO `distritos_municipales` VALUES ('67', 'Guanito', '44');
INSERT INTO `distritos_municipales` VALUES ('68', 'Rancho de la Guardia', '45');
INSERT INTO `distritos_municipales` VALUES ('69', 'Río Limpio', '47');
INSERT INTO `distritos_municipales` VALUES ('70', 'Canca La Reina', '48');
INSERT INTO `distritos_municipales` VALUES ('71', 'El Higüerito', '48');
INSERT INTO `distritos_municipales` VALUES ('72', 'José Contreras', '48');
INSERT INTO `distritos_municipales` VALUES ('73', 'Juan López', '48');
INSERT INTO `distritos_municipales` VALUES ('74', 'La Ortega', '48');
INSERT INTO `distritos_municipales` VALUES ('75', 'Las Lagunas', '48');
INSERT INTO `distritos_municipales` VALUES ('76', 'Monte de la Jagua', '48');
INSERT INTO `distritos_municipales` VALUES ('77', 'San Víctor', '48');
INSERT INTO `distritos_municipales` VALUES ('78', 'Joba Arriba', '50');
INSERT INTO `distritos_municipales` VALUES ('79', 'Veragua', '50');
INSERT INTO `distritos_municipales` VALUES ('80', 'Villa Magante', '50');
INSERT INTO `distritos_municipales` VALUES ('81', 'Guayabo Dulce', '52');
INSERT INTO `distritos_municipales` VALUES ('82', 'Mata Palacio', '52');
INSERT INTO `distritos_municipales` VALUES ('83', 'Yerba Buena', '52');
INSERT INTO `distritos_municipales` VALUES ('84', 'Elupina Cordero de Las Cañitas', '54');
INSERT INTO `distritos_municipales` VALUES ('85', 'Jamao Afuera', '55');
INSERT INTO `distritos_municipales` VALUES ('86', 'Blanco', '56');
INSERT INTO `distritos_municipales` VALUES ('87', 'Boca de Cachón', '58');
INSERT INTO `distritos_municipales` VALUES ('88', 'El Limón', '58');
INSERT INTO `distritos_municipales` VALUES ('89', 'Batey 8', '59');
INSERT INTO `distritos_municipales` VALUES ('90', 'Vengan a Ver', '60');
INSERT INTO `distritos_municipales` VALUES ('91', 'La Colonia', '62');
INSERT INTO `distritos_municipales` VALUES ('92', 'Guayabal', '63');
INSERT INTO `distritos_municipales` VALUES ('93', 'La Otra Banda', '64');
INSERT INTO `distritos_municipales` VALUES ('94', 'Lagunas de Nisibón', '64');
INSERT INTO `distritos_municipales` VALUES ('95', 'Verón-Punta Cana', '64');
INSERT INTO `distritos_municipales` VALUES ('96', 'Bayahibe', '65');
INSERT INTO `distritos_municipales` VALUES ('97', 'Boca de Yuma', '65');
INSERT INTO `distritos_municipales` VALUES ('98', 'Caleta', '66');
INSERT INTO `distritos_municipales` VALUES ('99', 'Cumayasa', '68');
INSERT INTO `distritos_municipales` VALUES ('100', 'El Ranchito', '69');
INSERT INTO `distritos_municipales` VALUES ('101', 'Río Verde Arriba', '69');
INSERT INTO `distritos_municipales` VALUES ('102', 'La Sabina', '70');
INSERT INTO `distritos_municipales` VALUES ('103', 'Tireo', '70');
INSERT INTO `distritos_municipales` VALUES ('104', 'Buena Vista', '70');
INSERT INTO `distritos_municipales` VALUES ('105', 'Manabao', '71');
INSERT INTO `distritos_municipales` VALUES ('106', 'Rincón', '72');
INSERT INTO `distritos_municipales` VALUES ('107', 'Arroyo al Medio', '73');
INSERT INTO `distritos_municipales` VALUES ('108', 'Las Gordas', '73');
INSERT INTO `distritos_municipales` VALUES ('109', 'San José de Matanzas', '73');
INSERT INTO `distritos_municipales` VALUES ('110', 'Arroyo Salado', '74');
INSERT INTO `distritos_municipales` VALUES ('111', 'La Entrada', '74');
INSERT INTO `distritos_municipales` VALUES ('112', 'El Pozo', '75');
INSERT INTO `distritos_municipales` VALUES ('113', 'Arroyo Toro-Masipedro', '77');
INSERT INTO `distritos_municipales` VALUES ('114', 'La Salvia-Los Quemados', '77');
INSERT INTO `distritos_municipales` VALUES ('115', 'Jayaco', '77');
INSERT INTO `distritos_municipales` VALUES ('116', 'Juma Bejucal', '77');
INSERT INTO `distritos_municipales` VALUES ('117', 'Sabana del Puerto', '77');
INSERT INTO `distritos_municipales` VALUES ('118', 'Juan Adrián', '79');
INSERT INTO `distritos_municipales` VALUES ('119', 'Villa Sonador', '79');
INSERT INTO `distritos_municipales` VALUES ('120', 'Palo Verde', '81');
INSERT INTO `distritos_municipales` VALUES ('121', 'Cana Chapetón', '82');
INSERT INTO `distritos_municipales` VALUES ('122', 'Hatillo Palma', '82');
INSERT INTO `distritos_municipales` VALUES ('123', 'Villa Elisa', '82');
INSERT INTO `distritos_municipales` VALUES ('124', 'Boyá', '86');
INSERT INTO `distritos_municipales` VALUES ('125', 'Chirino', '86');
INSERT INTO `distritos_municipales` VALUES ('126', 'Don Juan', '86');
INSERT INTO `distritos_municipales` VALUES ('127', 'Gonzalo', '89');
INSERT INTO `distritos_municipales` VALUES ('128', 'Majagual', '89');
INSERT INTO `distritos_municipales` VALUES ('129', 'Los Botados', '90');
INSERT INTO `distritos_municipales` VALUES ('130', 'José Francisco Peña Gómez', '91');
INSERT INTO `distritos_municipales` VALUES ('131', 'Juancho', '91');
INSERT INTO `distritos_municipales` VALUES ('132', 'Catalina', '93');
INSERT INTO `distritos_municipales` VALUES ('133', 'El Carretón', '93');
INSERT INTO `distritos_municipales` VALUES ('134', 'El Limonal', '93');
INSERT INTO `distritos_municipales` VALUES ('135', 'Las Barías', '93');
INSERT INTO `distritos_municipales` VALUES ('136', 'Matanzas', '93');
INSERT INTO `distritos_municipales` VALUES ('137', 'Paya', '93');
INSERT INTO `distritos_municipales` VALUES ('138', 'Sabana Buey', '93');
INSERT INTO `distritos_municipales` VALUES ('139', 'Villa Fundación', '93');
INSERT INTO `distritos_municipales` VALUES ('140', 'Villa Sombrero', '93');
INSERT INTO `distritos_municipales` VALUES ('141', 'Pizarrete', '94');
INSERT INTO `distritos_municipales` VALUES ('142', 'Santana', '94');
INSERT INTO `distritos_municipales` VALUES ('143', 'Maimón', '86');
INSERT INTO `distritos_municipales` VALUES ('144', 'Yásica Arriba', '86');
INSERT INTO `distritos_municipales` VALUES ('145', 'Río Grande', '96');
INSERT INTO `distritos_municipales` VALUES ('146', 'Navas', '99');
INSERT INTO `distritos_municipales` VALUES ('147', 'Belloso', '100');
INSERT INTO `distritos_municipales` VALUES ('148', 'Estrecho', '100');
INSERT INTO `distritos_municipales` VALUES ('149', 'La Isabela', '100');
INSERT INTO `distritos_municipales` VALUES ('150', 'Cabarete', '101');
INSERT INTO `distritos_municipales` VALUES ('151', 'Sabaneta de Yásica', '101');
INSERT INTO `distritos_municipales` VALUES ('152', 'Estero Hondo', '102');
INSERT INTO `distritos_municipales` VALUES ('153', 'Gualete', '102');
INSERT INTO `distritos_municipales` VALUES ('154', 'La Jaiba', '102');
INSERT INTO `distritos_municipales` VALUES ('155', 'Arroyo Barril', '104');
INSERT INTO `distritos_municipales` VALUES ('156', 'El Limón', '104');
INSERT INTO `distritos_municipales` VALUES ('157', 'Las Galeras', '104');
INSERT INTO `distritos_municipales` VALUES ('158', 'Hato Damas', '107');
INSERT INTO `distritos_municipales` VALUES ('159', 'El Carril', '108');
INSERT INTO `distritos_municipales` VALUES ('160', 'Cambita El Pueblecito', '109');
INSERT INTO `distritos_municipales` VALUES ('161', 'La Cuchilla', '113');
INSERT INTO `distritos_municipales` VALUES ('162', 'Medina', '113');
INSERT INTO `distritos_municipales` VALUES ('163', 'San José del Puerto', '113');
INSERT INTO `distritos_municipales` VALUES ('164', 'El Naranjal', '115');
INSERT INTO `distritos_municipales` VALUES ('165', 'El Pinar', '115');
INSERT INTO `distritos_municipales` VALUES ('166', 'La Ciénaga', '115');
INSERT INTO `distritos_municipales` VALUES ('167', 'Nizao-Las Auyamas', '115');
INSERT INTO `distritos_municipales` VALUES ('168', 'El Rosario', '118');
INSERT INTO `distritos_municipales` VALUES ('169', 'Guanito', '118');
INSERT INTO `distritos_municipales` VALUES ('170', 'Hato del Padre', '118');
INSERT INTO `distritos_municipales` VALUES ('171', 'Hato Nuevo', '118');
INSERT INTO `distritos_municipales` VALUES ('172', 'La Jagua', '118');
INSERT INTO `distritos_municipales` VALUES ('173', 'Las Charcas de María Nova', '118');
INSERT INTO `distritos_municipales` VALUES ('174', 'Pedro Corto', '118');
INSERT INTO `distritos_municipales` VALUES ('175', 'Sabana Alta', '118');
INSERT INTO `distritos_municipales` VALUES ('176', 'Sabaneta', '118');
INSERT INTO `distritos_municipales` VALUES ('177', 'Arroyo Cano', '119');
INSERT INTO `distritos_municipales` VALUES ('178', 'Yaque', '119');
INSERT INTO `distritos_municipales` VALUES ('179', 'Batista', '120');
INSERT INTO `distritos_municipales` VALUES ('180', 'Derrumbadero', '120');
INSERT INTO `distritos_municipales` VALUES ('181', 'Jínova', '121');
INSERT INTO `distritos_municipales` VALUES ('182', 'Carrera de Yegua', '122');
INSERT INTO `distritos_municipales` VALUES ('183', 'Matayaya', '122');
INSERT INTO `distritos_municipales` VALUES ('184', 'Jorjillo', '123');
INSERT INTO `distritos_municipales` VALUES ('185', 'El Puerto', '129');
INSERT INTO `distritos_municipales` VALUES ('186', 'Gautier', '129');
INSERT INTO `distritos_municipales` VALUES ('187', 'Caballero', '130');
INSERT INTO `distritos_municipales` VALUES ('188', 'Comedero Arriba', '130');
INSERT INTO `distritos_municipales` VALUES ('189', 'Quita Sueño', '130');
INSERT INTO `distritos_municipales` VALUES ('190', 'La Cueva', '131');
INSERT INTO `distritos_municipales` VALUES ('191', 'Platanal', '131');
INSERT INTO `distritos_municipales` VALUES ('192', 'Angelina', '133');
INSERT INTO `distritos_municipales` VALUES ('193', 'La Bija', '133');
INSERT INTO `distritos_municipales` VALUES ('194', 'Hernando Alonzo', '133');
INSERT INTO `distritos_municipales` VALUES ('195', 'Baitoa', '134');
INSERT INTO `distritos_municipales` VALUES ('196', 'Hato del Yaque', '134');
INSERT INTO `distritos_municipales` VALUES ('197', 'La Canela', '134');
INSERT INTO `distritos_municipales` VALUES ('198', 'Pedro García', '134');
INSERT INTO `distritos_municipales` VALUES ('199', 'San Francisco de Jacagua', '134');
INSERT INTO `distritos_municipales` VALUES ('200', 'El Caimito', '136');
INSERT INTO `distritos_municipales` VALUES ('201', 'Juncalito', '136');
INSERT INTO `distritos_municipales` VALUES ('202', 'Las Palomas', '137');
INSERT INTO `distritos_municipales` VALUES ('203', 'Canabacoa', '137');
INSERT INTO `distritos_municipales` VALUES ('204', 'Guayabal', '137');
INSERT INTO `distritos_municipales` VALUES ('205', 'El Rubio', '140');
INSERT INTO `distritos_municipales` VALUES ('206', 'La Cuesta', '140');
INSERT INTO `distritos_municipales` VALUES ('207', 'Las Placetas', '140');
INSERT INTO `distritos_municipales` VALUES ('208', 'Canca La Piedra', '141');
INSERT INTO `distritos_municipales` VALUES ('209', 'El Limón', '142');
INSERT INTO `distritos_municipales` VALUES ('210', 'Palmar Arriba', '142');
INSERT INTO `distritos_municipales` VALUES ('211', 'San Luis', '146');
INSERT INTO `distritos_municipales` VALUES ('212', 'La Caleta', '147');
INSERT INTO `distritos_municipales` VALUES ('213', 'Palmarejo-Villa Linda', '148');
INSERT INTO `distritos_municipales` VALUES ('214', 'Pantoja', '148');
INSERT INTO `distritos_municipales` VALUES ('215', 'La Cuaba', '149');
INSERT INTO `distritos_municipales` VALUES ('216', 'La Guáyiga', '149');
INSERT INTO `distritos_municipales` VALUES ('217', 'Hato Viejo', '150');
INSERT INTO `distritos_municipales` VALUES ('218', 'La Victoria', '151');
INSERT INTO `distritos_municipales` VALUES ('219', 'Ámina', '153');
INSERT INTO `distritos_municipales` VALUES ('220', 'Guatapanal', '153');
INSERT INTO `distritos_municipales` VALUES ('221', 'Jaibón (Pueblo Nuevo)', '153');
INSERT INTO `distritos_municipales` VALUES ('222', 'Boca de Mao', '154');
INSERT INTO `distritos_municipales` VALUES ('223', 'Jicomé', '154');
INSERT INTO `distritos_municipales` VALUES ('224', 'Maizal', '154');
INSERT INTO `distritos_municipales` VALUES ('225', 'Paradero', '154');
INSERT INTO `distritos_municipales` VALUES ('226', 'Cruce de Guayacanes', '155');
INSERT INTO `distritos_municipales` VALUES ('227', 'Jaibón', '155');
INSERT INTO `distritos_municipales` VALUES ('228', 'La Caya', '155');

-- ----------------------------
-- Table structure for `entrada_inventario`
-- ----------------------------
DROP TABLE IF EXISTS `entrada_inventario`;
CREATE TABLE `entrada_inventario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idsuplidor` int(11) NOT NULL,
  `suplidor` varchar(250) NOT NULL,
  `fecha` date NOT NULL,
  `monto_total` decimal(12,2) NOT NULL DEFAULT '0.00',
  `total` decimal(12,2) NOT NULL,
  `anulada` varchar(1) NOT NULL DEFAULT '0',
  `anulada_comentario` mediumtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of entrada_inventario
-- ----------------------------

-- ----------------------------
-- Table structure for `entrada_inventario_detalle`
-- ----------------------------
DROP TABLE IF EXISTS `entrada_inventario_detalle`;
CREATE TABLE `entrada_inventario_detalle` (
  `id` int(11) NOT NULL,
  `idproducto` int(11) NOT NULL,
  `producto` varchar(250) NOT NULL,
  `tipo` varchar(1) NOT NULL,
  `precio` decimal(12,2) NOT NULL DEFAULT '0.00',
  `cantidad` int(11) NOT NULL,
  `subtotal` decimal(12,2) NOT NULL DEFAULT '0.00',
  `anulada` varchar(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of entrada_inventario_detalle
-- ----------------------------

-- ----------------------------
-- Table structure for `facturacion`
-- ----------------------------
DROP TABLE IF EXISTS `facturacion`;
CREATE TABLE `facturacion` (
  `idfacturacion` int(11) NOT NULL AUTO_INCREMENT,
  `idcliente` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `monto_b` decimal(12,2) NOT NULL DEFAULT '0.00',
  `descuento` decimal(12,2) NOT NULL DEFAULT '0.00',
  `monto_n` decimal(12,2) NOT NULL,
  `despachada` varchar(1) NOT NULL DEFAULT '0',
  `status` varchar(1) NOT NULL DEFAULT '0',
  `anulada` varchar(1) NOT NULL DEFAULT '0',
  `anulada_comentario` mediumtext,
  PRIMARY KEY (`idfacturacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of facturacion
-- ----------------------------

-- ----------------------------
-- Table structure for `facturacion_detalle`
-- ----------------------------
DROP TABLE IF EXISTS `facturacion_detalle`;
CREATE TABLE `facturacion_detalle` (
  `idfacturacion` int(11) NOT NULL,
  `idproducto` int(11) NOT NULL DEFAULT '0',
  `producto` varchar(250) NOT NULL,
  `tipo` varchar(1) NOT NULL,
  `precio` decimal(12,2) NOT NULL,
  `cantidad` int(11) NOT NULL DEFAULT '0',
  `subtotal` decimal(12,2) NOT NULL DEFAULT '0.00',
  `anulada` varchar(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of facturacion_detalle
-- ----------------------------

-- ----------------------------
-- Table structure for `gastos`
-- ----------------------------
DROP TABLE IF EXISTS `gastos`;
CREATE TABLE `gastos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(150) NOT NULL,
  `categoria` int(11) NOT NULL DEFAULT '9',
  `monto` decimal(12,2) NOT NULL DEFAULT '0.00',
  `fecha` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of gastos
-- ----------------------------

-- ----------------------------
-- Table structure for `gastos_tipo`
-- ----------------------------
DROP TABLE IF EXISTS `gastos_tipo`;
CREATE TABLE `gastos_tipo` (
  `idtipogasto` int(11) NOT NULL AUTO_INCREMENT,
  `desc_tipogasto` varchar(100) NOT NULL,
  PRIMARY KEY (`idtipogasto`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of gastos_tipo
-- ----------------------------
INSERT INTO `gastos_tipo` VALUES ('1', 'PAGO DE VIATICOS');
INSERT INTO `gastos_tipo` VALUES ('2', 'GASTOS EN COMBUSTIBLE');
INSERT INTO `gastos_tipo` VALUES ('3', 'GASTOS DE REPRESENTACION');
INSERT INTO `gastos_tipo` VALUES ('4', 'PAGO DE COMISION');
INSERT INTO `gastos_tipo` VALUES ('5', 'MATERIAL DE OFICINA');
INSERT INTO `gastos_tipo` VALUES ('6', 'PAGO DE SERVICIOS');
INSERT INTO `gastos_tipo` VALUES ('7', 'GASTOS SALARIOS');
INSERT INTO `gastos_tipo` VALUES ('8', 'GASTOS OFICINA');
INSERT INTO `gastos_tipo` VALUES ('9', 'GASTOS GENERALES');

-- ----------------------------
-- Table structure for `inventario`
-- ----------------------------
DROP TABLE IF EXISTS `inventario`;
CREATE TABLE `inventario` (
  `idproducto` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL,
  PRIMARY KEY (`idproducto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of inventario
-- ----------------------------

-- ----------------------------
-- Table structure for `municipios`
-- ----------------------------
DROP TABLE IF EXISTS `municipios`;
CREATE TABLE `municipios` (
  `municipio_id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  `provincia_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`municipio_id`),
  KEY `provincia_id_idx` (`provincia_id`),
  CONSTRAINT `provincia_id` FOREIGN KEY (`provincia_id`) REFERENCES `provincias` (`provincia_id`)
) ENGINE=InnoDB AUTO_INCREMENT=156 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of municipios
-- ----------------------------
INSERT INTO `municipios` VALUES ('1', 'Distrito Nacional', '5');
INSERT INTO `municipios` VALUES ('2', 'Azua de Compostela', '1');
INSERT INTO `municipios` VALUES ('3', 'Estebanía', '1');
INSERT INTO `municipios` VALUES ('4', 'Guayabal', '1');
INSERT INTO `municipios` VALUES ('5', 'Las Charcas', '1');
INSERT INTO `municipios` VALUES ('6', 'Las Yayas de Viajama', '1');
INSERT INTO `municipios` VALUES ('7', 'Padre Las Casas', '1');
INSERT INTO `municipios` VALUES ('8', 'Peralta', '1');
INSERT INTO `municipios` VALUES ('9', 'Pueblo Viejo', '1');
INSERT INTO `municipios` VALUES ('10', 'Sabana Yegua', '1');
INSERT INTO `municipios` VALUES ('11', 'Tábara Arriba', '1');
INSERT INTO `municipios` VALUES ('12', 'Neiba', '2');
INSERT INTO `municipios` VALUES ('13', 'Galván', '2');
INSERT INTO `municipios` VALUES ('14', 'Los Ríos', '2');
INSERT INTO `municipios` VALUES ('15', 'Tamayo', '2');
INSERT INTO `municipios` VALUES ('16', 'Villa Jaragua', '2');
INSERT INTO `municipios` VALUES ('17', 'Barahona', '3');
INSERT INTO `municipios` VALUES ('18', 'Cabral', '3');
INSERT INTO `municipios` VALUES ('19', 'El Peñón', '3');
INSERT INTO `municipios` VALUES ('20', 'Enriquillo', '3');
INSERT INTO `municipios` VALUES ('21', 'Fundación', '3');
INSERT INTO `municipios` VALUES ('22', 'Jaquimeyes', '3');
INSERT INTO `municipios` VALUES ('23', 'La Ciénaga', '3');
INSERT INTO `municipios` VALUES ('24', 'Las Salinas', '3');
INSERT INTO `municipios` VALUES ('25', 'Paraíso', '3');
INSERT INTO `municipios` VALUES ('26', 'Polo', '3');
INSERT INTO `municipios` VALUES ('27', 'Vicente Noble', '3');
INSERT INTO `municipios` VALUES ('28', 'Dajabón', '4');
INSERT INTO `municipios` VALUES ('29', 'El Pino', '4');
INSERT INTO `municipios` VALUES ('30', 'Loma de Cabrera', '4');
INSERT INTO `municipios` VALUES ('31', 'Partido', '4');
INSERT INTO `municipios` VALUES ('32', 'Restauración', '4');
INSERT INTO `municipios` VALUES ('33', 'San Francisco de Macorís', '6');
INSERT INTO `municipios` VALUES ('34', 'Arenoso', '6');
INSERT INTO `municipios` VALUES ('35', 'Castillo', '6');
INSERT INTO `municipios` VALUES ('36', 'Eugenio María de Hostos', '6');
INSERT INTO `municipios` VALUES ('37', 'Las Guáranas', '6');
INSERT INTO `municipios` VALUES ('38', 'Pimentel', '6');
INSERT INTO `municipios` VALUES ('39', 'Villa Riva', '6');
INSERT INTO `municipios` VALUES ('40', 'El Seibo', '8');
INSERT INTO `municipios` VALUES ('41', 'Miches', '8');
INSERT INTO `municipios` VALUES ('42', 'Comendador', '7');
INSERT INTO `municipios` VALUES ('43', 'Bánica', '7');
INSERT INTO `municipios` VALUES ('44', 'El Llano', '7');
INSERT INTO `municipios` VALUES ('45', 'Hondo Valle', '7');
INSERT INTO `municipios` VALUES ('46', 'Juan Santiago', '7');
INSERT INTO `municipios` VALUES ('47', 'Pedro Santana', '7');
INSERT INTO `municipios` VALUES ('48', 'Moca', '9');
INSERT INTO `municipios` VALUES ('49', 'Cayetano Germosén', '9');
INSERT INTO `municipios` VALUES ('50', 'Gaspar Hernández', '9');
INSERT INTO `municipios` VALUES ('51', 'Jamao al Norte', '9');
INSERT INTO `municipios` VALUES ('52', 'Hato Mayor del Rey', '10');
INSERT INTO `municipios` VALUES ('53', 'El Valle', '10');
INSERT INTO `municipios` VALUES ('54', 'Sabana de la Mar', '10');
INSERT INTO `municipios` VALUES ('55', 'Salcedo', '11');
INSERT INTO `municipios` VALUES ('56', 'Tenares', '11');
INSERT INTO `municipios` VALUES ('57', 'Villa Tapia', '11');
INSERT INTO `municipios` VALUES ('58', 'Jimaní', '12');
INSERT INTO `municipios` VALUES ('59', 'Cristóbal', '12');
INSERT INTO `municipios` VALUES ('60', 'Duvergé', '12');
INSERT INTO `municipios` VALUES ('61', 'La Descubierta', '12');
INSERT INTO `municipios` VALUES ('62', 'Mella', '12');
INSERT INTO `municipios` VALUES ('63', 'Postrer Río', '12');
INSERT INTO `municipios` VALUES ('64', 'Higüey', '13');
INSERT INTO `municipios` VALUES ('65', 'San Rafael del Yuma', '13');
INSERT INTO `municipios` VALUES ('66', 'La Romana', '14');
INSERT INTO `municipios` VALUES ('67', 'Guaymate', '14');
INSERT INTO `municipios` VALUES ('68', 'Villa Hermosa', '14');
INSERT INTO `municipios` VALUES ('69', 'La Concepción de La Vega', '15');
INSERT INTO `municipios` VALUES ('70', 'Constanza', '15');
INSERT INTO `municipios` VALUES ('71', 'Jarabacoa', '15');
INSERT INTO `municipios` VALUES ('72', 'Jima Abajo', '15');
INSERT INTO `municipios` VALUES ('73', 'Nagua', '16');
INSERT INTO `municipios` VALUES ('74', 'Cabrera', '16');
INSERT INTO `municipios` VALUES ('75', 'El Factor', '16');
INSERT INTO `municipios` VALUES ('76', 'Río San Juan', '16');
INSERT INTO `municipios` VALUES ('77', 'Bonao', '17');
INSERT INTO `municipios` VALUES ('78', 'Maimón', '17');
INSERT INTO `municipios` VALUES ('79', 'Piedra Blanca', '17');
INSERT INTO `municipios` VALUES ('80', 'Montecristi', '18');
INSERT INTO `municipios` VALUES ('81', 'Castañuela', '18');
INSERT INTO `municipios` VALUES ('82', 'Guayubín', '18');
INSERT INTO `municipios` VALUES ('83', 'Las Matas de Santa Cruz', '18');
INSERT INTO `municipios` VALUES ('84', 'Pepillo Salcedo', '18');
INSERT INTO `municipios` VALUES ('85', 'Villa Vásquez', '18');
INSERT INTO `municipios` VALUES ('86', 'Monte Plata', '19');
INSERT INTO `municipios` VALUES ('87', 'Bayaguana', '19');
INSERT INTO `municipios` VALUES ('88', 'Peralvillo', '19');
INSERT INTO `municipios` VALUES ('89', 'Sabana Grande de Boyá', '19');
INSERT INTO `municipios` VALUES ('90', 'Yamasá', '19');
INSERT INTO `municipios` VALUES ('91', 'Pedernales', '20');
INSERT INTO `municipios` VALUES ('92', 'Oviedo', '20');
INSERT INTO `municipios` VALUES ('93', 'Baní', '21');
INSERT INTO `municipios` VALUES ('94', 'Nizao', '21');
INSERT INTO `municipios` VALUES ('95', 'Puerto Plata', '22');
INSERT INTO `municipios` VALUES ('96', 'Altamira', '22');
INSERT INTO `municipios` VALUES ('97', 'Guananico', '22');
INSERT INTO `municipios` VALUES ('98', 'Imbert', '22');
INSERT INTO `municipios` VALUES ('99', 'Los Hidalgos', '22');
INSERT INTO `municipios` VALUES ('100', 'Luperón', '22');
INSERT INTO `municipios` VALUES ('101', 'Sosúa', '22');
INSERT INTO `municipios` VALUES ('102', 'Villa Isabela', '22');
INSERT INTO `municipios` VALUES ('103', 'Villa Montellano', '22');
INSERT INTO `municipios` VALUES ('104', 'Samaná', '23');
INSERT INTO `municipios` VALUES ('105', 'Las Terrenas', '23');
INSERT INTO `municipios` VALUES ('106', 'Sánchez', '23');
INSERT INTO `municipios` VALUES ('107', 'San Cristóbal', '25');
INSERT INTO `municipios` VALUES ('108', 'Bajos de Haina', '25');
INSERT INTO `municipios` VALUES ('109', 'Cambita Garabito', '25');
INSERT INTO `municipios` VALUES ('110', 'Los Cacaos', '25');
INSERT INTO `municipios` VALUES ('111', 'Sabana Grande de Palenque', '25');
INSERT INTO `municipios` VALUES ('112', 'San Gregorio de Nigua', '25');
INSERT INTO `municipios` VALUES ('113', 'Villa Altagracia', '25');
INSERT INTO `municipios` VALUES ('114', 'Yaguate', '25');
INSERT INTO `municipios` VALUES ('115', 'San José de Ocoa', '26');
INSERT INTO `municipios` VALUES ('116', 'Rancho Arriba', '26');
INSERT INTO `municipios` VALUES ('117', 'Sabana Larga', '26');
INSERT INTO `municipios` VALUES ('118', 'San Juan de la Maguana', '27');
INSERT INTO `municipios` VALUES ('119', 'Bohechío', '27');
INSERT INTO `municipios` VALUES ('120', 'El Cercado', '27');
INSERT INTO `municipios` VALUES ('121', 'Juan de Herrera', '27');
INSERT INTO `municipios` VALUES ('122', 'Las Matas de Farfán', '27');
INSERT INTO `municipios` VALUES ('123', 'Vallejuelo', '27');
INSERT INTO `municipios` VALUES ('124', 'San Pedro de Macorís', '28');
INSERT INTO `municipios` VALUES ('125', 'Consuelo', '28');
INSERT INTO `municipios` VALUES ('126', 'Guayacanes', '28');
INSERT INTO `municipios` VALUES ('127', 'Quisqueya', '28');
INSERT INTO `municipios` VALUES ('128', 'Ramón Santana', '28');
INSERT INTO `municipios` VALUES ('129', 'San José de Los Llanos', '28');
INSERT INTO `municipios` VALUES ('130', 'Cotuí', '24');
INSERT INTO `municipios` VALUES ('131', 'Cevicos', '24');
INSERT INTO `municipios` VALUES ('132', 'Fantino', '24');
INSERT INTO `municipios` VALUES ('133', 'La Mata', '24');
INSERT INTO `municipios` VALUES ('134', 'Santiago', '29');
INSERT INTO `municipios` VALUES ('135', 'Bisonó', '29');
INSERT INTO `municipios` VALUES ('136', 'Jánico', '29');
INSERT INTO `municipios` VALUES ('137', 'Licey al Medio', '29');
INSERT INTO `municipios` VALUES ('138', 'Puñal', '29');
INSERT INTO `municipios` VALUES ('139', 'Sabana Iglesia', '29');
INSERT INTO `municipios` VALUES ('140', 'San José de las Matas', '29');
INSERT INTO `municipios` VALUES ('141', 'Tamboril', '29');
INSERT INTO `municipios` VALUES ('142', 'Villa González', '29');
INSERT INTO `municipios` VALUES ('143', 'San Ignacio de Sabaneta', '30');
INSERT INTO `municipios` VALUES ('144', 'Los Almácigos', '30');
INSERT INTO `municipios` VALUES ('145', 'Monción', '30');
INSERT INTO `municipios` VALUES ('146', 'Santo Domingo Este', '31');
INSERT INTO `municipios` VALUES ('147', 'Boca Chica', '31');
INSERT INTO `municipios` VALUES ('148', 'Los Alcarrizos', '31');
INSERT INTO `municipios` VALUES ('149', 'Pedro Brand', '31');
INSERT INTO `municipios` VALUES ('150', 'San Antonio de Guerra', '31');
INSERT INTO `municipios` VALUES ('151', 'Santo Domingo Norte', '31');
INSERT INTO `municipios` VALUES ('152', 'Santo Domingo Oeste', '31');
INSERT INTO `municipios` VALUES ('153', 'Mao', '32');
INSERT INTO `municipios` VALUES ('154', 'Esperanza', '32');
INSERT INTO `municipios` VALUES ('155', 'Laguna Salada', '32');

-- ----------------------------
-- Table structure for `productos`
-- ----------------------------
DROP TABLE IF EXISTS `productos`;
CREATE TABLE `productos` (
  `idproducto` int(11) NOT NULL AUTO_INCREMENT,
  `producto` varchar(150) NOT NULL,
  `referencia` varchar(25) DEFAULT NULL,
  `descripcion` mediumtext,
  `imagen` mediumblob,
  `idcategoria` int(11) NOT NULL,
  `precio_a` decimal(12,2) NOT NULL,
  `precio_b` decimal(12,2) NOT NULL,
  `tipo` varchar(1) NOT NULL,
  `rutafoto` varchar(250) NOT NULL,
  `reorden` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idproducto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of productos
-- ----------------------------

-- ----------------------------
-- Table structure for `provincias`
-- ----------------------------
DROP TABLE IF EXISTS `provincias`;
CREATE TABLE `provincias` (
  `provincia_id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `zona` varchar(25) DEFAULT '0',
  PRIMARY KEY (`provincia_id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of provincias
-- ----------------------------
INSERT INTO `provincias` VALUES ('1', 'AZUA', '0');
INSERT INTO `provincias` VALUES ('2', 'BAHORUCO', '0');
INSERT INTO `provincias` VALUES ('3', 'BARAHONA', '0');
INSERT INTO `provincias` VALUES ('4', 'DAJABÓN', '0');
INSERT INTO `provincias` VALUES ('5', 'DISTRITO NACIONAL', '0');
INSERT INTO `provincias` VALUES ('6', 'DUARTE', '0');
INSERT INTO `provincias` VALUES ('7', 'ELÍAS PIÑA', '0');
INSERT INTO `provincias` VALUES ('8', 'EL SEIBO', '0');
INSERT INTO `provincias` VALUES ('9', 'ESPAILLAT', '0');
INSERT INTO `provincias` VALUES ('10', 'HATO MAYOR', '0');
INSERT INTO `provincias` VALUES ('11', 'HERMANAS MIRABAL', '0');
INSERT INTO `provincias` VALUES ('12', 'INDEPENDENCIA', '0');
INSERT INTO `provincias` VALUES ('13', 'LA ALTAGRACIA', '0');
INSERT INTO `provincias` VALUES ('14', 'LA ROMANA', '0');
INSERT INTO `provincias` VALUES ('15', 'LA VEGA', '0');
INSERT INTO `provincias` VALUES ('16', 'MARÍA TRINIDAD SÁNCHEZ', '0');
INSERT INTO `provincias` VALUES ('17', 'MONSEÑOR NOUEL', '0');
INSERT INTO `provincias` VALUES ('18', 'MONTE CRISTI', '0');
INSERT INTO `provincias` VALUES ('19', 'MONTE PLATA', '0');
INSERT INTO `provincias` VALUES ('20', 'PEDERNALES', '0');
INSERT INTO `provincias` VALUES ('21', 'PERAVIA', '0');
INSERT INTO `provincias` VALUES ('22', 'PUERTO PLATA', '0');
INSERT INTO `provincias` VALUES ('23', 'SAMANÁ', '0');
INSERT INTO `provincias` VALUES ('24', 'SÁNCHEZ RAMÍREZ', '0');
INSERT INTO `provincias` VALUES ('25', 'SAN CRISTÓBAL', '0');
INSERT INTO `provincias` VALUES ('26', 'SAN JOSÉ DE OCOA', '0');
INSERT INTO `provincias` VALUES ('27', 'SAN JUAN', '0');
INSERT INTO `provincias` VALUES ('28', 'SAN PEDRO DE MACORÍS', '0');
INSERT INTO `provincias` VALUES ('29', 'SANTIAGO', '0');
INSERT INTO `provincias` VALUES ('30', 'SANTIAGO RODRÍGUEZ', '0');
INSERT INTO `provincias` VALUES ('31', 'SANTO DOMINGO', '0');
INSERT INTO `provincias` VALUES ('32', 'VALVERDE', '0');

-- ----------------------------
-- Table structure for `suplidores`
-- ----------------------------
DROP TABLE IF EXISTS `suplidores`;
CREATE TABLE `suplidores` (
  `idsuplidor` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(150) NOT NULL,
  `rnc` varchar(25) DEFAULT NULL,
  `direccion` varchar(150) DEFAULT NULL,
  `provincia` int(11) NOT NULL,
  `telefono` varchar(25) DEFAULT '(000) 000-0000',
  `status` varchar(1) NOT NULL,
  PRIMARY KEY (`idsuplidor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of suplidores
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
INSERT INTO `usuarios` VALUES ('2', 'ventas', 'ventas', '', '1');
