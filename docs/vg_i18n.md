## i18n

In this project, we decided to use internationalization to reach younger people in more countries. In ConfigureServices we used AddLocaliztion and then Configure<RequestLocalizationOptions> to populate a List<CultureInfo> with supported languages. Also, to set the DefaultRequestCulture to English.

![i18n3](img\i18n3.PNG)

In Configure we added the app.UseRequestLocalization.

#### Views

For every View, we created one resource-file per language supported to hold all translated text. We also implemented some code to reach the IViewLocalizer:

```c#
@using Microsoft.AspNetCore.Mvc.Localization
@inject IViewLocalizer localizer
```

We could then call the @localizer to get what we wanted:

```c#
@localizer["Title"]
@localizer["Play Ludo"]
```

And here are some screen shots of the actual web app, in the Manual section:

![i18n1](img\i18n1.PNG)

![i18n2](img\i18n2.PNG)