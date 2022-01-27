using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayerV2 : MonoBehaviour
{
    TestInputPlayer controls;

    public Camera camera;

    [SerializeField]
    private Vector2 _move;

    [SerializeField]
    private Vector2 _rotate;

    private void Awake()
    {
        controls = new TestInputPlayer();

        controls.Gameplay.Move.performed += ctx => _move = ctx.ReadValue<Vector2>();

        controls.Gameplay.Move.canceled += ctx => _move = Vector2.zero;

        controls.Gameplay.Look.performed += ctx => _rotate = ctx.ReadValue<Vector2>();

        controls.Gameplay.Look.canceled += ctx => _rotate = Vector2.zero;
    }

    private void Update()
    {
        Vector2 m = new Vector2(_move.x, _move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);

        Vector2 r = new Vector2(_rotate.x, _rotate.y) * Time.deltaTime;
        camera.transform.localEulerAngles = new Vector3(r.x, r.y, 0);
    }
    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
