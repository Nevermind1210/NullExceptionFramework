using UnityEngine;

public class Cube : MonoBehaviour
{
    // This script just a basic script that helps me understand editor scripting.
    
    void Start()
    {
        GenerateColor();
    }

    /// <summary>
    ///  We generate the color
    /// </summary>
    public void GenerateColor()
    {
        GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV();
    }

    /// <summary>
    /// We reset the material color back to default 
    /// </summary>
    public void Reset()
    {
        GetComponent<Renderer>().sharedMaterial.color = Color.white;
    }
}
