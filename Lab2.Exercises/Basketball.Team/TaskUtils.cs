using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Team
{
    internal class TaskUtils
    {
        public static int TalestInTwoRegisters(PlayerRegister register1, PlayerRegister register2)
        {
            int talest = 0;
            if (register1.FindsTalestPlayer() <= register2.FindsTalestPlayer())
                talest = register2.FindsTalestPlayer();
            else
                talest = register1.FindsTalestPlayer();
            return talest;
        }
        public static PlayerRegister Talest(PlayerRegister Talest, PlayerRegister register1, int talest)
        {
            for (int i = 0; i < register1.PlayersCount(); i++)
            {
                if (talest == register1.GetPlayer(i).Height && !Talest.Contains(register1.GetPlayer(i)))
                    Talest.Add(register1.GetPlayer(i));
            }
            return Talest;
        }
    }
}
