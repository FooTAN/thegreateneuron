using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Articles.Queries.GetArticles
{
    public class GetAllArticlesQuery : IRequest<IEnumerable<ArticleDto>>
    {
    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllArticlesQuery, IEnumerable<ArticleDto>>
    {
        public async Task<IEnumerable<ArticleDto>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            var artArr = new ArticleDto[] {
                new ArticleDto
                {
                    Id = 0,
                    Title = "cats jump higher than dogs",
                    Text = "cats jump higher than dogs because the ratio of meat to bodyweight in the cat is generally higher than in the dog. However, it’s not the number of calories or protein grams per pound that matters; it’s the ratio of calories to weight. Because dogs have larger metabolisms, they need fewer calories to maintain their body weight. The ratio of protein grams to weight is also important, but because cats are relatively smaller in size, they can survive on lower percentages of protein in their diets. For example, you can safely give a 20-pound dog a diet that’s 10 percent protein and 50 percent carbohydrates, while a 5-pound"
                },
                new ArticleDto
                {
                    Id = 1,
                    Title = "who eats the most",
                    Text =  "When it comes to food, the animal kingdom seems to have an order of preference: a dog will eat cats, and cats will eat dogs. But what about cats and dogs eating other animals? What about dogs and cows? And what about cats and dogs eating dogs?  I found myself faced with these questions, as my husband and I sat down with our four-year-old son at a restaurant in the Poconos, and our 14-year-old daughter joined us after her school band practice.  “Well, I don’t eat dogs,” said our son, who"
                },
                new ArticleDto
                {
                    Id = 2,
                    Title = "Who would win in a fight",
                    Text = "Well, the real answer is that it's not possible to say which one would win. Both would win! They'd both win a lot, that's for sure. But who would win, in reality, in the fight? We can't know, but what we can say, with certainty, is that both cats and dogs would win. Both cats and dogs would lose. So in reality, neither would win the fight.  Now, if cats had their way, there'd be no dogs. Or at least, only cats who had their way would be around. And this is because cats don't see themselves as being"
                }
            };

            return await Task.FromResult<IEnumerable<ArticleDto>>(artArr);
        }
    }
}
