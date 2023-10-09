mysqldump -uroot -proot -B db_space_invaders > db_space_invaders_backup.sql

mysql -uroot -proot < C:\Users\username\..\db_space_invaders_backup.sql

mysql -uroot -proot < db_space_invaders_backup.sql