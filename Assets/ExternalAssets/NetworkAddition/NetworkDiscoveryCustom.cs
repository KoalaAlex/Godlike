using UnityEngine.Networking;

namespace NetworkAdditional
{
    /// <summary>
    /// Custom implementation of the Unity Networking NetworkDiscovery class.
    /// This script auto-joins matches found in the local area network on discovery.
    /// </summary>
	public class NetworkDiscoveryCustom : NetworkDiscovery
    {
        public override void OnReceivedBroadcast(string fromAddress, string data)
        {
            StopBroadcast();

			NetworkLobbyManager.singleton.networkAddress = fromAddress;
			NetworkLobbyManager.singleton.StartClient();
        }
    }
}
