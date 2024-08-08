using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Erithacus3D.Engine
{
    public class Rigidbody : Component
    {
        float _mass = 1.0f;
        float _dragForce = 1.0f;
        Vector3 _velocity;
        Vector3 _force;
        Vector3 _netforce;
        public bool gravityEnabled;

        public Rigidbody(GameManager gameManager, GameObject owner) : base(gameManager, owner) { }

        public void ClearForce() { _force = Vector3.Zero; }
        public void AddForce(Vector3 force) { _force += force; }


        public override void Update(GameTime gameTime)
        {
            _velocity = (_force / _mass);
            gameObject.transform.position = _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            base.Update(gameTime);
        }

        private Vector3 CalculateDrag() 
        {
            Vector3 speedReduction = _dragForce * Vector3.One / (_mass * _velocity);
            return speedReduction;
        }
    } 
}
