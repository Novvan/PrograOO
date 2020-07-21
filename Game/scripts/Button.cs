using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.scripts
{
    public class Button : GameObject
    {
        

        private Texture nonHighlightTexture;
        private Texture highlightTexture;
        private Button nextButton;
        public Button NextButton => nextButton;
        private Button previousButton;
        public Button PreviousButton => previousButton;
        public event Action OnButtonSelected;


        public Button(Vector2 initialPosition, string texturePath, float angle, Vector2 size,
            string selectedTexturePath) : base(initialPosition, texturePath, angle, size)
        {
            nonHighlightTexture = Engine.GetTexture(texturePath);
            highlightTexture = Engine.GetTexture(selectedTexturePath);           
        }
        public void AssignButtons(Button previousButton, Button nextButton)
        {
            this.previousButton = previousButton;
            this.nextButton = nextButton;
        }

        public override void Update()
        {
            
        }
        public void Select()
        {
            OnButtonSelected?.Invoke();
        }
        public void OnHighlight()
        {
            
            renderer.Texture = highlightTexture;
            Engine.Debug("funciona");
        }
        public void OnUnHighlight()
        {

            renderer.Texture = nonHighlightTexture;
        }
    }
}
