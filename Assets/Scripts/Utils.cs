using UnityEngine;

namespace Utils
{
    public enum UnitKind
    {
        Policy,
        Fireman,
        Doctor
    }

    public enum EventKind
    {
        PolicyEvent,
        FiremanEvent,
        DoctorEvent
    }

    public enum State
    {
        Available,
        Used,
    }

    public static class Functions
    {
        public static int randomInt(int maxValue)
        {
            return Random.Range(0, maxValue - 1);
        }
    }
}

