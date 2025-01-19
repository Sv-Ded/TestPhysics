using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string c_horizotal = "Horizontal";
    private const string c_vertical = "Vertical";

    public float HorizontalShift { get; private set; }
    public float VerticalShift { get; private set; }

    private void Update()
    {
        HorizontalShift = Input.GetAxis(c_horizotal);
        VerticalShift = Input.GetAxis(c_vertical);
    }
}
