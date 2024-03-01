using System.Security.RightsManagement;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KMA.Lab1_Hrynchuk.Lab1_Hrynchuk
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DateTime selectedDate = datePicker.SelectedDate ?? DateTime.Now;

            int userAge = CalcUserAge(selectedDate);
            bool isValid = UserAgeValidation(userAge, selectedDate);

            if (isValid)
            {
                userAgeField.Text = $"You are {userAge} years old!";
                userWestZodiac.Text = $"You are {CalcUserWestZodiacSign(selectedDate)} by West Zodiac system!";
                userChineseZodiac.Text = $"You are {CalcUserChineseZodiacSign(selectedDate)} by Chinese Zodiac system!";
                IsTodayBirthDay(userAge, selectedDate);
            }
            else
            {
                userAgeField.Text = "";
                userWestZodiac.Text = "";
                userChineseZodiac.Text = "";
            }
        }

        private int CalcUserAge(DateTime userBDate)
        {
            int userAge;
            DateTime currentDate = DateTime.Now;
            userAge = currentDate.Year - userBDate.Year;
            if (currentDate.Month < userBDate.Month || (currentDate.Month == userBDate.Month && currentDate.Day < userBDate.Day))
            {
                userAge--;
            }
            return userAge;
        }

        private void IsTodayBirthDay(int userAge, DateTime userBDate)
        {
            DateTime currentDate = DateTime.Now;
            if (userBDate.Day == currentDate.Day && userBDate.Month == currentDate.Month)
            {
                MessageBox.Show($"Today you turned {userAge} years old.\n Congratulations! We wish you all the best!", "Happy Birthday!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool UserAgeValidation(int userAge, DateTime userBDate)
        {

            if (userAge < 0)
            {
                MessageBox.Show($"Selected Date: {userBDate.ToShortDateString()} is wrong! \n You are not born yet!", "Wrong Date of Birth", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (userAge > 135)
            {
                MessageBox.Show($"Selected Date: {userBDate.ToShortDateString()} is wrong \n or you over 135 years old which is not possible!", "Wrong Date of Birth", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private string CalcUserWestZodiacSign(DateTime userBDate)
        {
            int userDayOfBirth = userBDate.Day;
            int userMonthOfBirth = userBDate.Month;

            switch (userMonthOfBirth)
            {
                case 1:
                    return (userDayOfBirth >= 20) ? "Aquarius" : "Capricorn";
                case 2:
                    return (userDayOfBirth >= 19) ? "Pisces" : "Aquarius";
                case 3:
                    return (userDayOfBirth >= 21) ? "Aries" : "Pisces";
                case 4:
                    return (userDayOfBirth >= 20) ? "Taurus" : "Aries";
                case 5:
                    return (userDayOfBirth >= 21) ? "Gemini" : "Taurus";
                case 6:
                    return (userDayOfBirth >= 21) ? "Cancer" : "Gemini";
                case 7:
                    return (userDayOfBirth >= 23) ? "Leo" : "Cancer";
                case 8:
                    return (userDayOfBirth >= 23) ? "Virgo" : "Leo";
                case 9:
                    return (userDayOfBirth >= 23) ? "Libra" : "Virgo";
                case 10:
                    return (userDayOfBirth >= 23) ? "Scorpio" : "Libra";
                case 11:
                    return (userDayOfBirth >= 22) ? "Sagittarius" : "Scorpio";
                case 12:
                    return (userDayOfBirth >= 22) ? "Capricorn" : "Sagittarius";
                default:
                    return "Unknown";
            }
        }


        //Chinese new year begins almost randomly from 21 Jan to 21 Feb so if the user have DoB on this part of year i just return two possible zodiacs
        private string CalcUserChineseZodiacSign(DateTime userBDate)
        {
            int userDayOfBirth = userBDate.Day;
            int userMonthOfBirth = userBDate.Month;
            int userYearOfBirth = userBDate.Year % 12;

            switch (userYearOfBirth)
            {
                case 0:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Goat" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <=21 && userMonthOfBirth == 2)) ? "Goat or Monkey" : "Monkey";
                case 1:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Monkey" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Monkey or Rooster" : "Rooster";
                case 2:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Rooster" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Rooster or Dog" : "Dog";
                case 3:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Dog" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Dog or Pig" : "Pig";
                case 4:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Pig" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Pig or Rat" : "Rat";
                case 5:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Rat" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Rat or Ox" : "Ox";
                case 6:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Ox" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Ox or Tiger" : "Tiger";
                case 7:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Tiger" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Tiger or Rabbit" : "Rabbit";
                case 8:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Rabbit" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Rabbit or Dragon" : "Dragon";
                case 9:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Dragon" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Dragon or Snake" : "Snake";
                case 10:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Snake" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Snake or Horse" : "Horse";
                case 11:
                    return (userDayOfBirth < 21 && userMonthOfBirth == 1) ? "Horse" : ((userDayOfBirth >= 21 && userMonthOfBirth == 1) || (userDayOfBirth <= 21 && userMonthOfBirth == 2)) ? "Horse or Goat" : "Goat";
                default:
                    return "Unknown";
            }
        }

    }
}