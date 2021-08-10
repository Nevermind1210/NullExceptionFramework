using System;
using UnityEngine;

namespace NullFrameworkException.Test.Core
{
    public class CoreTesting : MonoBehaviour
    {
        public Transform cube;
        
        public RunnableTest runnableTest;

        private void Start()
        {
            RunnableUtils.Setup(ref runnableTest, gameObject, cube, 1f, Vector3.up);
        }

        private void Update()
        {
            RunnableUtils.Run(ref runnableTest, gameObject, Input.GetKey(KeyCode.Space));
        }
    }
}