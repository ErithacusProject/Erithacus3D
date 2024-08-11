using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
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
        private Texture2D texture;

        private Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 100f);

        public void Initialize(string path, Model model, string texturePath)
        {
            base.Initialize();
            id = Guid.NewGuid();

            if (model != null) { _model = model; }
            else if (path != null) { _model = Game.Content.Load<Model>(path); }
            texture = Game.Content.Load<Texture2D>(texturePath);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Matrix rotationMatrix = Matrix.CreateFromYawPitchRoll(
                MathHelper.ToRadians(gameObject.transform.rotation.Y),
               MathHelper.ToRadians(gameObject.transform.rotation.X), 
               MathHelper.ToRadians(gameObject.transform.rotation.Z));
            Matrix worldMatrix =
                rotationMatrix *
                Matrix.CreateTranslation(gameObject.transform.position); 


            foreach (var mesh in _model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.Texture = texture;
                    effect.TextureEnabled = true;
                    effect.Alpha = 1;
                    effect.World = worldMatrix;
                    effect.View = Matrix.CreateLookAt(new Vector3(0, 50, 0), Vector3.Down, Vector3.UnitX); ;
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
