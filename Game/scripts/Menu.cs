﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Menu : GameObject
    {
        private Button playButton;
        private Button creditsButton;
        private Button helpButton;
        private Button quitButton;
        private Button currentHighlightButton;
        private float currentPressKeyTime;
        private float delayPressKey = 0.2f;

        public Menu(Vector2 initialPosition, string texturePath, float angle, Vector2 size) : base(
            initialPosition, texturePath, angle, size)
        {
            playButton = new Button(new Vector2(Program.Width / 2, 325), "textures/assets/Menu/play.png", 0f, new Vector2(0.7f,0.7f), "textures/assets/Menu/selectedplay.png");
            playButton.OnButtonSelected += OnSelectedPlayButton;

            creditsButton = new Button(new Vector2(Program.Width / 2, 440), "textures/assets/Menu/credits.png", 0f, new Vector2(0.7f, 0.7f), "textures/assets/Menu/selectedcredits.png");
            creditsButton.OnButtonSelected += OnSelectedCreditsButton;

            helpButton = new Button(new Vector2(Program.Width / 2, 555), "textures/assets/Menu/help.png", 0f, new Vector2(0.7f, 0.7f), "textures/assets/Menu/selectedhelp.png");
            helpButton.OnButtonSelected += OnSelectedHelpButton;

            quitButton = new Button(new Vector2(Program.Width / 2, 670), "textures/assets/Menu/quit.png", 0f, new Vector2(0.7f, 0.7f), "textures/assets/Menu/selectedquit.png");
            quitButton.OnButtonSelected += OnSelectedQuitButton;

            currentHighlightButton = playButton;
            currentHighlightButton.OnHighlight();
        }

        public override void Update()
        {
            currentPressKeyTime += Time.DeltaTime;
            if (Engine.GetKey(Keys.SPACE))
            {
                currentHighlightButton.Select();
            }
            if ((Engine.GetKey(Keys.UP) || Engine.GetKey(Keys.DOWN)) && currentPressKeyTime >= delayPressKey)
            {
                currentPressKeyTime = 0;
                currentHighlightButton.OnUnHighlight();
                if (currentHighlightButton == playButton)
                {
                    currentHighlightButton = quitButton;

                }
                else
                {
                    currentHighlightButton = playButton;
                }
                currentHighlightButton.OnHighlight();
                Engine.Debug(currentHighlightButton);

            }
            playButton.Update();
            quitButton.Update();
            creditsButton.Update();
            helpButton.Update();
        }

        public override void Render()
        {
            base.Render();
            playButton.Render();
            creditsButton.Render();
            helpButton.Render();
            quitButton.Render();
        }
        private void OnSelectedPlayButton()
        {
            GameManager.Instance.ChangeCurrentState(State.Level);
        }
        private void OnSelectedQuitButton()
        {
            Engine.Debug("Quit Game");
            Environment.Exit(1);
        }
        private void OnSelectedCreditsButton()
        {
            GameManager.Instance.ChangeCurrentState(State.Credits);
        }

        private void OnSelectedHelpButton()
        {
            GameManager.Instance.ChangeCurrentState(State.Help);
        }
    }
}
