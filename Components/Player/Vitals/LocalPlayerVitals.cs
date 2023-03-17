using SOTFModMenu.Components.Utility;
using TheForest.Utils;

namespace SOTFModMenu.Components.Player.Stats
{
    public class LocalPlayerStats
    {
        private static Vitals vitals;
        public static void ModifyVitals()
        {
            if (vitals == null)
            {
                vitals = LocalPlayer.Vitals;
            }

            if (Settings.Health)
            {
                vitals._health._currentValue = vitals._health._max;
            }

            if (Settings.Stamina)
            {
                vitals._stamina._currentValue = vitals._stamina._max;
            }

            if (Settings.Cold)
            {
                vitals._temperature._currentValue = vitals._temperature._max;
                vitals._temperature._baseValue = vitals._temperature._max;
                vitals._isCold = Settings.Cold;
            }

            if (Settings.Hunger)
            {
                vitals._fullness._currentValue = vitals._fullness._max;
            }
                
            if (Settings.Thirst)
            {
                vitals._hydration._currentValue = vitals._hydration._max;
            }

            if (Settings.Rested)
            {
                vitals._rested._currentValue = vitals._rested._max;
            }

            if (Settings.Strength)
            {
                vitals._strength._currentValue = vitals._strength._max;
            }

            if (Settings.LungCapacity)
            {
                vitals.LungBreathing.CurrentLungAir = vitals.LungBreathing.MaxLungAirCapacity;
            }
        }
    }
}