using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caterative.Brick.Destroyable
{
    public class DestroyableManager : Singleton<DestroyableManager>
    {
        public delegate void DestroyableEvent(Destroyable whichDestroyable);
        public static event DestroyableEvent OnDestroyableDestroy;

        public void InvokeOnDestroyableDestroy(Destroyable destroyable)
        {
            if (OnDestroyableDestroy != null)
            {
                OnDestroyableDestroy(GetClosestDestroyable());
            }
        }

        public Destroyable GetClosestDestroyable()
        {
            Destroyable[] allDestroyables = GetActiveDestroyable();
            Destroyable closestDestroyable = null;
            if (allDestroyables.Length > 0)
            {
                closestDestroyable = allDestroyables[0];
                for (int i = 1; i < allDestroyables.Length; i++)
                {
                    if (allDestroyables[i].transform.position.y < closestDestroyable.transform.position.y)
                    {
                        closestDestroyable = allDestroyables[i];
                    }
                }
            }
            return closestDestroyable;
        }

        private Destroyable[] GetActiveDestroyable()
        {
            var allDestroyables = new List<Destroyable>(FindObjectsOfType<Destroyable>());
            for (int i = allDestroyables.Count - 1; i >= 0; i--)
            {
                if (!allDestroyables[i].active)
                {
                    allDestroyables.RemoveAt(i);
                }
            }
            return allDestroyables.ToArray();
        }
    }
}