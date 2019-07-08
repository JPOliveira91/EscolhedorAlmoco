using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using DAOEscolhedorAlmoco.Infraestrutura;
using DAOEscolhedorAlmoco.Modelos;
using DAOEscolhedorAlmoco.Repositorios;
using EscolhedorAlmoco.Models;
using System.Collections.Generic;

namespace EscolhedorAlmoco.Controllers
{
    public class RestauranteController : Controller
    {
        public static List<SelectListItem> _listaCustoDisponiveis;
        public static List<SelectListItem> _listaTipoDisponiveis;
        public static List<SelectListItem> _listaVetoDisponiveis;

        static Random rnd = new Random();

        public RestauranteController()
        {
            _listaCustoDisponiveis = _listaCustoDisponiveis ?? ObterListaCustos();
            _listaTipoDisponiveis = _listaTipoDisponiveis ?? ObterListaTipos();
            _listaVetoDisponiveis = _listaVetoDisponiveis ?? ObterListaVetos();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new RestauranteFiltro();
            model.CustosDisponiveis = _listaCustoDisponiveis;
            model.TiposDisponiveis = _listaTipoDisponiveis;
            model.VetosDisponiveis = _listaVetoDisponiveis;

            model.Restaurantes = ObterRestaurantes();

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Index(RestauranteFiltro model)
        {
            model.CustosDisponiveis = _listaCustoDisponiveis;
            model.TiposDisponiveis = _listaTipoDisponiveis;
            model.VetosDisponiveis = _listaVetoDisponiveis;

            model.Restaurantes = ObterRestaurantes(model);

            return View("Index", model);
        }

        [HttpGet]
        public ActionResult Aleatorio()
        {
            var model = new RestauranteFiltro();
            model.CustosDisponiveis = _listaCustoDisponiveis;
            model.TiposDisponiveis = _listaTipoDisponiveis;
            model.VetosDisponiveis = _listaVetoDisponiveis;

            model.Restaurantes = ObterRestauranteAleatorio();

            return View("Aleatorio", model);
        }

        [HttpPost]
        public ActionResult Aleatorio(RestauranteFiltro model)
        {
            model.CustosDisponiveis = _listaCustoDisponiveis;
            model.TiposDisponiveis = _listaTipoDisponiveis;
            model.VetosDisponiveis = _listaVetoDisponiveis;

            model.Restaurantes = ObterRestauranteAleatorio(model);

            return View("Aleatorio", model);
        }

        [HttpGet]
        public ActionResult Incluir()
        {
            var model = new RestauranteFiltro();
            model.CustosDisponiveis = _listaCustoDisponiveis;
            model.TiposDisponiveis = _listaTipoDisponiveis;
            model.VetosDisponiveis = _listaVetoDisponiveis;

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Incluir(RestauranteFiltro model)
        {
            var restaurante = new Restaurante()
            {
                IdRestaurante = model.Id,
                Nome = model.Nome,
                Apelido = model.Apelido,
                Endereco = model.Endereco,
                Observacao = model.Observacao,
                Custos = ObterCustos().Where(custo => model.CustosSelecionados.Contains(custo.IdCusto)).ToList(),
                Tipos = ObterTipos().Where(tipo => model.TiposSelecionados.Contains(tipo.IdTipo)).ToList(),
                Vetos = ObterVetos().Where(veto => model.VetosSelecionados.Contains(veto.IdVeto)).ToList()
            };

            if (ModelState.IsValid)
            {
                var restauranteRepository = new NHibernateRestauranteRepository();
                restauranteRepository.SaveOrUpdate(restaurante);

                TempData["sucessMessage"] = string.Format("Restaurante {0} inserido com sucesso.", restaurante.Apelido);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Incluir", "Restaurante");
        }

        [HttpGet]
        public ActionResult Editar(int idRestaurante)
        {
            var model = ObterRestaurante(idRestaurante);
            model.CustosDisponiveis = _listaCustoDisponiveis;
            model.TiposDisponiveis = _listaTipoDisponiveis;
            model.VetosDisponiveis = _listaVetoDisponiveis;
            model.Custos.ToList().ForEach(custo => model.CustosSelecionados.Add(custo.IdCusto));
            model.Tipos.ToList().ForEach(tipo => model.TiposSelecionados.Add(tipo.IdTipo));
            model.Vetos.ToList().ForEach(veto => model.VetosSelecionados.Add(veto.IdVeto));

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(RestauranteFiltro model)
        {
            var restaurante = new Restaurante(){
                IdRestaurante = model.Id,
                Nome = model.Nome,
                Apelido = model.Apelido,
                Endereco = model.Endereco,
                Observacao = model.Observacao,
                Custos = ObterCustos().Where(custo => model.CustosSelecionados.Contains(custo.IdCusto)).ToList(),
                Tipos = ObterTipos().Where(tipo => model.TiposSelecionados.Contains(tipo.IdTipo)).ToList(),
                Vetos = ObterVetos().Where(veto => model.VetosSelecionados.Contains(veto.IdVeto)).ToList()
            };

            if (ModelState.IsValid)
            {
                var restauranteRepository = new NHibernateRestauranteRepository();
                restauranteRepository.SaveOrUpdate(restaurante);

                TempData["sucessMessage"] = string.Format("Restaurante {0} alterado com sucesso.", restaurante.Apelido);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Editar", "Restaurante");
        }

        [HttpGet]
        public ActionResult Detalhe(int idRestaurante)
        {
            var model = ObterRestaurante(idRestaurante);
            model.CustosDisponiveis = _listaCustoDisponiveis;
            model.TiposDisponiveis = _listaTipoDisponiveis;
            model.VetosDisponiveis = _listaVetoDisponiveis;
            model.Custos.ToList().ForEach(custo => model.CustosSelecionados.Add(custo.IdCusto));
            model.Tipos.ToList().ForEach(tipo => model.TiposSelecionados.Add(tipo.IdTipo));
            model.Vetos.ToList().ForEach(veto => model.VetosSelecionados.Add(veto.IdVeto));

            return View(model);
        }

        public List<Restaurante> ObterRestaurantes()
        {
            try
            {
                var restauranteRepository = new NHibernateRestauranteRepository(session: NHibernateHelper.OpenSession());
                var restaurantes = from rest in restauranteRepository.ObterTodos()
                                   select rest;

                return restaurantes.OrderBy(r => r.Nome).ToList();
            }
            catch (Exception)
            {
                RedirectToAction("Index", "Home");
                throw;
            }
        }

        public List<Restaurante> ObterRestaurantes(RestauranteFiltro model)
        {
            try
            {
                var restauranteRepository = new NHibernateRestauranteRepository(session: NHibernateHelper.OpenSession());
                var restaurantes = from rest in restauranteRepository.ObterTodos()
                                   where (!model.CustosSelecionados.Any() || rest.Custos.Any(c => model.CustosSelecionados.Contains(c.IdCusto)))
                                        && (!model.TiposSelecionados.Any() || rest.Tipos.Any(t => model.TiposSelecionados.Contains(t.IdTipo)))
                                        && (!model.VetosSelecionados.Any() || rest.Vetos.Any(v => model.VetosSelecionados.Contains(v.IdVeto)))
                                   select rest;

                return restaurantes.OrderBy(r => r.Nome).ToList();
            }
            catch (Exception)
            {
                RedirectToAction("Index", "Home");
                throw;
            }
        }

        public RestauranteFiltro ObterRestaurante(int idRestaurante)
        {
            try
            {
                var restauranteRepository = new NHibernateRestauranteRepository(session: NHibernateHelper.OpenSession());
                var restaurante = (from rest in restauranteRepository.ObterTodos()
                                   where rest.IdRestaurante == idRestaurante
                                   select rest).First();

                var model = new RestauranteFiltro()
                {
                    Id = restaurante.IdRestaurante,
                    Apelido = restaurante.Apelido,
                    Endereco = restaurante.Endereco,
                    Nome = restaurante.Nome,
                    Observacao = restaurante.Observacao,
                    Custos = restaurante.Custos,
                    Tipos = restaurante.Tipos,
                    Vetos = restaurante.Vetos
                };

                return model;
            }
            catch (Exception)
            {
                RedirectToAction("Index", "Home");
                throw;
            }
        }

        public List<Restaurante> ObterRestauranteAleatorio()
        {
            try
            {
                var restauranteRepository = new NHibernateRestauranteRepository(session: NHibernateHelper.OpenSession());
                var listaRestaurantes = (from rest in restauranteRepository.ObterTodos()
                                         where !rest.Tipos.Any(t => t.IdTipo == 4) // Zueira
                                         select rest).ToList();
                
                var listaRetornoRestaurantes = new List<Restaurante>();

                if (listaRestaurantes.Any())
                {
                    int escolhaAleatoria = rnd.Next(listaRestaurantes.Count);
                    var restauranteEscolhido = listaRestaurantes[escolhaAleatoria];
                    listaRetornoRestaurantes.Add(restauranteEscolhido);
                }

                return listaRetornoRestaurantes;
            }
            catch (Exception)
            {
                RedirectToAction("Index", "Home");
                throw;
            }
        }

        public List<Restaurante> ObterRestauranteAleatorio(RestauranteFiltro model)
        {
            try
            {
                var restauranteRepository = new NHibernateRestauranteRepository(session: NHibernateHelper.OpenSession());
                var listaRestaurantes = (from rest in restauranteRepository.ObterTodos()
                                         where !rest.Tipos.Any(t => t.IdTipo == 4) // Zueira
                                            && (!model.CustosSelecionados.Any() || rest.Custos.Any(c => model.CustosSelecionados.Contains(c.IdCusto)))
                                            && (!model.TiposSelecionados.Any() || rest.Tipos.Any(t => model.TiposSelecionados.Contains(t.IdTipo)))                                            
                                            //&& (!(rest.Vetos.Any() && rest.Vetos.AsQueryable().Except(listaVetos.AsQueryable()).Any()))
                                         select rest).ToList();

                var listaRestaurantesPosVetoIgnorado = new List<Restaurante>();

                foreach(var restaurante in listaRestaurantes)
                {
                    var listaVeto = new List<int>();
                    restaurante.Vetos.ToList().ForEach(veto => listaVeto.Add(veto.IdVeto));

                    if (!listaVeto.Except(model.VetosSelecionados).ToList().Any())
                        listaRestaurantesPosVetoIgnorado.Add(restaurante);
                }

                var listaRetornoRestaurantes = new List<Restaurante>();

                if (listaRestaurantesPosVetoIgnorado.Any())
                {
                    int escolhaAleatoria = rnd.Next(listaRestaurantesPosVetoIgnorado.Count);
                    var restauranteEscolhido = listaRestaurantesPosVetoIgnorado[escolhaAleatoria];
                    listaRetornoRestaurantes.Add(restauranteEscolhido);
                }
                
                return listaRetornoRestaurantes;
            }
            catch (Exception)
            {
                RedirectToAction("Index", "Home");
                throw;
            }
        }

        private List<SelectListItem> ObterListaCustos()
        {
            var listaCustos = ObterCustos();
            var selectListCustos = new List<SelectListItem>();

            foreach(var custo in listaCustos)
            {
                selectListCustos.Add(new SelectListItem { Text = custo.DescricaoCusto, Value = custo.IdCusto.ToString() });
            }

            return selectListCustos;
        }

        private List<SelectListItem> ObterListaTipos()
        {
            var listaTipos = ObterTipos();
            var selectListTipos = new List<SelectListItem>();

            foreach (var tipo in listaTipos)
            {
                selectListTipos.Add(new SelectListItem { Text = tipo.DescricaoTipo, Value = tipo.IdTipo.ToString() });
            }

            return selectListTipos;
        }

        private List<SelectListItem> ObterListaVetos()
        {
            var listaVetos = ObterVetos();
            var selectListVetos = new List<SelectListItem>();

            foreach (var veto in listaVetos)
            {
                selectListVetos.Add(new SelectListItem { Text = veto.DescricaoVeto, Value = veto.IdVeto.ToString() });
            }

            return selectListVetos;
        }

        private List<Custo> ObterCustos()
        {
            var custoRepository = new NHibernateCustoRepository();

            return custoRepository.ObterTodos().OrderBy(c => c.DescricaoCusto).ToList();
        }
        
        private List<Tipo> ObterTipos()
        {
            var tipoRepository = new NHibernateTipoRepository();

            return tipoRepository.ObterTodos().OrderBy(c => c.DescricaoTipo).ToList();
        }

        private List<Veto> ObterVetos()
        {
            var vetoRepository = new NHibernateVetoRepository();

            return vetoRepository.ObterTodos().OrderBy(c => c.DescricaoVeto).ToList();
        }
    }
}