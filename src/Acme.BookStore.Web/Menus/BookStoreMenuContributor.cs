using System.Threading.Tasks;
using Acme.BookStore.Localization;
using Acme.BookStore.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Acme.BookStore.Web.Menus;

public class BookStoreMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<BookStoreResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                BookStoreMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "bi bi-house-door-fill",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 11);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 12);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 13);

        context.Menu.AddItem(
            new ApplicationMenuItem(
                BookStoreMenus.Charts, 
                l["Menu:Charts"], 
                icon: "bi bi-columns-gap"
            )
            .AddItem(new ApplicationMenuItem(
                name: "MyProject.Crm.Customers",
                displayName: l["Menu:DataCharts"],
                icon: "bi bi-bar-chart-fill",
                url: "/Charts/DataCharts")
            )
        );

        return Task.CompletedTask;
    }
}
