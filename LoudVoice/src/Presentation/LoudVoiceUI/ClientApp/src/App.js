import React, { Component } from 'react';
import "./styles/main.css";

import Navbar from './components/navbar/Navbar';
import Footer from './components/footer/Footer';
import Home from './pages/Home';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <div className='App'>
        <Navbar/>

        <Home/>

        <Footer/>

      </div>
    );
  }
}
