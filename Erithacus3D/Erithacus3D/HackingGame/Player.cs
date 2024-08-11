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
            ren.Initialize("Models/player", null, "Textures/white");

            AddComponent<Rigidbody>();
            PlayerMovement movement =  AddComponent<PlayerMovement>();
            movement.playerSpeed = 2.5f;
        }
    }
}
