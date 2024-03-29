﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameInput;
using QuickResearchPlusPlus.Config;
using static Terraria.ID.ContentSamples;
using static Terraria.Audio.SoundEngine;
using static Terraria.GameContent.Creative.CreativeItemSacrificesCatalog;

using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.UI;

namespace QuickResearchPlusPlus
{
    public class QRPlayer : ModPlayer
    {
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (QuickResearch.QRBind.JustPressed && Main.GameMode.Equals(3))
            {
                BeginResearch();
            }
        }

        private static void SetSacrificeCount(Item item, int newSarcrificeCount)
        {
            Main.LocalPlayerCreativeTracker.ItemSacrifices.SetSacrificeCountDirectly(ItemPersistentIdsByNetIds[item.type], newSarcrificeCount);
        }

		public static void BeginResearch()
		{
			bool flag = false;
			bool flag2 = false;
			
			bool completeResearchToggle = ModContent.GetInstance<QRConfig>().CompleteResearchToggle;
			bool ClearInventoryToggle = ModContent.GetInstance<QRConfig>().ClearInventoryToggle;
			bool DisplayResearchedItemsInChat = ModContent.GetInstance<QRConfig>().DisplayResearchedItemsInChat;
			
			string ResearchedItemsString = "";
			
			Item[] inventory = Main.LocalPlayer.inventory;
			int num = default(int);
			
			for (int i = 0; i < inventory.Length; i++)
			{
				if (inventory[i] == Main.LocalPlayer.HeldItem || inventory[i].favorited || inventory[i].IsAir || !CreativeItemSacrificesCatalog.Instance.TryGetSacrificeCountCapToUnlockInfiniteItems(inventory[i].type, out num))
				{
					continue;
				}
				
				bool isFullyResearched = false;
				int CurrentSacrificeCount = CreativeUI.GetSacrificeCount(inventory[i].type, out isFullyResearched);
				int MaxSacrificeCount = CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[inventory[i].type];
				if ( ! isFullyResearched && ((completeResearchToggle && inventory[i].stack >= MaxSacrificeCount - CurrentSacrificeCount) || (!completeResearchToggle)))
				{
					
					int SubtractingAmount = inventory[i].stack;
					int ItemID = inventory[i].type;
					
					ResearchedItemsString += "[i:" + ItemID + "]";
					
					flag2 = true;

					
					int amountWeSacrificed;
					CreativeUI.SacrificeItem(inventory[i], out amountWeSacrificed);
					
					CurrentSacrificeCount = CreativeUI.GetSacrificeCount(ItemID, out isFullyResearched);
					if (isFullyResearched)
					{						
						flag = true;
					}
										
					inventory[i].TurnToAir();					

				}
				
				//should work for everything except not reasearchable Items
				if (ClearInventoryToggle)
				{
					inventory[i].TurnToAir();										
				}				
			}

			if (DisplayResearchedItemsInChat && (flag || flag2))
				Main.NewText(ResearchedItemsString);

			if (flag)
			{
				SoundEngine.PlaySound(SoundID.ResearchComplete, (Vector2?)null);
			}
			else if (flag2)
			{
				SoundEngine.PlaySound(SoundID.Research, (Vector2?)null);
			}
			else
			{
				SoundEngine.PlaySound(SoundID.MenuTick, (Vector2?)null);
			}
		}
	}
}
