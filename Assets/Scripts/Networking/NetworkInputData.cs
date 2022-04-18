using UnityEngine;
using Fusion;

namespace Networking
{
    public struct NetworkInputData : INetworkInput
    {
        public Vector2 Direction;
        public NetworkBool IsSprint;
    }
}
