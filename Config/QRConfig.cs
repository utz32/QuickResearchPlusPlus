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
	}
}
