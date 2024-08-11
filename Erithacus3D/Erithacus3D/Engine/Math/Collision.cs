using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erithacus3D.Engine.Math
{
    enum ColliderType
    { 
        //AABB, //axis aligned bounding box
        OBB, //oriented bouding box
        Sphere, //Sphere collision
        //capsule
    }


    public class Collision : Component
    {
        public Collision(GameManager gameManager, GameObject owner) : base(gameManager, owner) { transform = gameObject.transform; }
        Transform transform;

        static bool AABBAABBCollision(AABBCollider collider1, AABBCollider collider2)
        {
            return false;
        }

        static bool SphereSphereCollision(SphereCollider collider1, SphereCollider collider2)
        {
            return false;
        }

        static bool AABBSphereCollision(AABBCollider collider1, SphereCollider collider2)
        {
            return false;
        }
    }

    public class AABBCollider : Collision
    {
        AABBCollider(GameManager gameManager, GameObject owner) : base(gameManager, owner) { }
    }

    public class SphereCollider : Collision
    {
        SphereCollider(GameManager gameManager, GameObject owner) : base(gameManager, owner) { }
    }


}
