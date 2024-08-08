using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Erithacus3D.HackingGame
{
    public class Input : GameComponent
    {
        public static System.Action<Vector3> playerDirection;
        public Input(Game game) : base(game) { game.Components.Add(this); }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            #region movement inputs
            Vector3 movementDirection = Vector3.Zero;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                movementDirection.Y -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                movementDirection.Y += 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                movementDirection.X += 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                movementDirection.X -= 1;
            }
            if (movementDirection != Vector3.Zero)
            {
                playerDirection?.Invoke(movementDirection);
            }
            #endregion
        }
    }
}
