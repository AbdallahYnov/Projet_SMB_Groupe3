# SuperMeatBoy

# Documentation du Projet
Reproduction du Niveau 20 – Chapitre 1 de Super Meat Boy

# 1. Présentation du Projet
Ce projet vise à reproduire à l’identique le niveau 20 du Chapitre 1 de Super Meat Boy. L’objectif est de recréer :

Le level design (disposition des plateformes, obstacles, zones mortes, etc.)
Le level art (textures, couleurs et style visuel)
Les déplacements et contrôles du personnage, semblables à ceux de Meat Boy
Les dangers (scies, piques, etc.) et leurs comportements
Le timer qui affiche le temps de jeu, à l’image du timer original (pour valider un A+ sous une certaine limite de temps)
Des animations bonus (pour le personnage ou les scies, par exemple)
(Éventuellement) Un système de replay, permettant de revoir sa partie
Ce document fournit les instructions nécessaires pour cloner, lancer et comprendre le projet. Nous détaillons également les noms des contributeurs, l’organisation du code et les principaux concepts retenus.

2. Équipe et Collaborateurs
Le travail est réalisé par un groupe de trois personnes :

- abdallah
- hugo
- Djibril
- 
Chacun a participé à la mise en place du projet, à la configuration Git, à la reproduction du level design et du level art, aux tests et aux corrections éventuelles.

3. Dépôt Git et Lien de Rendu Final
Le dépôt Git est hébergé à l’adresse suivante :
https://github.com/AbdallahYnov/SuperMeatBoy

Important : Selon les exigences du cahier des charges, seules les commits et push sur la branche main (ou master) jusqu’au 15 février à 8h00 sont pris en compte. Après cette date, plus aucune modification n’est autorisée.

4. Clonage et Ouverture du Projet
4.1 Prérequis
Unity (version 2021 LTS ou 2022 LTS recommandée)
Git (pour cloner le dépôt)
4.2 Étapes de clonage
Ouvrez un terminal (ou l’invite de commandes) dans le dossier où vous souhaitez cloner le projet.
Saisissez :
git clone https://github.com/AbdallahYnov/SuperMeatBoy

Ouvrez ensuite Unity Hub, puis sélectionnez Add project. Choisissez le dossier où vous avez cloné le dépôt.
4.3 Ouverture de la scène
Dans Unity, rendez-vous dans le dossier Assets/_Project/Scenes/.
Ouvrez la scène Level20 (ou le nom exact du fichier .unity correspondant).

5. Organisation du Projet = Théoriquement 
Pour une meilleure lisibilité, nous avons structuré les ressources et scripts comme suit :

Assets/
  _Project/
    Scenes/
      Level20/               <- Scène principale reproduisant le niveau 20
    Scripts/                 <- Scripts pour les déplacements, gestion du timer, etc.
      Player/
      Level/
      ...
    Art/
      Sprites/
      Textures/
      Materials/
    Prefabs/
      Hazards/               <- Préfabriqués des scies, pièges, etc.
      ...
    Animations/
      ...
    Fonts/
      ...
  Docs/
    README.md (ou ce fichier de documentation)

_Project/Scenes/Level20 : contient la scène Unity du niveau 20.
Scripts/ : regroupe tous les scripts C#, organisés par catégories.
Art/ : textures et sprites pour le level design et le personnage.
Prefabs/ : tous les éléments (scies, plateformes, etc.) qui sont instanciés dans la scène.
Docs/ : documentation (y compris ce présent document).
(Note : Les noms de dossiers sont indicatifs. L’important est la clarté et la cohérence.)

_Project/Scenes/Level20 : contient la scène Unity du niveau 20.
Scripts/ : regroupe tous les scripts C#, organisés par catégories.
Art/ : textures et sprites pour le level design et le personnage.
Prefabs/ : tous les éléments (scies, plateformes, etc.) qui sont instanciés dans la scène.
Docs/ : documentation (y compris ce présent document).
(Note : Les noms de dossiers sont indicatifs. L’important est la clarté et la cohérence.)

6. Description Fonctionnelle
6.1 Level Design
Parois latérales : reproduites selon la disposition du niveau 20 (taille, forme, collisions).
Plateformes multiples sur la partie droite, avec un corridor vertical.
Zone centrale avec des scies rotatives ou mobiles (comme dans l’original).
Zone de départ (à gauche) et Zone d’arrivée (en haut à droite, où se trouve Bandage Girl ou un équivalent).
6.2 Level Art
Textures et couleurs inspirées du décor industriel / caverneux de Super Meat Boy.
Sol dangereux en bas, rouge sang ou piques (mort instantanée).
Scies ou autres obstacles mortels fidèles à l’esthétique du jeu.
6.3 Contrôles et Déplacements
Déplacement horizontal rapide et réactif.
Saut avec un feeling proche de Super Meat Boy (gravité élevée, possibilité de “rebond” en wall jump).
Mort instantanée en cas de collision avec les scies ou la zone mortelle au sol.
6.4 Timer
Interface affichant le temps écoulé depuis le début du niveau.
Référence de temps pour décrocher un A+ si terminé en-dessous d’une limite (par exemple 20 secondes).
6.5 Replay et Animations (Bonus)
Replay : en fin de niveau, possibilité de rejouer l’itinéraire du joueur (ghost) ou d’afficher des tentatives ratées (selon les choix du groupe).
Animations :
Personnage : idle, run, jump, wall-slide (au besoin).
Scies : rotation continue.
(Ces aspects bonus ne sont pas forcément indispensables, mais donnent un résultat plus fidèle et plus complet.)

7. Documentation Technique
Vous trouverez dans le dossier Docs/ (ou directement dans certains scripts) plus d’explications techniques :

Configuration du Propriétés du Projet : paramétrage de l’Input Manager, Physics 2D, etc. pour reproduire la physique “Super Meat Boy”.
Utilisation des Prefabs : scies, piques, plateformes, etc.
Gestion de la Mort du Joueur : collisions triggers ou collisions directes.
Système de Camera : si besoin, camera statique ou suiveuse (selon l’étendue du niveau).
Système de Timer : script UI pour l’affichage, calcul du temps et grade A+.
Système de Replay (facultatif) : enregistrement des positions du joueur, restitution en fin de partie.
8. Conseils d’Exploitation et Tests
Tester la gravité et la vitesse : ajuster la force de saut, la vitesse de déplacement, etc., pour qu’ils soient aussi proches que possible de Super Meat Boy.
Vérifier chaque scie : emplacement, taille, vitesse de rotation, éventuel mouvement vertical ou horizontal.
S’assurer du timer : qu’il se mette bien à zéro au début et qu’il arrête au moment où le joueur atteint l’objectif.
Multiplateforme : idéalement, tester le jeu sur Windows/Mac/Linux ou dans l’éditeur Unity, pour s’assurer de l’absence de bugs liés à la plateforme.
9. Remarques Finales et Limites
Le projet se concentre sur un seul niveau (niveau 20 – Chapitre 1). Il n’a pas vocation à reproduire l’intégralité de Super Meat Boy.
Certaines mécaniques avancées du jeu original (par exemple, la “restitution” de multiples fantômes de mort à la fin) peuvent être simplifiées selon les contraintes de temps.
Nous avons respecté la consigne de limite de push et commits jusqu’au 15 février 8h00. Les modifications après cette date ne figurent pas dans le rendu officiel.
10. Informations Légales et Crédits
Droits et licence : Les assets (images, sons, etc.) utilisés sont originaux ou libres de droits. Ce projet est strictement éducatif, visant à comprendre et reproduire le level design à des fins d’apprentissage.
Contributeurs :
1-Abdallah
2-Hugo
3-Djibril
Contact
Pour toute question ou problème lors du lancement du projet, vous pouvez contacter l’un des collaborateurs via GitHub (issues, pull requests) ou par l’adresse e-mail fournie dans le profil.

Merci d’avoir consulté cette documentation. Nous espérons que la reproduction de ce niveau de Super Meat Boy vous apportera une expérience de jeu fluide et fidèle à l’original !
