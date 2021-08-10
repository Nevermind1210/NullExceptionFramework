using UnityEngine;

namespace NullFrameworkException.Mobile.InputHandling
{
    public class MobileInputManager : MonoBehaviour
    {
        public JoystickInputHandler joystick;

        private void Start()
        {
            joystick = FindObjectOfType<JoystickInputHandler>();
            joystick.SetUp(this);
        }

        private void Update()
        {
            joystick.Run();
        }
    }
}