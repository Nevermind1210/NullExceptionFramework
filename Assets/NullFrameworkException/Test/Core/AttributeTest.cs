using NullFrameworkException.Core;
using UnityEngine;

namespace NullFrameworkException.Test.Core
{
    public class AttributeTest : MonoBehaviour
    {
        [Tag, SerializeField] private string playerTag;
        [Tag, SerializeField] private string finishTag = "Finish";
    }
}