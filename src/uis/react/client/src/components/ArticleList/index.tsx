import { Article } from '../../models/article';
import ArticleFeaturette from '../ArticleFeaturette';

interface Props{
  articles: Article[];
}

function ArticleList({articles}: Props) {
  return (
    <ul className="list-group list-group-flush">
      {articles.map((article:Article) => (
        <li key={article.id} className="list-group-item">
            <ArticleFeaturette article={article} />
        </li>
      ))}
    </ul>
  );
}

export default ArticleList;