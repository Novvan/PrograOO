using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Menu : GameObject
    {
        private Button playButton;
        private Button quitButton;
        private Button currentHighlightButton;
        public Menu(Vector2 initialPosition, string texturePath, float angle, float scaleX, float scaleY) : base(initialPosition, texturePath, angle, scaleX, scaleY)
        {
            playButton = new Button(new Vector2(Program.Width / 2, 350), "textures/assets/Menu/play.png", 0f, 1f, 1f, "textures/assets/Menu/yellowplay.png");
            playButton.OnButtonSelected += OnSelectedPlayButton;
            quitButton = new Button(new Vector2(Program.Width / 2, 550), "textures/assets/Menu/quit.png", 0f, 1f, 1f, "textures/assets/Menu/yellowquit.png");
            quitButton.OnButtonSelected += OnSelectedQuitButton;
            currentHighlightButton = playButton;
            currentHighlightButton.OnHighlight();
        }

        public override void Update()
        {
            if (Engine.GetKey(Keys.SPACE))
            {
                currentHighlightButton.Select();
            }
            if (Engine.GetKey(Keys.UP) || (Engine.GetKey(Keys.DOWN)))
            {
                currentHighlightButton.OnUnHighlight(); 
                if(currentHighlightButton == playButton)
                {
                    currentHighlightButton = quitButton;
                }
                else
                {
                    currentHighlightButton = playButton;
                }
                currentHighlightButton.OnHighlight();
            }                       
            playButton.Update();
            quitButton.Update();
        }
      
        public override void Render()
        {
            base.Render();
            playButton.Render();
            quitButton.Render();
        }
        private void OnSelectedPlayButton()
        {
            GameManager.Instance.ChangeCurrentState(State.Level);
        }
        private void OnSelectedQuitButton()
        {
            Environment.Exit(1);
        }
    }
}
