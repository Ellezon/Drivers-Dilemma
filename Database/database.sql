-- phpMyAdmin SQL Dump
-- version 4.4.15.5
-- http://www.phpmyadmin.net
--
-- Host: localhost:3306
-- Generation Time: Dec 14, 2016 at 12:57 PM
-- Server version: 5.5.49-log
-- PHP Version: 7.0.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `game`
--

-- --------------------------------------------------------

--
-- Table structure for table `choices_table`
--

CREATE TABLE IF NOT EXISTS `choices_table` (
  `choice_id` int(11) NOT NULL,
  `player_id` int(11) NOT NULL,
  `choice` varchar(30) NOT NULL,
  `scene` int(2) NOT NULL,
  `comb_id` int(4) NOT NULL,
  `time_given` double NOT NULL,
  `time_taken` double NOT NULL,
  `took_action` tinyint(1) NOT NULL,
  `law_abiding` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `combinations_table`
--

CREATE TABLE IF NOT EXISTS `combinations_table` (
  `comb_id` int(4) NOT NULL,
  `choice_1` varchar(30) NOT NULL,
  `choice_2` varchar(30) NOT NULL,
  `choice_3` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `player_table`
--

CREATE TABLE IF NOT EXISTS `player_table` (
  `player_id` int(10) NOT NULL,
  `gender` varchar(6) NOT NULL,
  `age` int(2) NOT NULL,
  `nationality` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `choices_table`
--
ALTER TABLE `choices_table`
  ADD PRIMARY KEY (`choice_id`),
  ADD KEY `player_id` (`player_id`,`comb_id`),
  ADD KEY `comb_id` (`comb_id`);

--
-- Indexes for table `combinations_table`
--
ALTER TABLE `combinations_table`
  ADD PRIMARY KEY (`comb_id`);

--
-- Indexes for table `player_table`
--
ALTER TABLE `player_table`
  ADD PRIMARY KEY (`player_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `choices_table`
--
ALTER TABLE `choices_table`
  MODIFY `choice_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `combinations_table`
--
ALTER TABLE `combinations_table`
  MODIFY `comb_id` int(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `player_table`
--
ALTER TABLE `player_table`
  MODIFY `player_id` int(10) NOT NULL AUTO_INCREMENT;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `choices_table`
--
ALTER TABLE `choices_table`
  ADD CONSTRAINT `comb_id` FOREIGN KEY (`comb_id`) REFERENCES `combinations_table` (`comb_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `player_id` FOREIGN KEY (`player_id`) REFERENCES `player_table` (`player_id`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
