using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Team
{
    internal class TaskUtils
    {
        public static int TalestInTwoContainers(PlayerContainer container1, PlayerContainer container2)
        {
            int talest = 0;
            if (container1.FindsTalestPlayer() <= container2.FindsTalestPlayer())
                talest = container2.FindsTalestPlayer();
            else
                talest = container1.FindsTalestPlayer();
            return talest;
        }
        public static PlayerContainer Talest(PlayerContainer Talest, PlayerContainer container1, int talest)
        {
            for (int i = 0; i < container1.Count; i++)
            {
                if (talest == container1.Get(i).Height && !Talest.Contains(container1.Get(i)))
                    Talest.Add(container1.Get(i));
            }
            return Talest;
        }
    }
}
