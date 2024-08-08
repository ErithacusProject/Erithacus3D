using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erithacus3D.Engine
{
    //look at unity transform for ref
    //need to add functionality e.g. resetting forwards etc. local coordinates.
    public class Transform : Component
    {
        public Transform(Game sceneManager, GameObject owner) : base(sceneManager, owner) 
        { 
            position = Vector3.Zero;
            rotation = Quaternion.Identity;
            scale = Vector3.One;
            children = new List<GameObject>();
        }

        #region properties 
        GameObject parent;

        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

        List<GameObject> children;

        public int childcount 
        {
            get { return children.Count; }
            protected set { }
        }

        #endregion

    }
}
