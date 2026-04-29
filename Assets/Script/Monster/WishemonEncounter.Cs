using UnityEngine;

    [System.Serializable]
    public class WishemonEncounter
    {
        public WishemonData Wishemon;
        [Range(0f, 100f)] public float Chance;
    }