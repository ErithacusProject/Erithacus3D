using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erithacus3D.Engine
{
    /// <summary>
    /// A class deriving from GameComponent, includes additional functionality
    /// </summary>
   public class Component : GameComponent
    {
        public Component(Game game, GameObject owner) : base(game) { gameObject = owner; }
        public Guid id { get; protected set; }
        public GameObject gameObject { get; protected set; }

        public override void Initialize()
        {
            base.Initialize();  
            id = Guid.NewGuid();
        }

        public static bool operator ==(Component a, Component b) { return a.id == b.id; }
        public static bool operator !=(Component a, Component b) { return a.id != b.id; }
    }
}
