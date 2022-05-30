using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MeusLivros_ProjetoMVC.Models;

namespace MeusLivros_ProjetoMVC.Data
{
    public class MeusLivros_ProjetoMVCContext : DbContext
    {
        public MeusLivros_ProjetoMVCContext (DbContextOptions<MeusLivros_ProjetoMVCContext> options)
            : base(options)
        {
        }

        public DbSet<MeusLivros_ProjetoMVC.Models.Autor> Autor { get; set; }

        public DbSet<MeusLivros_ProjetoMVC.Models.Editora> Editora { get; set; }

        public DbSet<MeusLivros_ProjetoMVC.Models.Status> Status { get; set; }

        public DbSet<MeusLivros_ProjetoMVC.Models.Livro> Livro { get; set; }
    }
}
