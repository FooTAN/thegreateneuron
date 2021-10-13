using Application.Articles;
using Application.Articles.Queries.GetArticles;
using Common.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ListController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<ArticleDto>> GetArticles()
        {
            return await Mediator.Send(new GetAllArticlesQuery());
        }
    }
}
