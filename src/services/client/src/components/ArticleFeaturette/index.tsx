import React, { useEffect, useState } from 'react';
import axios from 'axios';

function ArticleFeaturette() {
    const [articles, setArticles] = useState([]);

    useEffect(()=>{
        axios.get('/api/article/list').then(response => {
            setArticles(response.data);
        });
    }, []);

  return (
      <div>
          Users
          <ul>
              {articles.map((article: any) => (
              <li key={article.id}>
                  {article.title}
              </li>
              ))}
          </ul>
      </div>
  );
}

export default ArticleFeaturette;