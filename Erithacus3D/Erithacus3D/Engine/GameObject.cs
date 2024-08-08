using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erithacus3D.Engine
{
    public class GameObject 
    {
        public string name;
        public string tag;
        public Transform transform;
        public Guid id;
        public bool active { get; protected set; }
       

        private List<GameComponent> components;
        public GameManager game;

        public GameObject(GameManager _game)
        {
            id = Guid.NewGuid();
            game = _game;
            components = new List<GameComponent>();
            transform = new Transform(_game, this);
            _game.AddGameObject(this);
        }
        
        /// <summary>
        /// sets the activity status of the gameobject and all of its child components
        /// </summary>
        public void SetActive(bool active) 
        { 
            foreach (Component comp in components)
            {
                comp.Enabled = active;
            }
        
        }

        #region Component controllers
        public T GetComponent<T>() where T : Component
        {
            foreach (Component comp in components)
            {
                if (comp is T)
                {
                    return comp as T;
                }
            }
            return null;
        }

        /// <summary>
        /// creates a component and sets its default values, to make it specific
        /// the specific initializer for the class will need to be called.
        /// </summary>
        public T AddComponent<T>() where T : Component
        {
            T component = (T)Activator.CreateInstance(typeof(T));
            components.Add(component);
            component.Initialize();
            return component;
        }

        /// <summary>
        /// removes a component from a gameobject
        /// </summary>
        public void RemoveComponent(Component component)
        {
            foreach (Component comp in components)
            {
                if (comp == component)
                {
                    components.Remove(comp);
                }
            }
        }

        #endregion

        /// <summary>
        /// destorys a game object and all components associated with it
        /// </summary>
        public void Dispose()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Dispose();
            }
            components.Clear();
            game.RemoveGameObject(this);
        }

        public static bool operator ==(GameObject a, GameObject b) { return a.id == b.id; }
        public static bool operator !=(GameObject a, GameObject b) { return a.id != b.id; }
    }
}
