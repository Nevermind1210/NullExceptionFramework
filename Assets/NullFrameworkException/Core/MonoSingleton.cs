using System;
using UnityEngine;

namespace NullFrameworkException.Core
{
    // The '<ExampleSingleton>' is updating the 'TSingletonType' to be ExampleSingleton
    // public class ExampleSingleton : MonoSingleton<ExampleSingleton>
    
    public class MonoSingleton<TSingletonType> : MonoBehaviour
        where TSingletonType : MonoSingleton<TSingletonType> // This makes sure that SINGLETON_TYPE inherits from MonoSingleton
    {
        public static TSingletonType Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<TSingletonType>();
                    
                    // No instance was found, so throw a NullRefException detailing what singleton caused the error

                    if (instance == null)
                    {
                        // The 'typeof(TSingletonType).Name' shows the exact class name of generic type
                        throw new NullReferenceException($"No objects of type: {typeof(TSingletonType).Name}");
                    }
                }

                return instance;
            }
        }
        private static TSingletonType instance = null;
        /// <summary>
        /// Has the singleton been generated?
        /// </summary>
        /// <returns></returns>
        public static bool IsSingetonValid() => instance != null;

        /// <summary>
        /// Force the singleton instance to not be destroyed on scene load
        /// </summary>
        public static void FlagAsPersistant() => DontDestroyOnLoad((instance.gameObject));

        
        /// <summary>
        /// Finds
        /// </summary>
        /// <returns></returns>
        protected TSingletonType CreateInstance() => instance;
    }
}