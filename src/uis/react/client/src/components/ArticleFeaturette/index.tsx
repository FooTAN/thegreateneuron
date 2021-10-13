import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Article } from '../../models/article';
import './style.scss';

interface Props{
    article: Article;
  }

function ArticleFeaturette({article}:Props) {
  return (
    <div className="container articleFeaturette">
        <div className="row">
            <div className="col">
                <h3>{article.title}</h3>
            </div>
        </div>
        <div className="row">
            <div className="col">
                <span className="articleInfo articleInfo__text--default"><small>By: FooUser Created:01.01.1979 updated: 02.02.1980</small></span>
            </div>
        </div>
        <div className="row">
            <div className="col">
                <div className="mt-2">
                {article.text.substring(0, 100)}
                </div>
            </div>
        </div>
        <div className="row">
            <div className="col">
            <div className="mt-3">
                <a href="#">Readmore</a>
            </div>
            </div>
        </div>
      </div>
  );
}

export default ArticleFeaturette;