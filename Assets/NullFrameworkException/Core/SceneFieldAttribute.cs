using UnityEngine;

namespace NullFrameworkException.Core
{
    public class SceneFieldAttribute : MonoBehaviour
    {
        /// <summary>
        /// Converts a full filepath to a sceneManger 
        /// </summary>
        /// <param name="_path"></param>
        /// <returns></returns>
        public static string LoadableName(string _path)
        {
            // The pieces of the path we are looking to ignore
            string start = "Assets/";
            string end = ".unity";

            // Test if the path contains 'start' data, if so, remove it!
            if (_path.StartsWith(start))
                _path = _path.Substring(start.Length);

            // Tests if the path contains 'end' data, if so, remove it
            if (_path.EndsWith(end))
                //ReSharper disable once StringLastIndexOfIsCultureSpecific.1
                _path = _path.Substring(0, _path.LastIndexOf(end));
            
            // Return the newly edited path
            return _path;
        }
        
        /// <summary>
        /// Takes a local folder path and converts it into an assets path.
        /// </summary>
        /// <param name="_path">a local path. </param>
        /// <returns></returns>
        public static string ToAssetPath(string _path) => $"Assets/{_path}.unity";
    }
}