import React, { useEffect, useState } from 'react';
import axios from 'axios';
import ArticleFeaturette from '../ArticleFeaturette';
import { Article } from '../../models/article';

function ArticleFeaturettes() {
    const [articles, setArticles] = useState<Article[]>([]);

    useEffect(()=>{
        axios.get<Article[]>('/api/article/list').then(response => {
            setArticles(response.data);
        });

        console.log(articles);
    }, []);

  return (
      <div>
          {/*articles.map((article:Article) => (
              <ArticleFeaturette key={article.id} article={article.title}></ArticleFeaturette>
          ))*/}
      </div>
  );
}

export default ArticleFeaturettes;