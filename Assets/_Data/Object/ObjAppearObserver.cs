using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOAppearObserver
{
    public abstract void OnAppearStart();

    public abstract void OnAppearFinish();
}