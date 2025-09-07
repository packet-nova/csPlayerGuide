using Level52TheFinalBattle.BattleCommands;
using Level52TheFinalBattle.BattleEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level52TheFinalBattle.Item
{
    public class VinsBow : IEquippable
    {
        public string Name => "Vin's Bow";
        public IBattleCommand ProvidedCommand => new QuickShot();
    }
}
