import React, { Component } from 'react';
import "./styles/main.css";
import moon from "./img/icons/moon.svg";
import sun from "./img/icons/sun.svg";
import vk from "./img/icons/vk.svg";
import instagram from "./img/icons/instagram.svg";
import twitter from "./img/icons/twitter.svg";
import gitHub from "./img/icons/gitHub.svg";
import linkedIn from "./img/icons/linkedIn.svg";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <div className='App'>
        <nav class="nav">
          <div class="container">
              <div class="nav-row">
                  <a href="./index.html" class="logo"><strong>Loud</strong>Voice</a>

                  <button class="dark-mode-btn">
                      <img src={sun} alt="Light mode" class="dark-mode-btn__icon"/>
                      <img src={moon} alt="Dark mode" class="dark-mode-btn__icon"/>
                  </button>

                  <ul class="nav-list">
                      <li class="nav-list__item"><a href="./index.html" class="nav-list__link nav-list__link--active">Home</a></li>
                      <li class="nav-list__item"><a href="./projects.html" class="nav-list__link">Projects</a></li>
                      <li class="nav-list__item"><a href="./contacts.html" class="nav-list__link">Contacts</a></li>
                  </ul>
              </div>
          </div>
        </nav>

        <header class="header">
          <div class="header__wrapper">
            <h1 class="header__title">
                <strong>Hi, my name is <em>LoudVoice</em></strong><br/>
                I am a music web player for you
            </h1>
            <div class="header__text">
                <p>with passion for dreaming and creating.</p>
            </div>
            <a href="#!" class="btn"><strong>/START</strong></a>
          </div>
        </header>

        {/* <main class="section">
          <div class="container">

          </div>
        </main> */}

        <footer class="footer">
          <div class="container">
              <div class="footer__wrapper">
                  <ul class="social">
                      <li class="social__item"><a href="#!"><img src={vk} alt="Link"/></a></li>
                      <li class="social__item"><a href="#!"><img src={instagram} alt="Link"/></a></li>
                      <li class="social__item"><a href="#!"><img src={twitter} alt="Link"/></a></li>
                      <li class="social__item"><a href="#!"><img src={gitHub} alt="Link"/></a></li>
                      <li class="social__item"><a href="#!"><img src={linkedIn} alt="Link"/></a></li>
                  </ul>
                  <div class="copyright">
                      <p>© 2023 LoudVoice</p>
                  </div>
              </div>
          </div>
        </footer>
      </div>
    );
  }
}
