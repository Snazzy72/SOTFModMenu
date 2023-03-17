using Sons.Inventory;
using Sons.Items.Core;
using SOTFModMenu.Components.Utility;
using TheForest.Utils;

namespace SOTFModMenu.Components.Player.Ammo
{
    public class LocalPlayerAmmo
    {
        public static void EnableInfAmmo()
        {
            if (!Settings.InfAmmo)
            {
                return;
            }

            if (!LocalPlayer.Inventory.IsRightHandEmpty() && !LocalPlayer.Inventory.Logs.HasLogs)
            {
                if (LocalPlayer.Inventory.RightHandItem.Data._type.HasFlag(Types.RangedWeapon)) 
                {
                    if (LocalPlayer.Inventory.RightHandItem.TryGetModule(out RangedWeaponItemInstanceModule module))
                    {
                        if (module._rangedWeapon._ammo._currentCount < module._rangedWeapon._ammo._maxCount)
                        {
                            module._rangedWeapon._ammo._currentCount = module._rangedWeapon._ammo._maxCount;
                        }
                    }
                }
            }
        }
    }
}