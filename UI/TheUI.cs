using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.UI;
using QuickResearch.Config;

namespace QuickResearch.UI
{
    class TheUI : UIState
    {
		public UIHoverImageButton button;
		
		public override void OnActivate()
		{
			button.Top.Set(ModContent.GetInstance<QRConfig>().ButtonY, 0);
            button.Left.Set(ModContent.GetInstance<QRConfig>().ButtonX, 0);
		}
		
        public override void OnInitialize()
        {
            var texture = ModContent.Request<Texture2D>("QuickResearch/UI/QuickResearchButton");
            button = new(texture, "Quick Research");
            button.Width.Set(34, 0);
            button.Height.Set(32, 0);
            button.Top.Set(0, 0);
            button.Left.Set(0, 0);
            button.OnClick += OnButtonClick;
            
            Append(button);
        }

        private void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            QRPlayer.BeginResearch();
        }

        internal void Unload()
        {

        }
    }
}
