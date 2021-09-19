-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- 主機： db
-- 產生時間： 2021 年 09 月 19 日 12:30
-- 伺服器版本： 8.0.26
-- PHP 版本： 7.4.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- 資料庫: `WalkToFly`
--

-- --------------------------------------------------------

--
-- 資料表結構 `areas`
--

CREATE TABLE `areas` (
  `id` int NOT NULL,
  `name` varchar(30) NOT NULL,
  `city_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- 傾印資料表的資料 `areas`
--

INSERT INTO `areas` (`id`, `name`, `city_id`) VALUES
(1, '中正區', 1),
(2, '大同區', 1),
(3, '中山區', 1),
(4, '松山區', 1),
(5, '大安區', 1),
(6, '萬華區', 1),
(7, '信義區', 1),
(8, '士林區', 1),
(9, '北投區', 1),
(10, '內湖區', 1),
(11, '南港區', 1),
(12, '文山區', 1),
(13, '仁愛區', 3),
(14, '信義區', 3),
(15, '中正區', 3),
(16, '中山區', 3),
(17, '安樂區', 3),
(18, '暖暖區', 3),
(19, '七堵區', 3),
(20, '萬里區', 2),
(21, '金山區', 2),
(22, '板橋區', 2),
(23, '汐止區', 2),
(24, '深坑區', 2),
(25, '石碇區', 2),
(26, '瑞芳區', 2),
(27, '平溪區', 2),
(28, '雙溪區', 2),
(29, '貢寮區', 2),
(30, '新店區', 2),
(31, '坪林區', 2),
(32, '烏來區', 2),
(33, '永和區', 2),
(34, '中和區', 2),
(35, '土城區', 2),
(36, '三峽區', 2),
(37, '樹林區', 2),
(38, '鶯歌區', 2),
(39, '三重區', 2),
(40, '新莊區', 2),
(41, '泰山區', 2),
(42, '林口區', 2),
(43, '蘆洲區', 2),
(44, '五股區', 2),
(45, '八里區', 2),
(46, '淡水區', 2),
(47, '三芝區', 2),
(48, '石門區', 2),
(49, '宜蘭市', 17),
(50, '頭城鎮', 17),
(51, '礁溪鄉', 17),
(52, '壯圍鄉', 17),
(53, '員山鄉', 17),
(54, '羅東鎮', 17),
(55, '三星鄉', 17),
(56, '大同鄉', 17),
(57, '五結鄉', 17),
(58, '冬山鄉', 17),
(59, '蘇澳鎮', 17),
(60, '南澳鄉', 17),
(61, '東區', 5),
(62, '北區', 5),
(63, '香山區', 5),
(64, '竹北市', 6),
(65, '湖口鄉', 6),
(66, '新豐鄉', 6),
(67, '新埔鎮', 6),
(68, '關西鎮', 6),
(69, '芎林鄉', 6),
(70, '寶山鄉', 6),
(71, '竹東鎮', 6),
(72, '五峰鄉', 6),
(73, '橫山鄉', 6),
(74, '尖石鄉', 6),
(75, '北埔鄉', 6),
(76, '峨嵋鄉', 6),
(77, '中壢區', 4),
(78, '平鎮區', 4),
(79, '龍潭區', 4),
(80, '楊梅區', 4),
(81, '新屋區', 4),
(82, '觀音區', 4),
(83, '桃園區', 4),
(84, '龜山區', 4),
(85, '八德區', 4),
(86, '大溪區', 4),
(87, '復興區', 4),
(88, '大園區', 4),
(89, '蘆竹區', 4),
(90, '竹南鎮', 7),
(91, '頭份市', 7),
(92, '三灣鄉', 7),
(93, '南庄鄉', 7),
(94, '獅潭鄉', 7),
(95, '後龍鎮', 7),
(96, '通霄鎮', 7),
(97, '苑裡鎮', 7),
(98, '苗栗市', 7),
(99, '造橋鄉', 7),
(100, '頭屋鄉', 7),
(101, '公館鄉', 7),
(102, '大湖鄉', 7),
(103, '泰安鄉', 7),
(104, '銅鑼鄉', 7),
(105, '三義鄉', 7),
(106, '西湖鄉', 7),
(107, '卓蘭鎮', 7),
(108, '中區', 8),
(109, '東區', 8),
(110, '南區', 8),
(111, '西區', 8),
(112, '北區', 8),
(113, '北屯區', 8),
(114, '西屯區', 8),
(115, '南屯區', 8),
(116, '太平區', 8),
(117, '大里區', 8),
(118, '霧峰區', 8),
(119, '烏日區', 8),
(120, '豐原區', 8),
(121, '后里區', 8),
(122, '石岡區', 8),
(123, '東勢區', 8),
(124, '和平區', 8),
(125, '新社區', 8),
(126, '潭子區', 8),
(127, '大雅區', 8),
(128, '神岡區', 8),
(129, '大肚區', 8),
(130, '沙鹿區', 8),
(131, '龍井區', 8),
(132, '梧棲區', 8),
(133, '清水區', 8),
(134, '大甲區', 8),
(135, '外埔區', 8),
(136, '大安區', 8),
(137, '彰化市', 9),
(138, '芬園鄉', 9),
(139, '花壇鄉', 9),
(140, '秀水鄉', 9),
(141, '鹿港鎮', 9),
(142, '福興鄉', 9),
(143, '線西鄉', 9),
(144, '和美鎮', 9),
(145, '伸港鄉', 9),
(146, '員林市', 9),
(147, '社頭鄉', 9),
(148, '永靖鄉', 9),
(149, '埔心鄉', 9),
(150, '溪湖鎮', 9),
(151, '大村鄉', 9),
(152, '埔鹽鄉', 9),
(153, '田中鎮', 9),
(154, '北斗鎮', 9),
(155, '田尾鄉', 9),
(156, '埤頭鄉', 9),
(157, '溪州鄉', 9),
(158, '竹塘鄉', 9),
(159, '二林鎮', 9),
(160, '大城鄉', 9),
(161, '芳苑鄉', 9),
(162, '二水鄉', 9),
(163, '南投市', 10),
(164, '中寮鄉', 10),
(165, '草屯鎮', 10),
(166, '國姓鄉', 10),
(167, '埔里鎮', 10),
(168, '仁愛鄉', 10),
(169, '名間鄉', 10),
(170, '集集鎮', 10),
(171, '水里鄉', 10),
(172, '魚池鄉', 10),
(173, '信義鄉', 10),
(174, '竹山鎮', 10),
(175, '鹿谷鄉', 10),
(176, '西區', 11),
(177, '東區', 11),
(178, '番路鄉', 12),
(179, '梅山鄉', 12),
(180, '竹崎鄉', 12),
(181, '阿里山鄉', 12),
(182, '中埔鄉', 12),
(183, '大埔鄉', 12),
(184, '水上鄉', 12),
(185, '鹿草鄉', 12),
(186, '太保市', 12),
(187, '朴子市', 12),
(188, '東石鄉', 12),
(189, '六腳鄉', 12),
(190, '新港鄉', 12),
(191, '民雄鄉', 12),
(192, '大林鎮', 12),
(193, '溪口鄉', 12),
(194, '義竹鄉', 12),
(195, '布袋鎮', 12),
(196, '斗南鎮', 13),
(197, '大埤鄉', 13),
(198, '虎尾鎮', 13),
(199, '土庫鎮', 13),
(200, '褒忠鄉', 13),
(201, '東勢鄉', 13),
(202, '臺西鄉', 13),
(203, '崙背鄉', 13),
(204, '麥寮鄉', 13),
(205, '斗六市', 13),
(206, '林內鄉', 13),
(207, '古坑鄉', 13),
(208, '莿桐鄉', 13),
(209, '西螺鎮', 13),
(210, '二崙鄉', 13),
(211, '北港鎮', 13),
(212, '水林鄉', 13),
(213, '口湖鄉', 13),
(214, '四湖鄉', 13),
(215, '元長鄉', 13),
(216, '中西區', 14),
(217, '東區', 14),
(218, '南區', 14),
(219, '北區', 14),
(220, '安平區', 14),
(221, '安南區', 14),
(222, '永康區', 14),
(223, '歸仁區', 14),
(224, '新化區', 14),
(225, '左鎮區', 14),
(226, '玉井區', 14),
(227, '楠西區', 14),
(228, '南化區', 14),
(229, '仁德區', 14),
(230, '關廟區', 14),
(231, '龍崎區', 14),
(232, '官田區', 14),
(233, '麻豆區', 14),
(234, '佳里區', 14),
(235, '西港區', 14),
(236, '七股區', 14),
(237, '將軍區', 14),
(238, '學甲區', 14),
(239, '北門區', 14),
(240, '新營區', 14),
(241, '後壁區', 14),
(242, '白河區', 14),
(243, '東山區', 14),
(244, '六甲區', 14),
(245, '下營區', 14),
(246, '柳營區', 14),
(247, '鹽水區', 14),
(248, '善化區', 14),
(249, '大內區', 14),
(250, '山上區', 14),
(251, '新市區', 14),
(252, '安定區', 14),
(253, '新興區', 15),
(254, '前金區', 15),
(255, '芩雅區', 15),
(256, '鹽埕區', 15),
(257, '鼓山區', 15),
(258, '旗津區', 15),
(259, '前鎮區', 15),
(260, '三民區', 15),
(261, '楠梓區', 15),
(262, '小港區', 15),
(263, '左營區', 15),
(264, '仁武區', 15),
(265, '大社區', 15),
(266, '岡山區', 15),
(267, '路竹區', 15),
(268, '阿蓮區', 15),
(269, '田寮區', 15),
(270, '燕巢區', 15),
(271, '橋頭區', 15),
(272, '梓官區', 15),
(273, '彌陀區', 15),
(274, '永安區', 15),
(275, '湖內區', 15),
(276, '鳳山區', 15),
(277, '大寮區', 15),
(278, '林園區', 15),
(279, '鳥松區', 15),
(280, '大樹區', 15),
(281, '旗山區', 15),
(282, '美濃區', 15),
(283, '六龜區', 15),
(284, '內門區', 15),
(285, '杉林區', 15),
(286, '甲仙區', 15),
(287, '桃源區', 15),
(288, '三民區', 15),
(289, '那瑪夏區', 15),
(290, '茂林區', 15),
(291, '茄萣區', 15),
(292, '馬公市', 20),
(293, '西嶼鄉', 20),
(294, '望安鄉', 20),
(295, '七美鄉', 20),
(296, '白沙鄉', 20),
(297, '湖西鄉', 20),
(298, '屏東市', 16),
(299, '三地門鄉', 16),
(300, '霧臺鄉', 16),
(301, '瑪家鄉', 16),
(302, '九如鄉', 16),
(303, '里港鄉', 16),
(304, '高樹鄉', 16),
(305, '盬埔鄉', 16),
(306, '長治鄉', 16),
(307, '麟洛鄉', 16),
(308, '竹田鄉', 16),
(309, '內埔鄉', 16),
(310, '萬丹鄉', 16),
(311, '潮州鎮', 16),
(312, '泰武鄉', 16),
(313, '來義鄉', 16),
(314, '萬巒鄉', 16),
(315, '崁頂鄉', 16),
(316, '新埤鄉', 16),
(317, '南州鄉', 16),
(318, '林邊鄉', 16),
(319, '東港鎮', 16),
(320, '琉球鄉', 16),
(321, '佳冬鄉', 16),
(322, '新園鄉', 16),
(323, '枋寮鄉', 16),
(324, '枋山鄉', 16),
(325, '春日鄉', 16),
(326, '獅子鄉', 16),
(327, '車城鄉', 16),
(328, '牡丹鄉', 16),
(329, '恆春鎮', 16),
(330, '滿州鄉', 16),
(331, '臺東市', 19),
(332, '綠島鄉', 19),
(333, '蘭嶼鄉', 19),
(334, '延平鄉', 19),
(335, '卑南鄉', 19),
(336, '鹿野鄉', 19),
(337, '關山鎮', 19),
(338, '海端鄉', 19),
(339, '池上鄉', 19),
(340, '東河鄉', 19),
(341, '成功鎮', 19),
(342, '長濱鄉', 19),
(343, '太麻里鄉', 19),
(344, '金峰鄉', 19),
(345, '大武鄉', 19),
(346, '達仁鄉', 19),
(347, '花蓮市', 18),
(348, '新城鄉', 18),
(349, '秀林鄉', 18),
(350, '吉安鄉', 18),
(351, '壽豐鄉', 18),
(352, '鳳林鎮', 18),
(353, '光復鄉', 18),
(354, '豐濱鄉', 18),
(355, '瑞穗鄉', 18),
(356, '萬榮鄉', 18),
(357, '玉里鎮', 18),
(358, '卓溪鄉', 18),
(359, '富里鄉', 18),
(360, '金沙鎮', 21),
(361, '金湖鎮', 21),
(362, '金寧鄉', 21),
(363, '金城鎮', 21),
(364, '烈嶼鄉', 21),
(365, '烏坵鄉', 21),
(366, '南竿鄉', 22),
(367, '北竿鄉', 22),
(368, '莒光鄉', 22),
(369, '東引鄉', 22);

-- --------------------------------------------------------

--
-- 資料表結構 `citys`
--

CREATE TABLE `citys` (
  `id` int NOT NULL,
  `name` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- 傾印資料表的資料 `citys`
--

INSERT INTO `citys` (`id`, `name`) VALUES
(1, '台北市'),
(2, '新北市'),
(3, '基隆市'),
(4, '桃園市'),
(5, '新竹市'),
(6, '新竹縣'),
(7, '苗栗縣'),
(8, '台中市'),
(9, '彰化縣'),
(10, '南投縣'),
(11, '嘉義市'),
(12, '嘉義縣'),
(13, '雲林縣'),
(14, '台南市'),
(15, '高雄市'),
(16, '屏東縣'),
(17, '宜蘭縣'),
(18, '花蓮縣'),
(19, '台東縣'),
(20, '澎湖縣'),
(21, '金門縣'),
(22, '連江縣');

-- --------------------------------------------------------

--
-- 資料表結構 `Member`
--

CREATE TABLE `Member` (
  `MemberId` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '會員帳號',
  `FirstName` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '姓氏',
  `LastName` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '名稱',
  `PassWord` varchar(200) COLLATE utf8mb4_general_ci NOT NULL COMMENT '密碼',
  `Email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '信箱',
  `BirthDay` datetime NOT NULL COMMENT '生日',
  `Sex` tinyint(1) NOT NULL COMMENT '性別',
  `MobilePhone` varchar(10) COLLATE utf8mb4_general_ci NOT NULL COMMENT '手機',
  `TelePhone` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '市話',
  `City` int DEFAULT NULL COMMENT '縣市',
  `Area` int DEFAULT NULL COMMENT '鄉鎮市區',
  `Address` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '地址',
  `CreateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '建立日期',
  `UpdateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '修改日期',
  `EnableFlag` tinyint(1) NOT NULL COMMENT '是否啟用'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='會員';

--
-- 傾印資料表的資料 `Member`
--

INSERT INTO `Member` (`MemberId`, `FirstName`, `LastName`, `PassWord`, `Email`, `BirthDay`, `Sex`, `MobilePhone`, `TelePhone`, `City`, `Area`, `Address`, `CreateTime`, `UpdateTime`, `EnableFlag`) VALUES
('roy', '邱', '帥哥', '8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', 'roy@gmail.com', '1995-10-28 00:00:00', 1, '0912345678', NULL, 1, 1, '你猜猜看', '2021-08-25 21:34:09', '2021-08-29 10:41:07', 1),
('test1234', 'A', 'BC', '8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', 'a123@gmail.com.tw', '2020-12-31 16:00:00', 1, '0912345678', NULL, 2, 39, '111111', '2021-09-11 21:34:58', '2021-09-11 21:34:58', 0),
('wei12345', '張', '育瑋', '03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4', 'yuwei18963@gmail.com', '1996-04-07 16:00:00', 1, '0916598536', NULL, 2, 39, '仁化街 66號 五樓', '2021-09-01 23:40:24', '2021-09-01 23:40:24', 0),
('wei123456', '張', '育瑋', '8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', 'yuwei18963@gmail.com', '1996-04-07 16:00:00', 1, '0916598536', NULL, 2, 39, '仁化街 66號 五樓', '2021-09-16 20:37:34', '2021-09-16 20:37:34', 0);

-- --------------------------------------------------------

--
-- 資料表結構 `SystemFunction`
--

CREATE TABLE `SystemFunction` (
  `FunctionId` int UNSIGNED NOT NULL COMMENT '大功能Id',
  `FunctionName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '大功能名稱',
  `FunctionChineseName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '大功能中文名稱',
  `EnableFlag` tinyint(1) NOT NULL DEFAULT '1' COMMENT '是否啟用',
  `Remark` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '備註',
  `Sort` int UNSIGNED DEFAULT NULL COMMENT '排序'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='大功能(選單表頭用)';

--
-- 傾印資料表的資料 `SystemFunction`
--

INSERT INTO `SystemFunction` (`FunctionId`, `FunctionName`, `FunctionChineseName`, `EnableFlag`, `Remark`, `Sort`) VALUES
(1, 'MemberManager', '會員管理', 1, NULL, NULL),
(2, 'OrderManage', '訂單管理', 1, NULL, NULL),
(3, 'ProductManage', '商品管理', 1, NULL, NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `SystemFunctionDetail`
--

CREATE TABLE `SystemFunctionDetail` (
  `FunctionDetailId` int UNSIGNED NOT NULL COMMENT '附屬功能Id',
  `FunctionId` int UNSIGNED NOT NULL COMMENT '大功能Id RF:SystemFunction. FunctionId',
  `FunctionDetailName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '附屬功能名稱',
  `FunctionDetailChineseName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '附屬功能中文名稱',
  `Remark` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '備註',
  `Sort` int UNSIGNED DEFAULT NULL COMMENT '排序',
  `EnableFlag` tinyint(1) NOT NULL DEFAULT '1' COMMENT '是否啟用'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='附屬功能(大功能底下)';

--
-- 傾印資料表的資料 `SystemFunctionDetail`
--

INSERT INTO `SystemFunctionDetail` (`FunctionDetailId`, `FunctionId`, `FunctionDetailName`, `FunctionDetailChineseName`, `Remark`, `Sort`, `EnableFlag`) VALUES
(1, 1, 'ChangPassword', '更換密碼', NULL, NULL, 1),
(2, 3, 'CreateProduct', '新增商品', NULL, NULL, 1),
(5, 2, 'CreateOrder', '新增訂單', NULL, NULL, 1),
(6, 3, 'DeleteProduct', '刪除商品', NULL, NULL, 1),
(7, 1, 'MemberList', '會員一覽', NULL, NULL, 1);

--
-- 觸發器 `SystemFunctionDetail`
--
DELIMITER $$
CREATE TRIGGER `SystemFunctionDetail_Insert` AFTER INSERT ON `SystemFunctionDetail` FOR EACH ROW INSERT INTO SystemRoleUserFunction
(
    RoleUserId,
    FunctionDetailId
)
VALUES
(
    1,
    NEW.FunctionDetailId
)
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- 資料表結構 `SystemRole`
--

CREATE TABLE `SystemRole` (
  `RoleId` int UNSIGNED NOT NULL COMMENT '規則Id',
  `MemberId` varchar(20) CHARACTER SET utf8 NOT NULL COMMENT '會員帳號 RF: Member.MemberId',
  `RoleUserId` int UNSIGNED NOT NULL COMMENT '角色IdRF: SystemRoleUser. RoleUserId'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='規則(帳號綁角色)';

--
-- 傾印資料表的資料 `SystemRole`
--

INSERT INTO `SystemRole` (`RoleId`, `MemberId`, `RoleUserId`) VALUES
(1, 'roy', 1),
(2, 'wei12345', 1);

-- --------------------------------------------------------

--
-- 資料表結構 `SystemRoleUser`
--

CREATE TABLE `SystemRoleUser` (
  `RoleUserId` int UNSIGNED NOT NULL COMMENT '角色Id',
  `RoleUserName` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '角色名稱'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `SystemRoleUser`
--

INSERT INTO `SystemRoleUser` (`RoleUserId`, `RoleUserName`) VALUES
(1, 'administrator'),
(2, 'manager'),
(3, 'user');

-- --------------------------------------------------------

--
-- 資料表結構 `SystemRoleUserFunction`
--

CREATE TABLE `SystemRoleUserFunction` (
  `RoleUserFunctionId` int UNSIGNED NOT NULL COMMENT '角色功能Id',
  `RoleUserId` int UNSIGNED NOT NULL COMMENT '角色Id RF: SystemRoleUser. RoleUserId',
  `FunctionDetailId` int UNSIGNED NOT NULL COMMENT '附屬功能Id RF:SystemFunctionDetail'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='角色功能(角色綁功能)';

--
-- 傾印資料表的資料 `SystemRoleUserFunction`
--

INSERT INTO `SystemRoleUserFunction` (`RoleUserFunctionId`, `RoleUserId`, `FunctionDetailId`) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 1, 5),
(4, 1, 6),
(5, 1, 7);

--
-- 已傾印資料表的索引
--

--
-- 資料表索引 `areas`
--
ALTER TABLE `areas`
  ADD PRIMARY KEY (`id`);

--
-- 資料表索引 `Member`
--
ALTER TABLE `Member`
  ADD PRIMARY KEY (`MemberId`);

--
-- 資料表索引 `SystemFunction`
--
ALTER TABLE `SystemFunction`
  ADD PRIMARY KEY (`FunctionId`);

--
-- 資料表索引 `SystemFunctionDetail`
--
ALTER TABLE `SystemFunctionDetail`
  ADD PRIMARY KEY (`FunctionDetailId`);

--
-- 資料表索引 `SystemRole`
--
ALTER TABLE `SystemRole`
  ADD PRIMARY KEY (`RoleId`) USING BTREE;

--
-- 資料表索引 `SystemRoleUser`
--
ALTER TABLE `SystemRoleUser`
  ADD PRIMARY KEY (`RoleUserId`);

--
-- 資料表索引 `SystemRoleUserFunction`
--
ALTER TABLE `SystemRoleUserFunction`
  ADD PRIMARY KEY (`RoleUserFunctionId`);

--
-- 在傾印的資料表使用自動遞增(AUTO_INCREMENT)
--

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `areas`
--
ALTER TABLE `areas`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=370;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `SystemFunction`
--
ALTER TABLE `SystemFunction`
  MODIFY `FunctionId` int UNSIGNED NOT NULL AUTO_INCREMENT COMMENT '大功能Id', AUTO_INCREMENT=4;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `SystemFunctionDetail`
--
ALTER TABLE `SystemFunctionDetail`
  MODIFY `FunctionDetailId` int UNSIGNED NOT NULL AUTO_INCREMENT COMMENT '附屬功能Id', AUTO_INCREMENT=8;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `SystemRole`
--
ALTER TABLE `SystemRole`
  MODIFY `RoleId` int UNSIGNED NOT NULL AUTO_INCREMENT COMMENT '規則Id', AUTO_INCREMENT=3;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `SystemRoleUser`
--
ALTER TABLE `SystemRoleUser`
  MODIFY `RoleUserId` int UNSIGNED NOT NULL AUTO_INCREMENT COMMENT '角色Id', AUTO_INCREMENT=4;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `SystemRoleUserFunction`
--
ALTER TABLE `SystemRoleUserFunction`
  MODIFY `RoleUserFunctionId` int UNSIGNED NOT NULL AUTO_INCREMENT COMMENT '角色功能Id', AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
