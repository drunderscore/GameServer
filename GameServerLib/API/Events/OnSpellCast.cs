using GameServerCore.Domain;
using GameServerCore.Domain.GameObjects;
using LeagueSandbox.GameServer.Scripting.CSharp;

namespace LeagueSandbox.GameServer.API.Events
{
    public class OnSpellCast : Event, ICancelable
    {
        public IChampion Champion { get; }
        public ISpell Spell { get; }
        public IAttackableUnit Target { get; }
        public IGameScript SpellScript { get; }
        public float SpellCost { get; set; }
        public bool Canceled { get; set; }

        public OnSpellCast(IChampion champ, ISpell spell, IAttackableUnit target, IGameScript script, float spellCost)
        {
            Champion = champ;
            Target = target;
            Spell = spell;
            SpellCost = spellCost;
            SpellScript = script;
        }
    }
}
