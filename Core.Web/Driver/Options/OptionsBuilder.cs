using OpenQA.Selenium.Chromium;

public class OptionsBuilder<T> where T : ChromiumOptions, new()
{
    public T _options = new T();

    public OptionsBuilder<T> AddArgument(string argument)
    {
        _options.AddArgument(argument);
        return this;
    }

    public OptionsBuilder<T> SetHeadless(bool isHeadless)
    {
        if (isHeadless)
        {
            _options.AddArgument("--headless");
        }
        return this;
    }

    public OptionsBuilder<T> DisableGpu()
    {
        _options.AddArgument("--disable-gpu");
        return this;
    }

    public OptionsBuilder<T> EnableIncognitoMode()
    {
        _options.AddArgument("--incognito");
        return this;
    }

    public OptionsBuilder<T> SetWindowSize(int width = 1920, int height = 1080)
    {
        _options.AddArgument($"--window-size={width},{height}");
        return this;
    }

    public T Build()
    {
        return _options;
    }
}
