import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Article } from '../../models/article';
import './style.scss';

interface Props{
    article: Article;
  }

function ArticleFeaturette({article}:Props) {
  return (
    <div className="article-featurette pb-5 mb-5 shadow">
          <div className="container row article-featurette__row">
            <div className="col-4 article-featurette__title-col" style={{backgroundColor:article.color}}>
                <div className="container p-3">
                    <h3 className="article-featurette__title">{article.title}</h3>
                </div>
            </div>
            <div className="col">
                <div className="row">
                    <div className="col">
                        <div className="container">
                          <span className="article-featurette--author-info ps-4"><small>By: FooUser Created:01.01.1970 updated: 02.02.1980</small></span>
                        </div>
                    </div>
                </div>
                <div className="row">
                      <div className="col">
                        <div className="container">
                            <div className="mt-4 ps-4 article-featurette--text">
                                {article.text.substring(0, 166)}
                            </div>
                        </div>
                    </div>
                </div>
                <div className="row">
                      <div className="col">
                        <div className="container">
                            <div className="mt-3 ps-4">
                                <a className="link-secondary" href="#">Readmore</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
  );
}
export default ArticleFeaturette;