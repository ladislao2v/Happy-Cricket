using System;
using UnityEngine;

namespace Code.Triggers
{
    public abstract class Trigger<TView> : MonoBehaviour where TView : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out TView view))
                InteractWith(view);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent(out TView view))
                InteractWith(view);
        }
        

        protected abstract void InteractWith(TView view);
    }
}
