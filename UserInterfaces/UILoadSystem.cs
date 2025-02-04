using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using System.Collections.Generic;
using WaasephisFishingPlus.UserInterfaces;

namespace WaasephisFishingPlus.UserInterfaces
{
    [Autoload(Side = ModSide.Client)]
    public class UILoadSystem : ModSystem
    {
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {

            //Filleting UI
            int mouseTextIndex = layers.FindIndex(layer => layer.Name == "Vanilla: Mouse Text");
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer("Filleting", () =>
                {
                    FilletingUI.Draw(Main.spriteBatch);
                    return true;
                },
                InterfaceScaleType.None));
            }
        }
    }
}