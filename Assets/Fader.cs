using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public sealed class Fader : MonoBehaviour
{
    [SerializeField] UnityEvent<float>[] _targets = null;

    KeyControl[][] _controls;

    void TrySetUp()
    {
        if (_controls != null) return;
        if (Keyboard.current == null) return;

        var k = Keyboard.current;

        _controls = new KeyControl[4][];
        _controls[0] = new[]{ k.digit1Key, k.digit2Key, k.digit3Key, k.digit4Key, k.digit5Key };
        _controls[1] = new[]{ k.qKey, k.wKey, k.eKey, k.rKey, k.tKey };
        _controls[2] = new[]{ k.aKey, k.sKey, k.dKey, k.fKey, k.gKey };
        _controls[3] = new[]{ k.zKey, k.xKey, k.cKey, k.vKey, k.bKey };
    }

    void Start()
      => TrySetUp();

    void Update()
    {
        TrySetUp();

        for (var row = 0; row < 4; row++)
        {
            for (var i = 4; i >= 0; i--)
            {
                if (_controls[row][i].wasPressedThisFrame)
                {
                    _targets[row].Invoke((float)i / 4);
                    break;
                }
            }
        }
    }
}
