using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Todos os dados referentes ao registro de ponto do funcionário
namespace folha_de_ponto.Models
{
    public class FolhaPonto
    {
        public int Id { get; set; }
        public string IdFuncionario { get; set; }
        public DateTime Data { get; set; }
    }
}