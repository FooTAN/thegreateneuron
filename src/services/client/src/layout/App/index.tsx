import React from 'react';
import './style.scss';
import UsersView from '../../components/UsersView';
import ArticleFeaturette from '../../components/ArticleFeaturette';
import NavBar from '../NavBar';
import Footer from '../Footer';

function App() {
  return (
    <div>
<div className="container py-3">
  <header>
    <NavBar/>
  </header>

  <main>
  <section className="py-5 text-center container">
    <div className="row py-lg-5">
      <div className="col-lg-6 col-md-8 mx-auto">
        <h1 className="fw-light">Latest From TGN</h1>
        <p className="lead text-muted">Some Text here</p>
        <p>
          Maybe more text here
        </p>
      </div>
    </div>
  </section>
    <h2 className="display-6 text-center mb-4">Latest Dog vs Cat Comparison</h2>
    <UsersView></UsersView>
</main>

  <footer className="pt-4 my-md-5 pt-md-5 border-top">
    <Footer></Footer>
  </footer>
</div>
</div>
  );
}

export default App;
