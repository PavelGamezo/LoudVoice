import "./style.css"
import moon from "./../../img/icons/moon.svg";
import sun from "./../../img/icons/sun.svg";

const Navbar = () => {
    return (
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
    );
}
 
export default Navbar; 