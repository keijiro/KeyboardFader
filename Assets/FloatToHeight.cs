using UnityEngine;

public sealed class FloatToHeight : MonoBehaviour
{
    public float Height { set => SetHeight(value); }

    void SetHeight(float height)
      => transform.localPosition = Vector3.up * height;
}
