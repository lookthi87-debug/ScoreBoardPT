cd "C:\Program Files\PostgreSQL\14\bin"

export:
    pg_dump -U postgres -h localhost -p 5432 -d DB_Scoreboard > D:\BongDa\DataBase\DB_Scoreboard.sql
import: t?n user login v?o ?ang l?  postgres
        t?n DB l?                   mydb_restore
        c? the thay doi ten tren tuy theo y minh
    psql -U postgres -d DB_Scoreboard -f "D:\BongDa\202510_11\GitHub_Source\DB\DB_Scoreboard.sql"