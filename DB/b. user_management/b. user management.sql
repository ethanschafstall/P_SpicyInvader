CREATE ROLE IF NOT EXISTS r_admin;
CREATE ROLE IF NOT EXISTS r_player;
CREATE ROLE IF NOT EXISTS r_shopkeeper;

GRANT ALL PRIVILEGES ON *.* TO r_admin WITH GRANT OPTION;

GRANT SELECT ON db_space_invaders.t_arme TO r_player;
GRANT INSERT, SELECT ON db_space_invaders.t_commande TO r_player;

GRANT SELECT ON db_space_invaders.t_joueur TO r_shopkeeper;
GRANT ALTER, SELECT, DELETE ON db_space_invaders.t_arme TO r_shopkeeper;
GRANT SELECT ON db_space_invaders.t_commande TO r_shopkeeper;

CREATE USER 'admin1'@'localhost' IDENTIFIED BY 'password';
CREATE USER 'player1'@'localhost' IDENTIFIED BY 'password';
CREATE USER 'shopkeeper1'@'localhost' IDENTIFIED BY 'password';

GRANT ROLE r_admin TO 'admin1'@'localhost';
GRANT ROLE r_player TO 'player1'@'localhost';
GRANT ROLE r_shopkeeper TO 'shopkeeper1'@'localhost';