using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IDoorOpener
{
    public bool canOpenDoor { get; set; }
    public UnityAction OnOpenedDoor { get; set; }
}
