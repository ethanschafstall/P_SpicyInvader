1.  select * from t_joueur 
    order by jouNombrePoints desc 
    limit 5;

2.  select max(armPrix) as PrixMaximum, min(armPrix) as PrixMinimum, avg(armPrix) as PrixMoyen 
    from t_arme;

3.  select count(idCommande) as NombreCommandes, fkJoueur as idJoueur from t_commande 
    group by fkJoueur 
    order by NombreCommandes desc;

4.  select fkJoueur as idJoueur, count(idCommande) as NombreCommandes from t_commande 
    group by fkJoueur 
    where NombreCommandes>2;

5.  select jouPseudo, armNom from t_joueur 
    join t_commande on fkJoueur = idJoueur 
    join t_detail_commande on fkCommande = idCommande 
    join t_arme on idArme = fkArme;

6.  select idJoueur, sum(armPrix) as TotalDepense from t_joueur
    join t_arsenal on fkJoueur = idJoueur
    join t_arme on fkArme = idArme
    group by idJoueur
    order by sum(armPrix) desc
    limit 10;

7.  select idJoueur, idCommande from t_joueur 
    join t_commande on fkJoueur = idJoueur;

8.  select t_commande.*, jouPseudo from t_commande
    join t_joueur on fkJoueur = idJoueur;

9.  select idJoueur, count(fkArme) as nbTotalArmes from t_joueur
    left join t_commande on fkJoueur = idJoueur
    left join t_detail_commande on fkCommande = idCommande 
    group by  idJoueur;

10. select idJoueur from t_joueur
    join t_commande on fkJoueur = idJoueur
    join t_detail_commande on fkCommande = idCommande 
    group by idJoueur
    having count(distinct fkArme) > 3;
