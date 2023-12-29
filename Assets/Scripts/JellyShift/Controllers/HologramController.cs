using UnityEngine;

namespace JellyShift.Controllers
{
	public class HologramController : MonoBehaviour
	{
		public GameObject playerCopy;
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Collider1"))
			{
				playerCopy.gameObject.SetActive(true);
			}
			else if (other.gameObject.CompareTag("Collider2"))
			{
				playerCopy.gameObject.SetActive(true);
			}
			else if (other.gameObject.CompareTag("Collider3"))
			{
				playerCopy.gameObject.SetActive(true);
			}
			else if (other.gameObject.CompareTag("Collider4"))
			{
				playerCopy.gameObject.SetActive(true);
			}
		}
	}
}

