using QuickResearchPlusPlus.UI;
using Terraria.ModLoader;

namespace QuickResearchPlusPlus
{
	public class QuickResearch : Mod
	{
        private static ModKeybind qR;
        
        public static ModKeybind QRBind { get => qR; set => qR = value; }

        public override void Load() => QRBind = KeybindLoader.RegisterKeybind(this, "Quick research", "J");

        public override void Unload() => QRBind = null;
    }
}
