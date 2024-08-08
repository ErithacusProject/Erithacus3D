using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erithacus3D.Engine
{
    public class Renderer : DrawableGameComponent
    {
        public Renderer(Game game, GameObject owner) : base(game) 
        { gameObject = owner; game.Components.Add(this); }
        public GameObject gameObject { get; protected set; }
        public Guid id { get; protected set; }

        private Model _model;

        private Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 100f);

        public void Initialize(string path, Model model)
        {
            base.Initialize();
            id = Guid.NewGuid();
            gameObject.transform.rotation.X = 90;

            if (model != null) { _model = model; }
            else if (path != null) { _model = Game.Content.Load<Model>(path); }
            
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            foreach (var mesh in _model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {

                    effect.TextureEnabled = true;
                    effect.Alpha = 1;
                    effect.World = Matrix.CreateTranslation(gameObject.transform.position) * Matrix.CreateRotationX(gameObject.transform.rotation.X);
                    effect.View = Matrix.CreateLookAt(new Vector3(0, 0, 10), Vector3.Zero, Vector3.UnitX); ;
                    effect.Projection = projection;
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                    effect.AmbientLightColor = new Vector3(0.2f, 0.1f, 0.3f);
                    effect.DiffuseColor = new Vector3(0.96f, 0.98f, 0.89f);
                }

                mesh.Draw();
            }
        }
    }
}
