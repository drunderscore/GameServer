using GameServerCore.Domain.GameObjects;
using GameServerCore.Domain;
using LeagueSandbox.GameServer.API;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits.AI;
using LeagueSandbox.GameServer.Scripting.CSharp;
using LeagueSandbox.GameServer.API.Events;

namespace Spells
{
    public class Recall : IGameScript
    {
        private IChampion owner;

        public void OnStartCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {
        }

        public void OnFinishCasting(IChampion owner, ISpell spell, IAttackableUnit target)
        {
            // @TODO Interrupt the script when owner uses movement spells
            owner.AddBuffGameScript("Recall", "Recall", spell, 8.0f, true);
        }

        public void ApplyEffects(IChampion owner, IAttackableUnit target, ISpell spell, IProjectile projectile)
        {
        }

        public void OnUpdate(double diff)
        {
        }

        [Listener]
        public void OnUnitDamage(OnUnitDamageTaken e)
        {
            if (e.Unit == owner && owner.HasBuffGameScriptActive("Recall", "Recall"))
            {
                ((ObjAiBase)owner).RemoveBuffGameScriptsWithName("Recall", "Recall");
            }
        }

        public void OnActivate(IChampion owner)
        {
            this.owner = owner;
            ApiEventManager.Subscribe(this);
        }

        public void OnDeactivate(IChampion owner)
        {
            ApiEventManager.Unsubscribe(this);
        }
    }
}

