#region

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Hearthstone_Deck_Tracker.Annotations;

#endregion

namespace Hearthstone_Deck_Tracker.Controls.Overlay
{
	public partial class WotogIcons : INotifyPropertyChanged
	{
		private bool _forceShow;
		private string _attack = "6";
		private string _health = "6";
		private string _spells = "0";
		private WotogIconsStyle _wotogIconsStyle;


		public WotogIcons()
		{
			InitializeComponent();
		}

		public string Attack
		{
			get { return _attack; }
			set
			{
				if(value == _attack)
					return;
				_attack = value;
				OnPropertyChanged();
			}
		}

		public string Health
		{
			get { return _health; }
			set
			{
				if(value == _health)
					return;
				_health = value;
				OnPropertyChanged();
			}
		}

		public string Spells
		{
			get { return _spells; }
			set
			{
				if(value == _spells)
					return;
				_spells = value;
				OnPropertyChanged();
			}
		}

		public WotogIconsStyle WotogIconsStyle
		{
			get { return _wotogIconsStyle; }
			set
			{
				if(value == _wotogIconsStyle)
					return;
				_wotogIconsStyle = value;
				OnPropertyChanged(nameof(CthunVisibility));
				OnPropertyChanged(nameof(SpellsVisibility));
				OnPropertyChanged(nameof(FullVisibility));
				OnPropertyChanged(nameof(IconWidth));
			}
		}

		public int IconWidth => WotogIconsStyle == WotogIconsStyle.Full ? 226 : 145;
		public Visibility CthunVisibility => _forceShow || WotogIconsStyle == WotogIconsStyle.Cthun ? Visibility.Visible : Visibility.Collapsed;
		public Visibility SpellsVisibility => !_forceShow && WotogIconsStyle == WotogIconsStyle.Spells ? Visibility.Visible : Visibility.Collapsed;
		public Visibility FullVisibility => !_forceShow && WotogIconsStyle == WotogIconsStyle.Full ? Visibility.Visible : Visibility.Collapsed;

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void ForceShow(bool force)
		{
			_forceShow = force;
			OnPropertyChanged(nameof(CthunVisibility));
			OnPropertyChanged(nameof(SpellsVisibility));
			OnPropertyChanged(nameof(FullVisibility));
		}
	}

	public enum WotogIconsStyle
	{
		Full,
		Cthun,
		Spells
	}
}