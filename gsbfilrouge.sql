-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : ven. 18 mars 2022 à 07:24
-- Version du serveur :  5.7.31
-- Version de PHP : 7.4.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `gsbfilrouge`
--

-- --------------------------------------------------------

--
-- Structure de la table `dosage`
--

DROP TABLE IF EXISTS `dosage`;
CREATE TABLE IF NOT EXISTS `dosage` (
  `dos_code` int(10) NOT NULL AUTO_INCREMENT,
  `dos_quantite` int(10) NOT NULL,
  `dos_unite` varchar(5) NOT NULL,
  PRIMARY KEY (`dos_code`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `dosage`
--

INSERT INTO `dosage` (`dos_code`, `dos_quantite`, `dos_unite`) VALUES
(1, 100, 'mg'),
(2, 200, 'mg'),
(3, 300, 'mg'),
(4, 400, 'mg'),
(5, 500, 'mg');

-- --------------------------------------------------------

--
-- Structure de la table `famille`
--

DROP TABLE IF EXISTS `famille`;
CREATE TABLE IF NOT EXISTS `famille` (
  `fam_code` int(3) NOT NULL AUTO_INCREMENT,
  `fam_libelle` varchar(80) NOT NULL,
  PRIMARY KEY (`fam_code`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `famille`
--

INSERT INTO `famille` (`fam_code`, `fam_libelle`) VALUES
(1, 'ANTIRÉTROVIRAL'),
(3, 'SOLUTION DE LAVAGE OCULAIRE'),
(4, 'ANTIINFLAMMATOIRES'),
(5, 'ANTIRHUMATISMAUX'),
(6, 'ANTIALLERGIQUE'),
(7, 'ANTIEMETIQUES'),
(8, 'ANTINAUSEEUX'),
(9, 'ANTIANGOREUX');

-- --------------------------------------------------------

--
-- Structure de la table `interagir`
--

DROP TABLE IF EXISTS `interagir`;
CREATE TABLE IF NOT EXISTS `interagir` (
  `med_perturbateur` int(10) NOT NULL,
  `med_med_perturbe` int(10) NOT NULL,
  PRIMARY KEY (`med_perturbateur`,`med_med_perturbe`),
  KEY `med_perturbateur` (`med_perturbateur`,`med_med_perturbe`),
  KEY `med_med_perturbe` (`med_med_perturbe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `medicament`
--

DROP TABLE IF EXISTS `medicament`;
CREATE TABLE IF NOT EXISTS `medicament` (
  `med_depotlegal` int(10) NOT NULL AUTO_INCREMENT,
  `med_nomcommerciale` varchar(25) NOT NULL,
  `fam_code` int(3) NOT NULL,
  `med_composition` text NOT NULL,
  `med_effets` text NOT NULL,
  `med_contreindic` varchar(255) NOT NULL,
  `med_prixechantillon` float NOT NULL,
  PRIMARY KEY (`med_depotlegal`),
  KEY `fam_code` (`fam_code`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `medicament`
--

INSERT INTO `medicament` (`med_depotlegal`, `med_nomcommerciale`, `fam_code`, `med_composition`, `med_effets`, `med_contreindic`, `med_prixechantillon`) VALUES
(3, 'ABACAVIR SANDOZ', 1, 'Abacavir-300 mg', 'Fréquents (1 à 10 % des cas) : maux de tête, perte d\'appétit, nausées, vomissements, diarrhée, éruption cutanée, fatigue, fièvre, torpeur.\r\n\r\nLa plupart de ces effets surviennent souvent chez les patients présentant une réaction allergique (voir Attention). Ils s\'aggravent avec la poursuite du traitement. L\'apparition d\'une éruption cutanée nécessite un avis médical urgent.\r\n\r\nTrès rares : pancréatite, acidose lactique (le risque est très faible, mais ne peut être exclu).\r\n\r\nUne prise de poids ainsi qu\'une augmentation des graisses et du taux de glucose dans le sang peut être observée au cours des traitements antirétroviraux.\r\n\r\nUn syndrome de restauration immunitaire est possible lorsque le système immunitaire se remet à jouer son rôle et combat les infections existantes, ce qui provoque une inflammation de la zone infectée.', 'Ce médicament ne doit pas être utilisé en cas d\'antécédent d\'allergie à l\'abacavir.', 106),
(4, 'DACRYOSERUM', 3, 'Acide borique (borax)-60 mg\r\nBorate de sodium-90 mg', 'irritation locale.', 'aucune', 40),
(5, 'PROFENID', 4, 'Kétoprofène-100mg', 'Des réactions cutanées graves, dont certaines d\'évolution fatale, incluant des dermatites exfoliatives, des syndromes de Stevens-Johnson et des syndromes de Lyell ont été très rarement rapportées lors de traitements par les AINS.\r\nDes hémorragies, ulcérations ou perforations gastro-intestinales parfois fatales, ont été rapportées avec tous les AINS, à n\'importe quel moment du traitement, sans qu\'il y ait eu nécessairement de signes d\'alerte.', 'Dangereux pour les personnes agés', 6),
(6, 'LÉVOCÉTIRIZINE MYLAN', 6, 'Lévocétirizine dichlorhydrate-5 mg\r\nLactose-...', 'somnolence, maux de tête, fatigue, bouche sèche, maux de ventre', 'Ce médicament ne doit pas être utilisé en cas d\'insuffisance rénale grave.', 2),
(7, 'KYTRIL', 7, 'Granisétron chlorhydrate-1mg\r\nTitane dioxyde-...\r\nLactose monohydrate-...', 'aucuns', 'aucune', 10),
(8, 'NICORANDIL ALMUS', 9, 'Nicorandil-10 mg', 'Maux de tête, très fréquents en début de traitement ; une augmentation progressive de la posologie peut permettre de limiter leur survenue.\r\n\r\nFréquents : nausées, vomissements, vertiges, rougeur cutanée, augmentation de la fréquence cardiaque, sensation de faiblesse.\r\n\r\nPeu fréquents : baisse de la tension artérielle.\r\n\r\nRares : douleurs musculaires, éruption cutanée, démangeaisons, hépatite, jaunisse.', 'Ce médicament ne doit pas être utilisé dans les cas suivants : hypotension grave, problème cardiaque, baisse importante du volume sanguin.', 3),
(9, 'LÉVOPHTA', 6, 'Lévocabastine-0,5 mg\r\nBenzalkonium chlorure-...\r\nPropylèneglycol-...\r\nPhosphates-...', 'Fréquents (1 à 10 % des cas) : douleur oculaire, vision floue.\r\n\r\nPeu fréquents (moins de 0,1 % des cas) : gonflement des paupières.\r\n\r\nTrès rares (moins de 0,01 % des cas) : larmoiement, rougeur, irritation ou démangeaisons oculaires, palpitations, maux de tête, urticaire, réaction allergique.', 'Ce collyre ne doit pas être utilisé en cas d\'allergie aux ammoniums quaternaires.', 5),
(10, 'MONOKÉTO', 6, 'Kétotifène-0,1 mg', 'Fréquents (1 à 10 % des utilisateurs) : irritation ou douleur oculaire, microlésions de la cornée.\r\n\r\nPeu fréquents (moins de 1 % des utilisateurs) :\r\nvision trouble à l\'instillation, sécheresse de l\'œil, irritation des paupières, sensibilité anormale à la lumière ;\r\n\r\nmaux de tête, somnolence, éruption cutanée, bouche sèche, réaction allergique.', 'aucune.', 6),
(11, 'OPATANOL', 6, 'Olopatadine chlorhydrate-100 mg\r\nBenzalkonium chlorure-...', 'Le plus couramment : gêne transitoire après l\'instillation.\r\n\r\nLes troubles suivants ont été également rapportés :\r\ntroubles oculaires : sécheresse de l\'œil, sécrétions de l\'œil, démangeaison locale, fatigue visuelle, œdème des paupières, sensation de corps étranger, kératite, sensation d\'œil qui colle, vision floue, sensibilité anormale à la lumière ;\r\n\r\nautres troubles : maux de tête, fatigue, vertiges, sécheresse nasale, bouche sèche, rhinite.', 'aucune.', 5),
(12, 'COCCULINE', 8, 'Cocculus indicus 4 CH-0,625 mg\r\nTabacum 4 CH-0,625 mg\r\nNux vomica 4 CH-0,625 mg\r\nPetroleum 4 CH-0,625 mg', 'aucun', 'aucune', 152),
(13, 'NORFLOXACINE TEVA', 4, 'Norfloxacine	400 mg', 'Brûlures d\'estomac, nausées, diarrhée, douleurs abdominales, manque d\'appétit, candidose vaginale.\r\n\r\nPhotosensibilisation (voir Attention), allergie cutanée.', 'Ce médicament ne doit pas être utilisé dans les cas suivants :\r\nallergie aux antibiotiques de la famille des quinolones,\r\n\r\nantécédent de tendinite lors de l\'utilisation d\'une quinolone,\r\n\r\nenfant jusqu\'à la fin de la croissance,\r\n\r\nallaitement.', 15),
(14, 'VERRUFILM', 6, 'Acide salicylique	16,7 g\r\nAcide lactique	        16,7 g\r\nCollodion	        ...', 'Sensation de brûlure nécessitant l\'arrêt du traitement.', 'Ce médicament ne doit pas être utilisé en cas d\'allergie aux salicylés.', 25),
(15, 'XEROQUEL LP', 8, 'Quétiapine fumarate  50 mg', 'En raison de ses effets principaux sur le système nerveux central, la quétiapine est susceptible d\'interférer dans les activités nécessitant de la vigilance. ', 'Il est déconseillé aux patients de conduire un véhicule ou d\'utiliser une machine tant que leur sensibilité individuelle à ce risque n\'est pas connue.', 22.47),
(16, 'TARGOCID', 9, 'Teicoplanine    100 mg', 'Targocid est indiqué chez les adultes et les enfants dès la naissance pour le traitement parentéral des infections suivantes (cf Posologie et Mode d\'administration, Mises en garde et Précautions d\'emploi, Pharmacodynamie) :\r\nInfections compliquées de la peau et des tissus mous.\r\n', 'La teicoplanine ne doit pas être administrée par voie intraventriculaire.', 48),
(17, 'TELMISARTAN CRISTERS', 9, 'Telmisartan	40 mg', 'Ce médicament ne doit pas être utilisé dans les cas suivants :\r\nobstruction des voies biliaires,\r\n\r\ninsuffisance hépatique grave,\r\n\r\nen association avec les médicaments contenant de l\'aliskiren (qui ne sont plus commercialisés en France) chez les patients diabétiques ou insuffisants rénaux,\r\n\r\ngrossesse (à partir du 4e mois).', 'Peu fréquents (0,1 à 1 % des utilisateurs) : infection (incluant sinusite, cystite), dépression, insomnie, malaise, éruption cutanée, vertiges, essoufflement, douleurs abdominales, diarrhées, digestion difficile, flatulences, vomissements, sueurs.', 4),
(18, 'TIBERAL', 5, 'Ornidazole      500 mg\r\n', 'Elles procèdent de l\'activité antibactérienne et antiparasitaire de l\'ornidazole et de ses caractéristiques pharmacocinétiques. Elles tiennent compte à la fois des études cliniques auxquelles a donné lieu ce médicament et de sa place dans l\'éventail des produits anti-infectieux actuellement disponibles.', 'L\'administration de l\'ornidazole pendant la grossesse et l\'allaitement est à éviter faute de données cliniques et expérimentales exploitables.', 50.26),
(19, 'TROLISE', 8, 'Pitavastatine	1 mg\r\nLactose	        ...', 'Fréquents (1 à 10 % des patients) : maux de tête, constipation, diarrhée, digestion difficile, nausées\r\n\r\nPeu fréquents (moins de 1 % des patients) : anémie, perte d\'appétit, insomnie, vertgies, troubles du goût, somnolence, étourdissements, bourdonnement d\'oreilles, douleurs abdominales, bouche sèche, vomissements, démangeaisons, éruption cutanée, douleurs musculaires ou articulaires, envie fréquente d\'uriner, fatigue, élévation des transaminases.', 'Ce médicament ne doit pas être utilisé dans les cas suivants :\r\ninsuffisance hépatique ou transaminases élevées,\r\n\r\nmyopathie,\r\n\r\nen association avec les médicaments contenant de la ciclosporine,', 43),
(20, 'TAHOR', 1, 'Atorvastatine	10 mg\r\nLactose	        ...\r\nAspartam        ...', 'Fréquents (plus de 1 % des utilisateurs) : constipation, ballonnements, digestion difficile, nausées, diarrhée, fatigue, maux de tête, saignements de nez, douleurs articulaires ou musculaires, crampes, mal de dos, gonflement des articulations, réaction allergique, hyperglycémie (voir Attention).', 'Ce médicament ne doit pas être utilisé dans les cas suivants :\r\ninsuffisance hépatique ou transaminases élevées,\r\n\r\nfemme en âge de procréer sans contraception efficace,\r\n\r\ngrossesse,\r\n\r\nallaitement.', 22),
(21, 'THIOCOLCHICOSIDE', 4, 'Thiocolchicoside      4 mg\r\nLactose               ...', 'Fréquents (1 à 10 % des patients) : douleurs d\'estomac, diarrhée, somnolence.\r\n\r\nPeu fréquents : réaction cutanée (démangeaisons, rougeur, éruption de boutons), nausées, vomissements.\r\n\r\nRares : urticaire.', 'Ce médicament ne doit pas être utilisé dans les cas suivants :\r\nallergie à la colchicine,\r\n\r\nfemme en âge de procréer sans contraception efficace,\r\n\r\ngrossesse.', 106.68),
(22, 'HYDROXYZINE ZENTIVA', 6, 'Hydroxyzine dichlorhydrate	25 mg\r\nLactose	                        70 mg', 'Constipation, nausées, vomissements, troubles de l\'accommodation, bouche sèche, rétention des urines.\r\n\r\nSomnolence, et plus rarement, convulsions, mouvements anormaux, tremblements, vertiges, insomnie.', 'Ce médicament ne doit pas être utilisé dans les cas suivants :\r\nrisque de glaucome à angle fermé ;\r\n\r\nrisque de rétention des urines (adénome de la prostate...) ;\r\n\r\nporphyrie ;', 50.26),
(23, 'HALAVEN', 1, 'Éribuline     0,88 mg', 'Halaven peut provoquer des effets indésirables tels que fatigue et sensations vertigineuses pouvant avoir une influence mineure à modérée sur l\'aptitude à conduire des véhicules ou à utiliser des machines.', 'En l\'absence d\'études de compatibilité, ce médicament ne doit pas être mélangé avec d\'autres médicaments à l\'exception de ceux mentionnés dans la rubrique Modalités de manipulation et d\'élimination.', 2.1),
(24, 'JETREA', 4, 'mannitol           0.52 mg\r\nsodium hydroxyde   0.79 mg', 'somnolence, maux de tête, fatigue, bouche sèche, maux de ventre', 'Dangereux pour les personnes agés', 25),
(25, 'JOSACINE', 4, 'Josamycine	125 mg\r\nSaccharose	0,82 g', 'Nausées, vomissements, diarrhée, douleurs d\'estomac.\r\n\r\nRéaction allergique, éruption cutanée.\r\n\r\nAugmentation des transaminases, hépatite (exceptionnelle).', 'Ce médicament ne doit pas être utilisé dans les cas suivants :\r\nallergie aux macrolides,\r\n\r\nphénylcétonurie (comprimé dispersible : présence d\'aspartam),\r\n\r\n', 85),
(26, 'FACTANE', 7, 'glycine               147 mg\r\nlysine chlorhydrate   53 mg', 'Maux de tête, très fréquents en début de traitement ; une augmentation progressive de la posologie peut permettre de limiter leur survenue.\r\n\r\nFréquents : nausées, vomissements, vertiges, rougeur cutanée, augmentation de la fréquence cardiaque, sensation de faiblesse.\r\n\r\nPeu fréquents : baisse de la tension artérielle.\r\n\r\nRares : douleurs musculaires, éruption cutanée, démangeaisons, hépatite, jaunisse.', 'En l\'absence d\'études de compatibilité, ce médicament ne doit pas être mélangé avec d\'autres produits et/ou médicaments.', 46),
(27, 'FENOFIBRATE CRISTERS', 5, 'Fénofibrate	160 mg\r\nLactose         ...\r\n\r\n', 'Fréquents (1 à 10 des cas) : douleurs abdominales, nausées, vomissements, diarrhée, flatulence, élévation des transaminases.\r\n\r\nPeu fréquents (moins de 1 % des cas) : maux de tête, crampes, faiblesse, douleurs musculaires, rougeur cutanée, démangeaisons, urticaire, baisse de la libido, calcul biliaire, pancréatite.', 'Ce médicament ne doit pas être utilisé dans les cas suivants :\r\nantécédent d\'allergie cutanée ou de photosensibilisation lors d\'une exposition au soleil pendant un traitement par un fibrate ou le kétoprofène ;', 40);

-- --------------------------------------------------------

--
-- Structure de la table `prescrire`
--

DROP TABLE IF EXISTS `prescrire`;
CREATE TABLE IF NOT EXISTS `prescrire` (
  `med_depotlegal` int(10) NOT NULL,
  `tin_code` int(5) NOT NULL,
  `dos_code` int(10) NOT NULL,
  `pre_posologie` text NOT NULL,
  KEY `tin_code` (`tin_code`,`dos_code`),
  KEY `med_depotlegal` (`med_depotlegal`),
  KEY `dos_code` (`dos_code`),
  KEY `med_depotlegal_2` (`med_depotlegal`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `prescrire`
--

INSERT INTO `prescrire` (`med_depotlegal`, `tin_code`, `dos_code`, `pre_posologie`) VALUES
(5, 2, 4, 'ok'),
(13, 3, 2, '5j'),
(24, 5, 3, '1s'),
(27, 2, 4, 'kk'),
(24, 4, 2, '5j'),
(13, 4, 2, '5j');

-- --------------------------------------------------------

--
-- Structure de la table `type_individu`
--

DROP TABLE IF EXISTS `type_individu`;
CREATE TABLE IF NOT EXISTS `type_individu` (
  `tin_code` int(5) NOT NULL AUTO_INCREMENT,
  `tin_libelle` text NOT NULL,
  PRIMARY KEY (`tin_code`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `type_individu`
--

INSERT INTO `type_individu` (`tin_code`, `tin_libelle`) VALUES
(1, 'nourrisson'),
(2, 'enfant'),
(3, 'adulte'),
(4, 'femme en seinte'),
(5, 'personne agés');

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `interagir`
--
ALTER TABLE `interagir`
  ADD CONSTRAINT `interagir_ibfk_1` FOREIGN KEY (`med_perturbateur`) REFERENCES `medicament` (`med_depotlegal`),
  ADD CONSTRAINT `interagir_ibfk_2` FOREIGN KEY (`med_med_perturbe`) REFERENCES `medicament` (`med_depotlegal`);

--
-- Contraintes pour la table `medicament`
--
ALTER TABLE `medicament`
  ADD CONSTRAINT `medicament_ibfk_1` FOREIGN KEY (`fam_code`) REFERENCES `famille` (`fam_code`);

--
-- Contraintes pour la table `prescrire`
--
ALTER TABLE `prescrire`
  ADD CONSTRAINT `prescrire_ibfk_1` FOREIGN KEY (`tin_code`) REFERENCES `type_individu` (`tin_code`),
  ADD CONSTRAINT `prescrire_ibfk_2` FOREIGN KEY (`dos_code`) REFERENCES `dosage` (`dos_code`),
  ADD CONSTRAINT `prescrire_ibfk_3` FOREIGN KEY (`med_depotlegal`) REFERENCES `medicament` (`med_depotlegal`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
