namespace AlarmClock
{
	public sealed class ModeManager : IModeManager
	{
		private Mode _currentMode;

		public ModeManager()
		{
			SetMode(Mode.SET_TIME);
		}

		public Mode GetMode()
		{
			return _currentMode;
		}

		public void SetMode(Mode mode)
		{
			_currentMode = mode;
		}
	}
}