using GameServerCore.Domain.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSandbox.GameServer.API
{
    public class OnUnitDamageTaken : Event
    {
        public IAttackableUnit Unit { get; }
        public float Damage { get; }

        public OnUnitDamageTaken( IAttackableUnit unit, float dmg)
        {
            Unit = unit;
            Damage = dmg;
        }
    }
}
