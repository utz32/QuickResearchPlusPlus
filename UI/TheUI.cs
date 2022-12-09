using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.UI;
using QuickResearchPlusPlus.Config;

namespace QuickResearchPlusPlus.UI
{
    class TheUI : UIState
    {
		private UIHoverImageButton button;
		
		public override void OnActivate()
		{
			button.Top.Set(ModContent.GetInstance<QRConfig>().ButtonY, 0);
            button.Left.Set(ModContent.GetInstance<QRConfig>().ButtonX, 0);
		}
		
        public override void OnInitialize()
        {
            var texture = ModContent.Request<Texture2D>("QuickResearchPlusPlus/UI/QuickResearchButton");
            button = new UIHoverImageButton(texture, "Quick Research");
            button.Width.Set(34, 0);
            button.Height.Set(32, 0);
            button.Top.Set(ModContent.GetInstance<QRConfig>().ButtonY, 0);
            button.Left.Set(ModContent.GetInstance<QRConfig>().ButtonX, 0);
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
