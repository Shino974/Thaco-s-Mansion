using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class TouchscreenInput : MonoBehaviour
{
    public UnityEvent<Vector2> MoveEvent;
    public UnityEvent<Vector2> LookEvent;
    public UnityEvent<bool> JumpEvent;
    public UnityEvent<bool> SprintEvent;
    
    private UIDocument m_Document;

    private VirtualJoystick m_MoveJoystick;
    private VirtualJoystick m_LookJoystick;

    private void Awake()
    {
        m_Document = GetComponent<UIDocument>();
    }

    private void Start()
    {
        var joystickMove = m_Document.rootVisualElement.Q<VisualElement>("JoystickMove");
        var joystickLook = m_Document.rootVisualElement.Q<VisualElement>("JoystickLook");
        
        m_MoveJoystick = new VirtualJoystick(joystickMove);
        m_MoveJoystick.JoystickEvent.AddListener(mov =>
        {
            MoveEvent.Invoke(mov);
        });;
        
        m_LookJoystick = new VirtualJoystick(joystickLook);
        m_LookJoystick.JoystickEvent.AddListener(mov =>
        {
            LookEvent.Invoke(mov);
        });

        var jumpButton = m_Document.rootVisualElement.Q<VisualElement>("ButtonJump");
        jumpButton.RegisterCallback<PointerDownEvent>(evt => { JumpEvent.Invoke(true); });
        jumpButton.RegisterCallback<PointerUpEvent>(evt => { JumpEvent.Invoke(false); });
        
        var sprintButton = m_Document.rootVisualElement.Q<VisualElement>("ButtonSprint");
        sprintButton.RegisterCallback<PointerDownEvent>(evt => { SprintEvent.Invoke(true); });
        sprintButton.RegisterCallback<PointerUpEvent>(evt => { SprintEvent.Invoke(false); });
    }
}
public class VirtualJoystick
{
    public VisualElement BaseElement;
    public VisualElement Thumbstick;

    public UnityEvent<Vector2> JoystickEvent = new();

    public VirtualJoystick(VisualElement root)
    {
        BaseElement = root;
        Thumbstick = root.Q<VisualElement>("JoystickHandle");
            
        BaseElement.RegisterCallback<PointerDownEvent>(HandlePress);
        BaseElement.RegisterCallback<PointerMoveEvent>(HandleDrag);
        BaseElement.RegisterCallback<PointerUpEvent>(HandleRelease);
    }

    void HandlePress(PointerDownEvent evt)
    {
        BaseElement.CapturePointer(evt.pointerId);
    }

    void HandleRelease(PointerUpEvent evt)
    {
        BaseElement.ReleasePointer(evt.pointerId);
            
        Thumbstick.style.left = Length.Percent(50);
        Thumbstick.style.top = Length.Percent(50);
        
        JoystickEvent.Invoke(Vector2.zero);
    }

    void HandleDrag(PointerMoveEvent evt)
    {
        if (!BaseElement.HasPointerCapture(evt.pointerId)) return;
            
        var width = BaseElement.contentRect.width;
        var center = new Vector3(width / 2, width / 2);
        var centerToPosition = evt.localPosition - center;

        if (centerToPosition.magnitude > width/2)
        {
            centerToPosition = centerToPosition.normalized * width / 2;
        }

        var newPos = center + centerToPosition;

        Thumbstick.style.left = newPos.x;
        Thumbstick.style.top = newPos.y;

        centerToPosition /= (width / 2);
        //we invert y as the y of UI goes down, but pushing the joystick up is expected to give a positive y value
        centerToPosition.y *= -1;
        
        JoystickEvent.Invoke(centerToPosition);
    }
}