using System;
using System.Net;
using System.Text;
using APIRedisCore.RedisService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIRedisCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Search")]
    [AllowAnonymous]
    public class SearchController : Controller
    {
        const string Taco = "taco";
        const string Polishop = "polishop";

        private readonly ICache _cache;

        public SearchController(ICache cache)
        {
            _cache = cache;
        }

        [HttpGet]
        [Route("vtexpolishop/{pesquisa}")]
        public IActionResult VtexPolishop(string pesquisa)
        {
            using (WebClient wc = new WebClient { Encoding = Encoding.UTF8 })
            {
                try
                {
                    var json = wc.DownloadString($"http://polishop.vtexcommercestable.com.br/api/catalog_system/pub/products/search/{pesquisa}");

                    return Ok(json);
                }
                catch (Exception)
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { "Ocorreu uma falha interna no servidor." }
                    });
                }
            }
        }


        [HttpGet]
        [Route("vtextaco/{pesquisa}")]
        public IActionResult VtexTaco(string pesquisa)
        {
            using (WebClient wc = new WebClient { Encoding = Encoding.UTF8 })
            {
                try
                {
                    var json = wc.DownloadString($"http://taco.vtexcommercestable.com.br/api/catalog_system/pub/products/search/{pesquisa}");

                    return Ok(json);
                }
                catch (Exception ex)
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { "Ocorreu uma falha interna no servidor." }
                    });
                }
            }
        }

        [HttpGet]
        [Route("findtaco/{id}")]
        public IActionResult FindTaco(long id)
        {
            using (WebClient wc = new WebClient { Encoding = Encoding.UTF8 })
            {
                try
                {
                    _cache.CountVisitas(id, Taco);

                    var json = wc.DownloadString($"http://taco.vtexcommercestable.com.br/api/catalog_system/pub/products/search?fq=productId:{id}");

                    return Ok(json);
                }
                catch (Exception ex)
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { "Ocorreu uma falha interna no servidor." }
                    });
                }
            }
        }

        [HttpGet]
        [Route("findpolishop/{id}")]
        public IActionResult FindPolishp(long id)
        {
            using (WebClient wc = new WebClient { Encoding = Encoding.UTF8 })
            {
                try
                {
                    _cache.CountVisitas(id, Polishop);

                    var json = wc.DownloadString($"http://polishop.vtexcommercestable.com.br/api/catalog_system/pub/products/search?fq=productId:{id}");


                    return Ok(json);
                }
                catch (Exception ex)
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { "Ocorreu uma falha interna no servidor." }
                    });
                }
            }
        }

        [HttpGet]
        [Route("totalVisitasPolishop")]
        public IActionResult TotalVisitas(long id, DateTime data)
        {
            try
            {
                return Ok(_cache.TotalVisitasProduto(id, data, Polishop));
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = new[] { "Ocorreu uma falha interna no servidor." }
                });
            }
        }

        [HttpGet]
        [Route("totalVisitasTaco")]
        public IActionResult TotalVisitasTaco(long id, DateTime data)
        {

            try
            {
                return Ok(_cache.TotalVisitasProduto(id, data, Taco));                
            }
            catch (Exception)
            {

                return BadRequest(new
                {
                    success = false,
                    errors = new[] { "Ocorreu uma falha interna no servidor." }
                });
            }
        }
    }
}