using Microsoft.Data.Sqlite;
using Dapper;

namespace Avaliacao3BimLp3.Database;

class DatabaseSetup
{
    private DatabaseConfig databaseConfig;

    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        this.databaseConfig = databaseConfig;
        CreateProductTable();
    }

    public void CreateProductTable()
    {
        var conection = new SqliteConnection(databaseConfig.ConnectionString);

        conection.Open();

        var command = conection.CreateCommand();
        command.CommandText = @";
        CREATE TABLE IF NOT EXISTS Product(
            id int not null primary key,
            name varchar(100) not null,
            price double not null, 
            active bool not null
        );
        ";
        command.ExecuteNonQuery();

        conection.Close();
    }
}