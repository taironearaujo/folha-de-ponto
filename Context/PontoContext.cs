using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using folha_de_ponto.Models;
using Microsoft.EntityFrameworkCore;

namespace folha_de_ponto.Context
{
    public class PontoContext : DbContext
    {
        public PontoContext(DbContextOptions<PontoContext> options) : base(options)
        {

        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FolhaPonto> FolhasPontos { get; set; }
    }
}