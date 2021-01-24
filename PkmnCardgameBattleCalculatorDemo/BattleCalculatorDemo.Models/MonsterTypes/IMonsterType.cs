using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCalculatorDemo.Models.MonsterTypes
{
    public interface IMonsterType
    {
        string Name { get; }
        string Icon { get; }
        ArrayList TypeAgainst { get; }
    }
}
