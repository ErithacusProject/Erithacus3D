using Erithacus3D.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erithacus3D.HackingGame
{
    public class HackingGameManager : GameManager
    {

        protected override void Initialize()
        {
            Player player = new Player(this);


            base.Initialize();
        }
    }
}
