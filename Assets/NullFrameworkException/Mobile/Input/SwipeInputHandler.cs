using System.Collections.Generic;
using NullFrameworkException.Core;
using UnityEngine;

namespace NullFrameworkException.Mobile.InputHandling
{
    public class SwipeInputHandler : RunnableBehaviour
    {
        public class Swipe
        {
            /// <summary>
            /// The lists of points along the swipe, added to each frame
            /// </summary>
            public readonly List<Vector2> positions = new List<Vector2>();
            /// <summary>
            /// The position the swipe started from.
            /// </summary>
            public readonly Vector2 initialPosition;
            /// <summary>
            /// The position the swipe started from.
            /// </summary>
            public readonly int fingerId;
      
            public Swipe(Vector2 _initialPosition, int _fingerId) 
            {
                initialPosition = _initialPosition;
                fingerId = _fingerId;
                positions.Add(_initialPosition); 
            }
        }

        /// <summary>
        /// The count of how many swipes are in progress
        /// </summary>
        public int SwipeCount => swipes.Count;
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<int, Swipe> swipes = new Dictionary<int, Swipe>();

        /// <summary>
        /// Attempts to retrieve the relevant swipe information relating to the passed ID
        /// </summary>
        /// <param name="_index"> The fingerID we are attempting to get the swipe for.</param>
        /// <returns>The corresponding</returns>
        public Swipe GetSwipe(int _index)
        {
            swipes.TryGetValue(_index, out Swipe swipe);
            return swipe;
        }

        protected override void OnSetup(params object[] _params)
        { }

        protected override void OnRun(params object[] _params)
        {
            if (Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        // This is the first frame this touch is detected, so put it in the dictionary
                        // as a swipe
                        swipes.Add(touch.fingerId, new Swipe(touch.position, touch.fingerId));
                    }
                    else if (touch.phase == TouchPhase.Moved && swipes.TryGetValue(touch.fingerId, out Swipe swipe))
                    {
                        swipe.positions.Add(touch.position);
                    }
                    else if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) &&
                             swipes.TryGetValue(touch.fingerId, out swipe))
                    {
                        swipes.Remove(swipe.fingerId);
                    }
                }
            }
        }
    }
}