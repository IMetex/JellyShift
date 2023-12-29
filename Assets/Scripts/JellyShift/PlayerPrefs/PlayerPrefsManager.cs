namespace JellyShift.PlayerPrefs
{
	public abstract class PlayerPrefsManager
	{
		private const string DiamondScorePrefsString = "DiamondScore";
		private const string HapticKey = "IsHapticOn";
		private const string SoundKey = "IsSoundOn";
		

		public static int DiamondScore
		{
			get
			{
				return UnityEngine.PlayerPrefs.GetInt(DiamondScorePrefsString);
			}
			set
			{
				UnityEngine.PlayerPrefs.SetInt(DiamondScorePrefsString, value);
			}
		}

		public static bool IsHapticOn
		{
			get
			{
				if (UnityEngine.PlayerPrefs.HasKey(HapticKey))
				{
					return bool.Parse(UnityEngine.PlayerPrefs.GetString(HapticKey));
				}
				return true;
			}
			set => UnityEngine.PlayerPrefs.SetString(HapticKey, value.ToString());
		}
		
		public static bool IsSoundOn
		{
			get
			{
				if (UnityEngine.PlayerPrefs.HasKey(SoundKey))
				{
					return bool.Parse(UnityEngine.PlayerPrefs.GetString(SoundKey));
				}
				return true;
			}
			set => UnityEngine.PlayerPrefs.SetString(SoundKey, value.ToString());
		}
	}
}

