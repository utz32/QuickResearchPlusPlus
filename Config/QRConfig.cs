using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace QuickResearchPlusPlus.Config
{
	public class QRConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		[Header("Research")]
		[Label("Only complete research")]
		[Tooltip("Only research items if there are enough of them to complete research.")]
		[DefaultValue(true)]
		
		public bool CompleteResearchToggle;
		
		//~ trashes the already researched items
		[Label("Clear Inventory")]
		[Tooltip("trash everything that isn't favorited, after Research check, including coins and ammo")]
		[DefaultValue(false)]
		
		public bool ClearInventoryToggle;		
		
		[Header("UI")]
		[Label("Show UI Button")]
		[Tooltip("Show UI Button")]
		[DefaultValue(true)]

		public bool ShowButton;
		
		
		[Label("Button X")]
		[Tooltip("Button Offset from the Left")]
		[DefaultValue(70)]
		[Range(int.MinValue, int.MaxValue)]

		public int ButtonX;
		
		
		[Label("Button Y")]
		[Tooltip("Button Offset from the Top")]
		[DefaultValue(267)]
		[Range(int.MinValue, int.MaxValue)]

		public int ButtonY;
		
				//~ show what items are researched
		[Header("Debug")]
		[Label("Display researched items in Chat")]
		[Tooltip("Display researched items in Chat")]
		[DefaultValue(false)]

		public bool DisplayResearchedItemsInChat;		

		
	}
}
