using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Projet_Hugo
{
    class MainClass
    {
        /// <summary>
        /// Fonction permettant de continuer le programme jusqu'à ce que l'utilisateur souhaite arrêter
        /// </summary>
        /// <returns>The continuer.</returns>
        public static int Continuer()
        {
            int c = -1;
            while (c < 0 || c > 1)
            {
                Console.WriteLine("\nVoulez vous continuer ?\n1) Oui\n2) Non");
                c = Convert.ToInt32(Console.ReadLine());
                if (c == 1)
                    return 2;
                else
                    return 1;
            }
            return 1;
        }

        public static void Main(string[] args)
        {

            // Variable permettant à l'utilisateur de choisir s'il veut afficher l'état intermédiaire ou pas 
            bool afficherEtatIntermediaire = false;

            // Variable permettant de continuer ou quitter le jeu
            int quitter = 2;

            do
            {
                /// Affichage du menu 
                Console.Clear();
                Console.WriteLine("\t\t\tBienvenue au Jeu de la vie \n\n\tQue souhaites-tu faire ?\n");
                Console.WriteLine("\t1) Etape 1");
                Console.WriteLine("\t2) Etape 2");
                Console.WriteLine("\t3) Etape 3");
                Console.WriteLine("\t4) Quitter");

                try
                {
                    int choix = Convert.ToInt32(Console.ReadLine());
                    while (choix < 1 || choix > 4)
                    {
                        Console.WriteLine("Veuillez saisir un choix valide SVP");
                        choix = Convert.ToInt32(Console.ReadLine());
                    }


                    ///Gérer le menu 
                    switch (choix)
                    {
                        case 1:
                            Console.WriteLine("Souhaites-tu afficher les étapes intermédiaires ?");
                            Console.WriteLine("1) Oui ");
                            Console.WriteLine("2) Non ");
                            int c = Convert.ToInt32(Console.ReadLine());
                            while (c < 1 || c > 2)
                            {
                                Console.WriteLine("Veuillez saisir un choix valide SVP");
                                choix = Convert.ToInt32(Console.ReadLine());
                            }
                            if (c == 1)
                                afficherEtatIntermediaire = true;
                            else
                                afficherEtatIntermediaire = false;

                            lancementEtape1(afficherEtatIntermediaire);


                            break;
                        case 2:
                            Console.WriteLine("Souhaites-tu afficher les étapes intermédiaires ?");
                            Console.WriteLine("1) Oui ");
                            Console.WriteLine("2) Non ");
                            c = Convert.ToInt32(Console.ReadLine());
                            while (c < 1 || c > 2)
                            {
                                Console.WriteLine("Veuillez saisir un choix valide SVP");
                                choix = Convert.ToInt32(Console.ReadLine());
                            }
                            if (c == 1)
                                afficherEtatIntermediaire = true;
                            else
                                afficherEtatIntermediaire = false;

                            lancementEtape2(afficherEtatIntermediaire);

                            break;
                        case 3:
                            Console.WriteLine("En préparation...");
                            System.Threading.Thread.Sleep(1000); // Pour faire une pause de 0.8 seconde

                            break;
                        case 4:
                            quitter = 1;
                            break;
                        default:

                            break;
                    }
                }
                // Dans le cas d'une erreur, permettre la compilation du programme et afficher l'erreur sur la console 
                // Par exemple si l'utilisateur saisi un caractèe au lieu d'un chiffre
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message); // Affichage de l'erreur
                }
            } while (quitter == 2);
            Console.Clear();
            if (quitter == 1)
            {
                Console.WriteLine("Merci de votre visite !");
                System.Threading.Thread.Sleep(800); // Pour faire une pause de 0.8 seconde
                Console.Clear();
            }
        }

        /// <summary>
        /// On remplit la grille de départ en fonction du paramètre : tauxRemplissage
        /// </summary>
        /// <param name="tauxRemplissage"></param>
        /// <param name="tailleX"></param>
        /// <param name="tailleY"></param>
        /// <param name="Cellules"></param>
        /// <param name="morte"></param>
        /// <param name="vivante"></param>
        public static void RemplirMonde(float tauxRemplissage, int tailleX, int tailleY, int[,] Cellules, int morte, int vivante)
        {
            int nbCellulesVivantesCible = (int)Math.Round(tailleX * tailleY * tauxRemplissage);
            int nbCellulesVivantesCreees = 0;
            Random random = new Random();

            while (nbCellulesVivantesCreees != nbCellulesVivantesCible)
            {
                int essaiX = random.Next(0, tailleX);
                int essaiY = random.Next(0, tailleY);
                if (Cellules[essaiX, essaiY] == morte)
                {
                    Cellules[essaiX, essaiY] = vivante;
                    nbCellulesVivantesCreees++;
                }
            }
        }

        /// <summary>
        /// On remplit la grille de départ en fonction du paramètre : tauxRemplissage et en 2 populations distinctes
        /// La proportion est la suivante : 0.5 population1 et 0.5 population2
        /// </summary>
        /// <param name="tauxRemplissage"></param>
        /// <param name="tailleX"></param>
        /// <param name="tailleY"></param>
        /// <param name="Cellules"></param>
        /// <param name="morte"></param>
        /// <param name="vivante1"></param>
        /// <param name="vivante2"></param>
        public static void RemplirMonde2(float tauxRemplissage, int tailleX, int tailleY, int[,] Cellules, int morte, int vivante1, int vivante2)
        {
            int nbCellulesVivantesCible = (int)Math.Round(tailleX * tailleY * tauxRemplissage);
            int nbCellulesVivantesCreees = 0;
            Random random = new Random();

            while (nbCellulesVivantesCreees != (nbCellulesVivantesCible / 2))
            {
                int essaiX = random.Next(0, tailleX); 
                int essaiY = random.Next(0, tailleY);
                if (Cellules[essaiX, essaiY] == morte)
                {
                    Cellules[essaiX, essaiY] = vivante1;
                    nbCellulesVivantesCreees++;
                }
            }

            while (nbCellulesVivantesCreees != nbCellulesVivantesCible)
            {
                int essaiX = random.Next(0, tailleX);
                int essaiY = random.Next(0, tailleY);
                if (Cellules[essaiX, essaiY] == morte)
                {
                    Cellules[essaiX, essaiY] = vivante2;
                    nbCellulesVivantesCreees++;
                }
            }
        }

        /// <summary>
        /// Récupère les cellules voisines au rang n de la cellule de coordonnées (x,y)
        /// </summary>
        /// <param name="Cellules"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="tailleX"></param>
        /// <param name="tailleY"></param>
        /// <param name="rang"></param>
        /// <returns> Retourne un tableau contenant les cellules voisines de la cellule de coordonnées (x,y) </returns>
        public static int[] RecupererLesVoisins(int[,] Cellules, int x, int y, int tailleX, int tailleY, int n)
        {
            int[] voisins = new int[1000];
            int i = 0;

            for (int translationX = -n; translationX <= n; translationX++)
            {
                for (int translationY = -n; translationY <= n; translationY++)
                {
                    if (translationX == 0 && translationY == 0)
                        // On est sur la cellule dont on cherche les voisins, on la saute...
                        continue;

                    int xVoisin = CorrigerCoordonnee(x + translationX, tailleX);
                    int yVoisin = CorrigerCoordonnee(y + translationY, tailleY);
                    voisins[i] = (Cellules[xVoisin, yVoisin]);
                    i++;
                }
            }

            return voisins;
        }

        public static bool EstVivante(int cellule, int vivante, int enTrainDeMourir)
        {
            return cellule == vivante || cellule == enTrainDeMourir;
        }

        /// <summary>
        /// On applique les règles d'évolution d'une seule population du jeu de la vie : R1, R2, R3 et R4
        /// </summary>
        /// <param name="Cellules"></param>
        /// <param name="tailleX"></param>
        /// <param name="tailleY"></param>
        /// <param name="vivante"></param>
        /// <param name="enTrainDeMourir"></param>
        /// <param name="enTrainDeNaitre"></param>
        /// <returns> true si un changement a été fait, false si aucun changement n'a été fait </returns>
        public static bool CalculerEvolution(int[,] Cellules, int tailleX, int tailleY, int vivante, int enTrainDeMourir, int enTrainDeNaitre)
        {
            bool changementMonde = false;
            for (int x = 0; x < tailleX; x++)
            {
                for (int y = 0; y < tailleY; y++)
                {
                    int[] voisins = RecupererLesVoisins(Cellules, x, y, tailleX, tailleY, 1);
                    int nbCellulesVivantes = CompterCellulesVivantes(voisins, vivante, enTrainDeMourir);

                    if (EstVivante(Cellules[x, y], vivante, enTrainDeMourir))
                    {
                        // R1 || R2
                        if (nbCellulesVivantes < 2 || nbCellulesVivantes > 3)
                        {
                            Cellules[x, y] = enTrainDeMourir;
                            changementMonde = true;
                        }
                    }
                    // R3
                    else if (nbCellulesVivantes == 3)
                    {
                        Cellules[x, y] = enTrainDeNaitre;
                        changementMonde = true;
                    }
                }
            }

            return changementMonde;
        }

        /// <summary>
        /// On applique les règles d'évolution des 2 populations du jeu de la vie : R1b, R2b, R3b et R4b
        /// </summary>
        /// <param name="Cellules"></param>
        /// <param name="tailleX"></param>
        /// <param name="tailleY"></param>
        /// <param name="vivante1"></param>
        /// <param name="enTrainDeMourir1"></param>
        /// <param name="enTrainDeNaitre1"></param>
        /// <param name="vivante2"></param>
        /// <param name="enTrainDeMourir2"></param>
        /// <param name="enTrainDeNaitre2"></param>
        /// <returns> true si un changement a été fait, false si aucun changement n'a été fait </returns>
        public static bool CalculerEvolution2(int[,] Cellules, int tailleX, int tailleY, int vivante1, int enTrainDeMourir1, int enTrainDeNaitre1, int vivante2, int enTrainDeMourir2, int enTrainDeNaitre2)
        {
            bool changementMonde = false;
            for (int x = 0; x < tailleX; x++)
            {
                for (int y = 0; y < tailleY; y++)
                {
                    int[] voisinsRang1 = RecupererLesVoisins(Cellules, x, y, tailleX, tailleY, 1);
                    int[] voisinsRang2 = RecupererLesVoisins(Cellules, x, y, tailleX, tailleY, 2);

                    int nbCellulesVivantes1Rang1 = CompterCellulesVivantes(voisinsRang1, vivante1, enTrainDeMourir1);
                    int nbCellulesVivantes2Rang1 = CompterCellulesVivantes(voisinsRang1, vivante2, enTrainDeMourir2);
                    int nbCellulesVivantes1Rang2 = CompterCellulesVivantes(voisinsRang2, vivante1, enTrainDeMourir1);
                    int nbCellulesVivantes2Rang2 = CompterCellulesVivantes(voisinsRang2, vivante2, enTrainDeMourir2);


                    if (EstVivante(Cellules[x, y], vivante1, enTrainDeMourir1))
                    {
                        // R1b || R2b
                        if (nbCellulesVivantes1Rang1 < 2 || nbCellulesVivantes1Rang1 > 3)
                        {
                            Cellules[x, y] = enTrainDeMourir1;
                            changementMonde = true;
                        }
                    }

                    else if (EstVivante(Cellules[x, y], vivante2, enTrainDeMourir2))
                    {
                        // R1b || R2b
                        if (nbCellulesVivantes2Rang1 < 2 || nbCellulesVivantes2Rang1 > 3)
                        {
                            Cellules[x, y] = enTrainDeMourir2;
                            changementMonde = true;
                        }
                    }

                    // R3b
                    else if (nbCellulesVivantes1Rang1 == 3 && nbCellulesVivantes2Rang1 != 3)
                    {
                        Cellules[x, y] = enTrainDeNaitre1;
                        changementMonde = true;
                    }

                    else if (nbCellulesVivantes2Rang1 == 3 && nbCellulesVivantes1Rang1 != 3)
                    {
                        Cellules[x, y] = enTrainDeNaitre2;
                        changementMonde = true;
                    }

                    // R4b
                    else if (nbCellulesVivantes1Rang1 == 3 && nbCellulesVivantes2Rang1 == 3)
                    {
                        if(nbCellulesVivantes1Rang2 > nbCellulesVivantes2Rang2)
                        {
                            Cellules[x, y] = enTrainDeNaitre2;
                            changementMonde = true;
                        }
                        else if(nbCellulesVivantes1Rang2 < nbCellulesVivantes2Rang2)
                        {
                            Cellules[x, y] = enTrainDeNaitre2;
                            changementMonde = true;
                        }
                        else if (nbCellulesVivantes1Rang2 == nbCellulesVivantes2Rang2)
                        {
                            if (CompterCellules(Cellules, vivante1, enTrainDeMourir1) < CompterCellules(Cellules, vivante2, enTrainDeMourir2))
                            {
                                Cellules[x, y] = enTrainDeNaitre2;
                                changementMonde = true;
                            }
                            else if (CompterCellules(Cellules, vivante1, enTrainDeMourir1) > CompterCellules(Cellules, vivante2, enTrainDeMourir2))
                            {
                                Cellules[x, y] = enTrainDeNaitre1;
                                changementMonde = true;
                            }
                        }
                    }
                }
            }

            return changementMonde;
        }

        /// <summary>
        /// Compte les cellules voisines vivantes 
        /// </summary>
        /// <param name="cellules"></param>
        /// <param name="vivante"></param>
        /// <param name="enTrainDeMourir"></param>
        /// <returns>le nombre de cellule vivante du tableau cellules mis en paramètre </returns>
        public static int CompterCellulesVivantes(int[] cellules, int vivante, int enTrainDeMourir)
        {
            int nbCellulesVivantes = 0;
            for (int i = 0; i < cellules.Length; i++)
            {
                if (EstVivante(cellules[i], vivante, enTrainDeMourir))
                    nbCellulesVivantes++;
            }

            return nbCellulesVivantes;
        }

        /// <summary>
        /// Compte les cellules vivantes de la grille 
        /// </summary>
        /// <param name="Cellules"></param>
        /// <param name="vivante"></param>
        /// <param name="enTrainDeMourir"></param>
        /// <returns>le nombre de cellule vivante en tout</returns>
        public static int CompterCellules(int[,] Cellules, int vivante, int enTrainDeMourir)
        {
            int nbCellulesVivantes = 0;
            for (int x = 0; x < Cellules.GetLength(0); x++)
                for (int y = 0; y < Cellules.GetLength(1); y++)
                    if (EstVivante(Cellules[x, y], vivante, enTrainDeMourir))
                        nbCellulesVivantes++;

            return nbCellulesVivantes;
        }

        /// <summary>
        /// Les cellules en train de naître deviennent vivantes et les cellules en train de mourir deviennent mortes 
        /// </summary>
        /// <param name="Cellules"></param>
        /// <param name="tailleX"></param>
        /// <param name="tailleY"></param>
        /// <param name="vivante"></param>
        /// <param name="morte"></param>
        /// <param name="enTrainDeMourir"></param>
        /// <param name="enTrainDeNaitre"></param>
        public static void AppliquerEvolution(int[,] Cellules, int tailleX, int tailleY, int vivante, int morte, int enTrainDeMourir, int enTrainDeNaitre)
        {
            for (int x = 0; x < tailleX; x++)
            {
                for (int y = 0; y < tailleY; y++)
                {
                    if (Cellules[x, y] == enTrainDeNaitre)
                        Cellules[x, y] = vivante;
                    else if (Cellules[x, y] == enTrainDeMourir)
                        Cellules[x, y] = morte;
                }
            }
        }

        /// <summary>
        /// Fonction permettant de corriger les coordonnées : la case à gauche de celle la plus à gauche est la case la plus à droite et vice versa
        /// </summary>
        /// <param name="index"></param>
        /// <param name="maximum"></param>
        /// <returns>La  coordonnée corrigée </returns>
        public static int CorrigerCoordonnee(int index, int maximum)
        {
            int retour = index;

            if (index < 0)
                retour = maximum - 1;

            if (index >= maximum)
                retour = 0;

            return retour;
        }

        /// <summary>
        /// Affichage de la grille du jeu de la vie pour une seule population 
        /// </summary>
        /// <param name="Cellules"></param>
        /// <param name="tailleX"></param>
        /// <param name="tailleY"></param>
        /// <param name="vivante"></param>
        /// <param name="morte"></param>
        /// <param name="enTrainDeMourir"></param>
        /// <param name="enTrainDeNaitre"></param>
        /// <param name="generation"></param>
        public static void Afficher(int[,] Cellules, int tailleX, int tailleY, int vivante, int morte, int enTrainDeMourir, int enTrainDeNaitre, int generation)
        {
            Console.Write(">> Affichage du monde étape #");
            Console.WriteLine(generation);

            for (int y = 0; y < tailleY; y++)
            {
                for (int x = 0; x < tailleX; x++)
                {
                    int etatCellule = Cellules[x, y];
                    if (etatCellule == morte)
                        Console.Write('.');
                    else if (etatCellule == vivante)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('#');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (etatCellule == enTrainDeNaitre)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('-');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (etatCellule == enTrainDeMourir)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('*');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Affichage de la grille du jeu de la vie pour 2 populations distinctes, des couleurs différencient les populations 
        /// </summary>
        /// <param name="Cellules"></param>
        /// <param name="tailleX"></param>
        /// <param name="tailleY"></param>
        /// <param name="vivante1"></param>
        /// <param name="morte"></param>
        /// <param name="enTrainDeMourir1"></param>
        /// <param name="enTrainDeNaitre1"></param>
        /// <param name="vivante2"></param>
        /// <param name="enTrainDeMourir2"></param>
        /// <param name="enTrainDeNaitre2"></param>
        /// <param name="generation"></param>
        public static void Afficher2(int[,] Cellules, int tailleX, int tailleY, int vivante1, int morte, int enTrainDeMourir1, int enTrainDeNaitre1, int vivante2, int enTrainDeMourir2, int enTrainDeNaitre2, int generation)
        {
            Console.Write(">> Affichage du monde étape #");
            Console.WriteLine(generation);
            Console.WriteLine("Il y a " + CompterCellules(Cellules, vivante1, enTrainDeMourir1) + " cellules de la population1 et " + CompterCellules(Cellules, vivante2, enTrainDeMourir2) + " cellules de la population2");

            for (int y = 0; y < tailleY; y++)
            {
                for (int x = 0; x < tailleX; x++)
                {
                    int etatCellule = Cellules[x, y];
                    if (etatCellule == morte)
                        Console.Write('.');
                    else if (etatCellule == vivante1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write('#');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (etatCellule == enTrainDeNaitre1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write('-');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (etatCellule == enTrainDeMourir1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write('*');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (etatCellule == vivante2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('#');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (etatCellule == enTrainDeNaitre2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('-');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (etatCellule == enTrainDeMourir2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('*');
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Jeu de la vie dans le cadre d'une seule population 
        /// </summary>
        /// <param name="afficherEtatIntermediaire"></param>
        public static void lancementEtape1(bool afficherEtatIntermediaire)
        {
            // Config
            int tempsDattenteAffichage = 1000;
            float tauxRemplissage = 0.5f;
            bool doitAppuyerSurEntreePourAvancer = true;

            // Grille du jeu
            int[,] Cellules;
            int generation = 0;

            // Etat des cellules
            int morte = 0;
            int vivante = 1;
            int enTrainDeNaitre = 2;
            int enTrainDeMourir = 3;

            // Saisir les coordonnées par l'utilisateur
            Console.Write("Coordonnées X : ");
            int tailleX = int.Parse(Console.ReadLine());
            Console.Write("Coordonnées Y : ");
            int tailleY = int.Parse(Console.ReadLine());
            Cellules = new int[tailleX, tailleY];

            // Remplir la grille
            RemplirMonde(tauxRemplissage, tailleX, tailleY, Cellules, morte, vivante);
            Afficher(Cellules, tailleX, tailleY, vivante, morte, enTrainDeMourir, enTrainDeNaitre, generation);
            while (true)
            {
                if (doitAppuyerSurEntreePourAvancer)
                {
                    Console.WriteLine("Appuyez sur entrée.");
                    Console.ReadLine();
                }
                else
                    Thread.Sleep(tempsDattenteAffichage);

                generation++;
                bool changement = CalculerEvolution(Cellules, tailleX, tailleY, vivante, enTrainDeMourir, enTrainDeNaitre);

                if (!changement)
                {
                    Console.WriteLine("Le monde ne change plus, sortie.");
                    break;
                }

                if (afficherEtatIntermediaire)
                    Afficher(Cellules, tailleX, tailleY, vivante, morte, enTrainDeMourir, enTrainDeNaitre, generation);

                AppliquerEvolution(Cellules, tailleX, tailleY, vivante, morte, enTrainDeMourir, enTrainDeNaitre);
                Afficher(Cellules, tailleX, tailleY, vivante, morte, enTrainDeMourir, enTrainDeNaitre, generation);
            }
        }


        /// <summary>
        /// Jeu de la vie dans le cadre de 2 populations distinctes 
        /// </summary>
        /// <param name="afficherEtatIntermediaire"></param>
        public static void lancementEtape2(bool afficherEtatIntermediaire)
        {
            // Config
            int tempsDattenteAffichage = 1000;
            float tauxRemplissage = 0.5f;
            bool doitAppuyerSurEntreePourAvancer = true;

            // Grille du jeu
            int[,] Cellules;
            int generation = 0;

            // Etats des cellules
            int morte = 0;

            // Etat des cellules population 1
            int vivante1 = 2;
            int enTrainDeNaitre1 = 3;
            int enTrainDeMourir1 = 4;

            // Etat des cellules population 2
            int vivante2 = -2;
            int enTrainDeNaitre2 = -3;
            int enTrainDeMourir2 = -4;


            // Saisir les coordonnées par l'utilisateur
            Console.Write("Coordonnées X : ");
            int tailleX = int.Parse(Console.ReadLine());
            Console.Write("Coordonnées Y : ");
            int tailleY = int.Parse(Console.ReadLine());
            Cellules = new int[tailleX, tailleY];

            // Remplir la grille
            RemplirMonde2(tauxRemplissage, tailleX, tailleY, Cellules, morte, vivante1, vivante2);
            Afficher2(Cellules, tailleX, tailleY, vivante1, morte, enTrainDeMourir1, enTrainDeNaitre1, vivante2, enTrainDeMourir2, enTrainDeNaitre2, generation);
            while (true)
            {
                if (doitAppuyerSurEntreePourAvancer)
                {
                    Console.WriteLine("Appuyez sur entrée.");
                    Console.ReadLine();
                }
                else
                    Thread.Sleep(tempsDattenteAffichage);

                generation++;
                bool changement = CalculerEvolution2(Cellules, tailleX, tailleY, vivante1, enTrainDeMourir1, enTrainDeNaitre1, vivante2, enTrainDeMourir2, enTrainDeNaitre2);

                if (!changement)
                {
                    Console.WriteLine("Le monde ne change plus, sortie.");
                    break;
                }

                if (afficherEtatIntermediaire)
                    Afficher2(Cellules, tailleX, tailleY, vivante1, morte, enTrainDeMourir1, enTrainDeNaitre1, vivante2, enTrainDeMourir2, enTrainDeNaitre2, generation);

                AppliquerEvolution(Cellules, tailleX, tailleY, vivante1, morte, enTrainDeMourir1, enTrainDeNaitre1);
                AppliquerEvolution(Cellules, tailleX, tailleY, vivante2, morte, enTrainDeMourir2, enTrainDeNaitre2);
                Afficher2(Cellules, tailleX, tailleY, vivante1, morte, enTrainDeMourir1, enTrainDeNaitre1, vivante2, enTrainDeMourir2, enTrainDeNaitre2, generation);
            }

        }
    }

}
