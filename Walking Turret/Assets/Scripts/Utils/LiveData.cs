
using System;
using System.Collections.Generic;

public class LiveData<T>
{
    private List<Action<T>> observers = new List<Action<T>>();

    private T value;
    public T Value {
        get { return value; }
        set {
            for (int i = 0; i < observers.Count; i++) {
                observers[i](value);
            }
            this.value = value;
        }
    }

    public LiveData(T value) {
        this.Value = value;
    }

    public void Observe(Action<T> observer) {
        observers.Add(observer);
    }
}
