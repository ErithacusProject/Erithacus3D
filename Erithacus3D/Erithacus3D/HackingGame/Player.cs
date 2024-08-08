using Erithacus3D.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erithacus3D.HackingGame
{
    public class Player : GameObject
    {
        public Player(GameManager manager) : base(manager) 
        { 
            Renderer ren = AddComponent<Renderer>();
            ren.Initialize("Models/cube", null);
        }
    }
}
