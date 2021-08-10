using System;
using UnityEngine;

namespace NullFrameworkException
{
    public abstract class RunnableBehaviour : MonoBehaviour, IRunnable

    {
        public bool Enabled { get; set; } = true;

        private bool isSetup = false;

        public void SetUp(params object[] _params)
        {
            // If the runnable is already steup, throw an exception as warn
            if (isSetup)
            {
                throw new InvalidOperationException($"GameObject {gameObject.name} already setup!");
            }

            // Run the OnSetup function and flag this component as setup
            OnSetup(_params);
            isSetup = true;
        }

        public void Run(params object[] _params)
        {
            // If the runnable is enabled and setup, run its OnRun function with the passed value;
            if (Enabled && isSetup)
            {
                OnRun(_params);
            }
        }
        protected abstract void OnSetup(params object[] _params);
        protected abstract void OnRun(params object[] _params);
    }
}