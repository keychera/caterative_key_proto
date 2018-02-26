using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Caterative.Brick.Balls;

namespace Caterative.Brick.Destroyable
{
    public abstract class Destroyable : MonoBehaviour
    {
        public bool active;
        
        void Start()
        {
            active = true;
        }

        public void Put(Vector3 position)
        {
            active = true;
            transform.position = position;
        }

        public void Destroy() {
            active = false;
            transform.position = Vector2.right * 1000;
            DestroyableManager.Instance.InvokeOnDestroyableDestroy(this);
        }
    }
}