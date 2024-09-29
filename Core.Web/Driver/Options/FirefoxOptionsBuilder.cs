namespace Core.Web.Driver.Options
{
    public class FirefoxOptionsBuilder
    {
        public FirefoxOptionsBuilder()
        {
            throw new NotImplementedException("For some reason FireFoxOptions" +
                " directly inherits from DriverOptions instead of ChromiumOptions," +
                " so rework for current approach is needed");
        }
    }
}
