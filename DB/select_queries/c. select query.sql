1.  SELECT * FROM t_joueur 
    ORDER BY jouNombrePoints DESC 
    LIMIT 5;

2.  SELECT MAX(armPrix) AS PrixMaximum, MIN(armPrix) AS PrixMinimum, AVG(armPrix) AS PrixMoyen 
    FROM t_arme;

3.  SELECT COUNT(idCommande) AS NombreCommandes, fkJoueur AS idJoueur FROM t_commande 
    GROUP BY fkJoueur 
    ORDER BY NombreCommandes DESC;

4.  SELECT fkJoueur AS idJoueur, 
    COUNT(idCommande) AS NombreCommandes 
    FROM t_commande 
    GROUP BY fkJoueur
    HAVING NombreCommandes > 1;

5.  SELECT jouPseudo, armNom 
    FROM t_joueur 
    JOIN t_commande ON fkJoueur = idJoueur 
    JOIN t_detail_commande ON fkCommande = idCommande 
    JOIN t_arme ON idArme = fkArme;

6.  SELECT idJoueur, SUM(armPrix*detQuantiteCommande) AS TotalDepense FROM t_joueur
    JOIN t_commande ON fkJoueur = idJoueur
    JOIN t_detail_commande ON fkCommande = idCommande
    JOIN t_arme ON fkArme = idArme
    GROUP BY idJoueur
    ORDER BY SUM(armPrix*detQuantiteCommande) DESC
    LIMIT 10;

7.  SELECT idJoueur, idCommande 
    FROM t_joueur 
    LEFT JOIN t_commande ON fkJoueur = idJoueur;

8.  SELECT t_commande.*, jouPseudo FROM t_commande
    JOIN t_joueur ON fkJoueur = idJoueur;


9.  SELECT idJoueur, SUM(detQuantiteCommande) AS nbTotalArmes FROM t_joueur
    LEFT JOIN t_commande ON fkJoueur = idJoueur
    LEFT JOIN t_detail_commande ON fkCommande = idCommande 
    GROUP BY  idJoueur;

10. SELECT idJoueur FROM t_joueur
    JOIN t_commande ON fkJoueur = idJoueur
    JOIN t_detail_commande ON fkCommande = idCommande 
    GROUP BY idJoueur
    HAVING COUNT(DISTINCT fkArme) > 3;
