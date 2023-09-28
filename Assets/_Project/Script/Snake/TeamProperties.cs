using UnityEngine;
using System;

namespace SnakeGame
{
    public enum Team
    {
        Motu = 0,
        Patlu = 1
    }

    [Serializable]
    public struct TeamProperties
	{
        public Team team;
        public Transform spawnPoint;
        public InputKeyConfig keyConfig;
        public Color color;
    }
}
