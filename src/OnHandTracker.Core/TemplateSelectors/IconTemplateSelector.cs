using System.Windows;
using System.Windows.Controls;

namespace OnHandTracker.Core.TemplateSelectors
{
    public class IconTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Icons icon)
            {
                return icon switch
                {
                    Icons.Settings => Application.Current.FindResource("SettingsIcon") as System.Windows.DataTemplate,
                    _ => null
                };
            }

            return null;
        }
    }
}