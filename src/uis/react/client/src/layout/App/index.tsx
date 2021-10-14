import React from 'react';
import './style.scss';
import UsersView from '../../components/UsersView';
import ArticleFeaturette from '../../components/ArticleFeaturette';
import NavBar from '../NavBar';
import Footer from '../Footer';
import ArticleList from '../../components/ArticleList';
import ArticleDashboard from '../../components/ArticleDashboard';
import Jumbotron from '../../components/Jumbotron';
import ScaffoldComponent from '../../components/ScaffoldComponent';

function App() {
  return (
    <>
      <div className="container py-3">
    <header>
      <NavBar />
    </header>

    <main>
      <section className="pb-5 container">
        <div className="row">
          <div className="col-12 mb-1">
              <ScaffoldComponent title="Breadcrumbs"></ScaffoldComponent>
          </div>
        </div>
        <div className="row">
          <div className="col-12">
            <Jumbotron></Jumbotron>
          </div>
        </div>
        <div className="row py-5">
          <div className="col-12">
            <ScaffoldComponent title="latest Cats vs dog AI Comparisons" height="256px" width="100%"></ScaffoldComponent>     
          </div>
        </div>
        <div className="row py-5">
          <div className="col-12">
            <ArticleDashboard />
          </div>
        </div>
      </section>

    </main>

    <footer className="pt-4 my-md-5 pt-md-5 border-top">
      <Footer></Footer>
    </footer>
  </div>
    </>
  );
}

export default App;
