import "./style.css";

const Header = () => {
    return ( 
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
     );
}
 
export default Header;