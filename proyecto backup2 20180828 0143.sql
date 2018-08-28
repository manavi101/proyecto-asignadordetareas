-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.1.45-community


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema proyecto
--

CREATE DATABASE IF NOT EXISTS proyecto;
USE proyecto;

--
-- Definition of table `asignartareas`
--

DROP TABLE IF EXISTS `asignartareas`;
CREATE TABLE `asignartareas` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `sector` varchar(45) NOT NULL,
  `rol` varchar(45) NOT NULL,
  `empleado` varchar(45) NOT NULL,
  `Fechainicial` varchar(45) NOT NULL,
  `Fechamaxima` varchar(45) NOT NULL,
  `Tarea` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `asignartareas`
--

/*!40000 ALTER TABLE `asignartareas` DISABLE KEYS */;
INSERT INTO `asignartareas` (`id`,`sector`,`rol`,`empleado`,`Fechainicial`,`Fechamaxima`,`Tarea`) VALUES 
 (1,'prueba','prueba','prueba','prueba','prueba','prueba'),
 (2,'it','tecnico','matias','viernes, 3 de agosto de 2018','viernes, 3 de agosto de 2018','hola'),
 (3,'it','tecnico','matias','martes, 7 de agosto de 2018','martes, 7 de agosto de 2018','biya'),
 (4,'ventas','vendedor','franco','15/08/2018','15/08/2018','hacer algo\r\n'),
 (5,'ventas','vendedor','franco','15/08/2018','15/08/2018','hacer muchas cosas'),
 (6,'it','tecnico','matias','15/08/2018','15/08/2018','asdsadsdasasdssda'),
 (7,'ventas','vendedor','franco','18/08/2018','18/08/2018','villla');
/*!40000 ALTER TABLE `asignartareas` ENABLE KEYS */;


--
-- Definition of table `inventario`
--

DROP TABLE IF EXISTS `inventario`;
CREATE TABLE `inventario` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `stock` varchar(45) NOT NULL,
  `precio` varchar(45) NOT NULL,
  `distribuidor` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `inventario`
--

/*!40000 ALTER TABLE `inventario` DISABLE KEYS */;
INSERT INTO `inventario` (`id`,`nombre`,`stock`,`precio`,`distribuidor`) VALUES 
 (1,'GTX1060','3','10000','NVIDIA'),
 (2,'GTX1070','5','15000','NVIDIA'),
 (3,'RX550','2','7000','AMD'),
 (4,'RX560','1','12000','AMD'),
 (5,'I5 8400','4','6000','INTEL'),
 (6,'I3 8100','0','4000','INTEL');
/*!40000 ALTER TABLE `inventario` ENABLE KEYS */;


--
-- Definition of table `login`
--

DROP TABLE IF EXISTS `login`;
CREATE TABLE `login` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `usuario` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `empleado` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `login`
--

/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login` (`id`,`usuario`,`password`,`empleado`) VALUES 
 (1,'admin','12345','admin'),
 (2,'franco','12345','franco'),
 (3,'matias','12345','matias'),
 (4,'colo','12345','colo'),
 (5,'nacho','12345','nacho'),
 (6,'santi','12345','santi');
/*!40000 ALTER TABLE `login` ENABLE KEYS */;


--
-- Definition of table `roles`
--

DROP TABLE IF EXISTS `roles`;
CREATE TABLE `roles` (
  `idrol` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `rol` varchar(45) NOT NULL,
  `sector` varchar(45) NOT NULL,
  `categoria` int(10) unsigned NOT NULL,
  PRIMARY KEY (`idrol`) USING BTREE,
  KEY `sector` (`sector`),
  KEY `index` (`rol`),
  CONSTRAINT `sector` FOREIGN KEY (`sector`) REFERENCES `sector` (`sector`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `roles`
--

/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` (`idrol`,`rol`,`sector`,`categoria`) VALUES 
 (1,'tecnico','it',3),
 (2,'supervisor','it',2),
 (3,'vendedor','ventas',3),
 (4,'gerente','ventas',2),
 (5,'cadete','administracion',3),
 (6,'administrador','administracion',2),
 (7,'Dueño','Dueño',1);
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;


--
-- Definition of table `sector`
--

DROP TABLE IF EXISTS `sector`;
CREATE TABLE `sector` (
  `id sector` int(10) unsigned NOT NULL,
  `sector` varchar(45) NOT NULL,
  PRIMARY KEY (`sector`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sector`
--

/*!40000 ALTER TABLE `sector` DISABLE KEYS */;
INSERT INTO `sector` (`id sector`,`sector`) VALUES 
 (3,'administracion'),
 (4,'Dueño'),
 (2,'it'),
 (1,'ventas');
/*!40000 ALTER TABLE `sector` ENABLE KEYS */;


--
-- Definition of table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
CREATE TABLE `usuario` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `rol` int(10) unsigned NOT NULL,
  `empleado` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `rol` (`rol`),
  CONSTRAINT `id` FOREIGN KEY (`id`) REFERENCES `login` (`id`) ON UPDATE CASCADE,
  CONSTRAINT `rol` FOREIGN KEY (`rol`) REFERENCES `roles` (`idrol`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `usuario`
--

/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` (`id`,`rol`,`empleado`) VALUES 
 (1,7,'admin'),
 (2,2,'matias'),
 (3,4,'franco'),
 (4,7,'colo'),
 (5,3,'nacho'),
 (6,5,'santi');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
