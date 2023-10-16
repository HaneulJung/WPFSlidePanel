using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFSlidePanel.Commands;

namespace WPFSlidePanel.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
		private bool _isSignupModalOpen;        

		public bool IsSignupModalOpen
        {
			get { return _isSignupModalOpen; }
			set { _isSignupModalOpen = value; OnPropertyChanged(nameof(IsSignupModalOpen)); }
		}

        public ICommand SignupCommand => new RelayCommand(_ => IsSignupModalOpen = true);
        public ICommand SignupSubmitCommand => new RelayCommand(_ => IsSignupModalOpen = false);

    }
}
