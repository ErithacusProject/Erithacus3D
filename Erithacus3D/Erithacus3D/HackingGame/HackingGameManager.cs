using Erithacus3D.Engine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Erithacus3D.HackingGame
{
    public class HackingGameManager : GameManager
    {
        Input _input;
        protected override void Initialize()
        {
            Player player = new Player(this);
            AddGameObject(player);
            _input = new Input(this);

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        private void PollInputs()
        {

        }
    }
}
