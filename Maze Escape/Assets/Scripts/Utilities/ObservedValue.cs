using System;

public class ObservedValue<TValue>
{
    public event Action ValueChanged;
    private TValue m_Value;
    public TValue Value
    {
        get => m_Value;
        set
        {
            if (m_Value != null && m_Value.Equals(value)) return;

            m_Value = value;

            ValueChanged?.Invoke();
        }
    }


    public override string ToString()
    {
        return Value.ToString();
    }
}