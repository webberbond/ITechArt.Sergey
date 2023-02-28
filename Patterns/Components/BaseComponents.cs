namespace Patterns.Components;

public class BaseComponents
{
    public readonly Button BurgerMenu = new(By.Id("react-burger-menu-btn"), "burger menu");

    public readonly Button Logout = new(By.Id("logout_sidebar_link"), "logout");

    public readonly Label ItemName = new(By.ClassName("inventory_item_name"), "inventory item name");

    public readonly Label ItemPrice = new(By.ClassName("inventory_item_price"), "inventory item price");
}