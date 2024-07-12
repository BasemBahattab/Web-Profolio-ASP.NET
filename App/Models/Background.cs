namespace Profolio_ASP.NET_MVC.Models
{
    public class Background
    {

        private static string BACKGROUND_IMG = "/Images/Background/Background-night.png";

        public static string  getBackground()
        {
            DateTime dt = DateTime.Now;

            TimeSpan start = new TimeSpan(6, 0, 0); // 6:00 AM
            TimeSpan end = new TimeSpan(18, 0, 0);  // 6:00 PM
            TimeSpan now = dt.TimeOfDay;
            if (now >= start && now <= end)
            {
                BACKGROUND_IMG = "/Images/Background/Background-day.png";
            }

            return BACKGROUND_IMG;
        }
    }
}
