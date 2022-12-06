using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using folha_de_ponto.Context;
using folha_de_ponto.Models;
using Microsoft.AspNetCore.Mvc;

namespace folha_de_ponto.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly PontoContext _context;

        public FuncionarioController(PontoContext context)
        {
            _context = context;
        }
        // Tela inicial para apresentar os funcionários cadastrados e opções para cadastro, edição,
        // detalhes e exclusão
        public IActionResult Index()
        {
            var funcionarios = _context.Funcionarios.ToList();
            return View(funcionarios);
        }
        // Tela de cadastro do novo funcionário
        public IActionResult Cadastrar()
        {
            return View();
        }
        // Função de inclusão do cadastro do novo funcionário fazendo a chamada da model Funcionário
        [HttpPost]
        public IActionResult Cadastrar(Funcionario funcionario)
        {
            if(ModelState.IsValid)
            {
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }
        // Tela para a edição do cadastro já realizado do funcionário caso haja alguma mudança de dados do mesmo
        public IActionResult Editar(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);

            if(funcionario==null)
                return RedirectToAction(nameof(Index));

            return View(funcionario);
        }
        // Função de edição do cadastro do funcionário
        [HttpPost]
        public IActionResult Editar(Funcionario funcionario)
        {
            var funcionarioBanco = _context.Funcionarios.Find(funcionario.Id);
            funcionarioBanco.Nome = funcionario.Nome;
            funcionarioBanco.Telefone = funcionario.Telefone;
            funcionarioBanco.Ativo = funcionario.Ativo;

            _context.Funcionarios.Update(funcionarioBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        // Tela de detalhes do funcionário cadastrado através do ID
        public IActionResult Detalhes(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);

            if(funcionario==null)
                return RedirectToAction(nameof(Index));
            
            return View(funcionario);
        }
        // Tela de exclusão do cadastro do funcionário através do ID
        public IActionResult Deletar(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);

            if(funcionario==null)
                return RedirectToAction(nameof(Index));
            
            return View(funcionario);
        }
        //  Função que realiza a exclusão do cadastro do funcionário
        [HttpPost]
        public IActionResult Deletar(Funcionario funcionario)
        {
            var funcionarioBanco = _context.Funcionarios.Find(funcionario.Id);

            _context.Funcionarios.Remove(funcionarioBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        // Tela de registro de ponto, onde são listados todos os funcionários cadastrados
        public IActionResult Ponto(int id)
        {
            var funcionarios = _context.Funcionarios.ToList();
            return View(funcionarios);
        }
        // Tela de registro de ponto, onde deve ser inserido o ID do funcionário
        public IActionResult Registrar()
        {
            return View();
        }
        // Função que realiza o registro do ponto e insere na tabela FolhasPontos
        [HttpPost]
        public IActionResult Registrar(FolhaPonto folhaPonto)
        {
            if(ModelState.IsValid)
            {
                folhaPonto.Data = DateTime.Now;
                _context.FolhasPontos.Add(folhaPonto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Ponto));
            }
            return View(folhaPonto);
        }
        // Tela onde é feita a consulta de todos os pontos registrados
        public IActionResult Consultar(int idFuncionario)
        {
            var folhaPonto = _context.FolhasPontos.ToList();
            return View(folhaPonto);
        }
    }
}