-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Oct 14, 2019 at 08:52 PM
-- Server version: 5.7.26
-- PHP Version: 7.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mydatabase`
--

-- --------------------------------------------------------

--
-- Table structure for table `mjerenja`
--

DROP TABLE IF EXISTS `mjerenja`;
CREATE TABLE IF NOT EXISTS `mjerenja` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `vrijeme_datum` varchar(1000) NOT NULL,
  `temperatura_dht` float NOT NULL,
  `vlaznost_dht` float NOT NULL,
  `ntc` float NOT NULL,
  `temperatura_ds` float NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=479 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `mjerenja`
--

INSERT INTO `mjerenja` (`ID`, `vrijeme_datum`, `temperatura_dht`, `vlaznost_dht`, `ntc`, `temperatura_ds`) VALUES
(473, '10/13/2019 9:33:37 PM', 36.5, 84.6, 1.53, -127),
(472, '10/13/2019 9:33:26 PM', 36.5, 84.6, 1.53, -127),
(471, '10/13/2019 9:33:17 PM', 36.5, 84.6, 1.5, -127),
(478, '10/14/2019 10:49:36 PM', 43.5, 84.6, 1.53, -127),
(477, '10/14/2019 10:34:58 PM', 43.5, 84.6, 1.53, -127);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
