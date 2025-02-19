
namespace GStore.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<Produto> Produtos { get; set; }

    public DbSet<ProdutoFoto> ProdutoFotos { get; set; }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        #region Renomeação das tabelas do Identity
        builder.Entity<Usuario>().ToTable("usuario");
        builder.Entity<IdentityRole>().ToTable("perfil");
        builder.Entity<IdentityUserRole<string>>().ToTable("usuario_perfil")
        builder.Entity<IdentityUserToken<string>>().ToTable("usuario_token")
        builder.Entity<IdentityUserClaim<string>>().ToTable("usuario_regra")
        builder.Entity<IdentityUserLogin<string>>().ToTable("usuario_login")
        builder.Entity<IdentityRoleClaim<string>>().ToTable("perfil_regra")    
        #endregion

        #region Popular Categoria
        List<Categorias> categorias = new()
        {
            new Categoria()
            {
                Id = 1,
                Nome = "Eletrônicos"
            },
             new Categoria()
            {
                Id = 2,
                Nome = "Celulares"
            },
        };
        builder.Entity<Categorias>().HasData(categorias);
        #endregion

        #region Produto

        List<Produto> produtos = new()
        {
            new Produto()
            {
                Id = 1,
                Nome = "SSD Externo",
                Descricao = "SSD Externo blábláblá",
                CategoriaId = 1,
                Qtde = 5,
                ValorCusto = 300,
                ValorVenda = 900
            }
        };
        builder.Entity<Produto>().HasData(produtos)
        #endregion
        
        #region Usuario
        List<Usuario> usuarios = new()
        {
            new Usuario()
            {
                Id = guid.NewGuid().ToString(),
                UserName = "AlanPinheiro",
                NormalizedUserName = "ALANPINHEIRO",
                Email = "alantnt15@gmail.com",
                NormalizedEmail = "ALANTNT15@GMAIL.COM",
                EmailConfirmed = true,
                Nome = "Alan Pinheiro",
                DataNascimento = DateTime.Parse("08/08/1996"),
            }
        };
        foreach (Usuario usuario in usuarios)
        {
            PasswordHasher<Usuario> password = new();
            usuario.PasswordHash = password.HashPassword(usuario, "123456");
        }    
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Perfil
        List<IdentityRole> perfis = new()
        {
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"

            },
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Funcionário",
                NormalizedName = "FUNCIONÁRIO",

            },
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Cliente",
                NormalizedName = "CLIENTE"

            }


        };
        builder.Entity<IdentytyRole>().HasData(perfis);
        #endregion

        #region Usuario Perfil
        List<IdentityUserRole<string>> usuarioPerfis = new()
        {
            new IdentityUserRole<string>()
            {
                UserId = usuarios[0].Id,
                RoleId = perfis[0].Id
            }
            new IdentityUserRole<string>()
            {
                UserId = usuarios[0].Id,
                RoleId = perfis[1].Id
            }
            new IdentityUserRole<string>()
            {
                UserId = usuarios[0].Id,
                RoleId = perfis[2].Id
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(usuarioPerfis);
        #endregion
    
}
