using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class HpUdate : MonoBehaviour
{
    public UnityEvent m_MyEvent;
    public UnityEvent<int> m_Attacked;
    public int _damage;

    public void Awake()
    {

    }

    void Start()
    {
        if (m_MyEvent == null)
            m_MyEvent = new UnityEvent();

        m_MyEvent.AddListener(DoSomething);

        if (m_Attacked == null)
            m_Attacked = new UnityEvent<int>();
    }

    

    void Update()
    {
        if (Input.anyKeyDown && m_MyEvent != null)
        {
            m_MyEvent.Invoke();
        }
    }

    void DoSomething()
    {
        Debug.Log("Callback called");
    }

    public void OnCollisionEnter(Collision collision)
    {
        m_Attacked.Invoke(_damage);
    }
}
