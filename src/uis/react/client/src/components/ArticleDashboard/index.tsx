import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { Article } from '../../models/article'
import ArticleList from '../ArticleList';



function ArticleDashboard() {
    const [articles, setArticles] = useState<Article[]>([]);

    useEffect(()=>{
        axios.get<Article[]>('/api/article/list').then(response => {
            setArticles(response.data);
        });
    }, []);

    return (
        <div className="row">
            <div className="col">
                <ArticleList articles={articles} />
            </div>
        </div>
    )
}

export default ArticleDashboard
