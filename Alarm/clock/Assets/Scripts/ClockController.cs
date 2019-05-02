using AlarmClock;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockController : MonoBehaviour
{
	[SerializeField] private GameObject _basePanel;
	[SerializeField] private Text _alarmStatusText;
	[SerializeField] private Text _modeStatusText;
	[SerializeField] private Text _hour;
	[SerializeField] private Text _minute;
	[SerializeField] private AudioSource _audioSource;
	[SerializeField] private GameObject _snoozeButton;

	[SerializeField] private Button _incrementHourButton;
	[SerializeField] private Button _incrementMinuteButton;

	private IClock _clock;
	private bool alarmOn = true;
	private bool isAlarmMode = true;

	private static ThreadDispatcher _threadDispatcher;

	private void Start()
	{
		_basePanel.SetActive(true);
		_threadDispatcher = new ThreadDispatcher();
		_clock = new Clock(new UnityAlarm(_audioSource, _snoozeButton), new UnityDisplay(_hour, _minute));
		_clock.Start();
		ToggleAlarm();
		ToggleMode();
	}

	private void Update()
	{
		_threadDispatcher?.Update();
	}

	public void IncrementHour()
	{
		_clock.ButtonManager.DoIncrementHour();
	}

	public void IncrementMinute()
	{
		_clock.ButtonManager.DoIncrementMinute();
	}

	public void Snooze()
	{
		_clock.ButtonManager.DoSnooze();
	}

	public void ToggleAlarm()
	{
		var status = !alarmOn;
		if (status)
		{
			_clock.ButtonManager.DoAlarmOn();
		}
		else
		{
			_clock.ButtonManager.DoAlarmOff();
		}

		ChangeAlarmStatus(status);
	}

	public void ToggleMode()
	{
		isAlarmMode = !isAlarmMode;
		_modeStatusText.text = isAlarmMode ? "Current Mode - Set Alarm" : "Current Mode - Set Time";
		if (isAlarmMode)
		{
			_clock.ButtonManager.DoSetAlarm();
		}
		else
		{
			_clock.ButtonManager.DoSetTime();
		}
		ChangeAlarmStatus(false);
	}

	private void ChangeAlarmStatus(bool status)
	{
		alarmOn = status;
		//_incrementHourButton.gameObject.SetActive(alarmOn);
		//_incrementMinuteButton.gameObject.SetActive(alarmOn);
		_alarmStatusText.text = alarmOn ? "Alarm status on" : "Alarm status off";
	}

	class UnityAlarm : IAlarm
	{
		private readonly AudioSource _audioSource;
		private readonly GameObject _snoozeButton;

		public UnityAlarm(AudioSource audioSource, GameObject snoozeButton)
		{
			_audioSource = audioSource;
			_snoozeButton = snoozeButton;
		}

		public void Off()
		{
			_threadDispatcher.RunOnMainThread(() =>
			{
				_snoozeButton.SetActive(false);
				_audioSource.Stop();
			});
		}

		public void On()
		{
			_threadDispatcher.RunOnMainThread(() =>
			{
				_snoozeButton.SetActive(true);
				_audioSource.Play();
			});
		}
	}

	class UnityDisplay : IDisplay
	{
		private Text _hour;
		private Text _minute;

		public UnityDisplay(Text hour, Text minute)
		{
			_hour = hour;
			_minute = minute;
		}

		public void ShowHour(int hour)
		{
			_threadDispatcher.RunOnMainThread(() => _hour.text = "" + hour);
		}

		public void ShowMinute(int minute)
		{
			_threadDispatcher.RunOnMainThread(() => _minute.text = minute.ToString("00"));
		}
	}

	class ThreadDispatcher
	{
		public List<Action> _actions;

		public ThreadDispatcher()
		{
			_actions = new List<Action>();
		}

		public void RunOnMainThread(Action action)
		{
			lock (_actions)
			{
				_actions.Add(action);
			}
		}

		public void Update()
		{
			foreach(var item in _actions)
			{
				item?.Invoke();
			}
			_actions.Clear();
		}
	}
}