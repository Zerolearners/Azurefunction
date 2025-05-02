using System.Text.RegularExpressions;
using ai_finder_be_schedulers_donetcore.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ai_finder_be_schedulers_donetcore.Common;

public class AddDependency
{
    public void AddDependencies(IServiceCollection services, FinderSetting finderSetting, MailSetting mailSetting)
    {
        services.AddSingleton(finderSetting);
        services.AddSingleton(mailSetting);
        services.AddScoped<IMatches, Matches>();
    }
}
