using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db;

public class DbContexto : DbContext
{
    private readonly IConfiguration _configuraçãoAppSettings;
    public DbContexto(IConfiguration configuraçãoAppSettings)
    {
        _configuraçãoAppSettings = configuraçãoAppSettings;
    }
    public DbSet<Administrador> Administradores { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
                var stringConexao = _configuraçãoAppSettings.GetConnectionString("mysql")?.ToString();
                if (!string.IsNullOrEmpty(stringConexao))
                {
                    optionsBuilder.UseMySql(
                    "string de conexão",
                    ServerVersion.AutoDetect("string de conexao")
                );
            }
        }
    }
}