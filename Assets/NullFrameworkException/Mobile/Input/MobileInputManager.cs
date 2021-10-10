using NullFrameworkException.Mobile.InputHandling;
using UnityEngine;

namespace NullFrameworkException.Mobile.Input
{
    public class MobileInputManager : MonoBehaviour
    {
        public JoystickInputHandler joystick;
        public SwipeInputHandler swiping;

        //public static Vector2 GetJoystickAxis() => Instance.joystick != null ? Instance.joystick.Axis : Vector2.zero;
        
        private void Start()
        {
            RunnableUtils.Setup(ref joystick, gameObject, true, this);
            RunnableUtils.Setup(ref swiping, gameObject, true);
        }

        private void Update()
        {
            joystick.Run(joystick, gameObject, true);
            joystick.Run(swiping, gameObject, true);
        }
    }
}