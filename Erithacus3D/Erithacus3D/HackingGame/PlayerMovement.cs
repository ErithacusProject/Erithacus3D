using Erithacus3D.Engine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erithacus3D.HackingGame
{
    public class PlayerMovement : Engine.Component
    {
        public PlayerMovement(Game gameManager, GameObject owner) : base(gameManager, owner) 
        {
             Input.playerDirection += setMoveDirection;
        }

        private void setMoveDirection(Vector3 direction)
        {
            Debug.WriteLine("direction key pressed");
            gameObject.GetComponent<Rigidbody>().AddForce(direction);
        }

    }
}
