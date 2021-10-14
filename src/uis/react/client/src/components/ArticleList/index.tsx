import { Article } from '../../models/article';
import ArticleFeaturette from '../ArticleFeaturette';

interface Props{
  articles: Article[];
}

function ArticleList({articles}: Props) {
  return (
    <>
      {articles.map((article:Article) => (
        <div key={article.id}>
            <ArticleFeaturette article={article} />
        </div>
      ))}
    </>
  );
}

export default ArticleList;