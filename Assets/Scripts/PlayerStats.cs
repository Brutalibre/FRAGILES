using System;

namespace AssemblyCSharp
{
	public static class PlayerStats
	{
		private static int _score, _time;

		public static int Score {
			get {
				return _score;
			}

			set {
				_score = value;
			}
		}

		public static int Time {
			get {
				return _time;
			}

			set {
				_time = value;
			}
		}
	}
}

