using System.Collections;
using UnityEngine;

public abstract class Pausable : MonoBehaviour
{
    public abstract void Finish();
    public abstract IEnumerator Resume();
}
