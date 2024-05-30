
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Design.Behavior;
using System.Windows.Interactivity;

namespace askonUFA.Utilities
{
    public class TreeViewItemBehavior : Behavior<TreeView>
    {
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem",
                                        typeof(object),
                                        typeof(TreeViewItemBehavior),
                                        new FrameworkPropertyMetadata(null,
                                            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                            OnSelectedItemChanged));

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = d as TreeViewItemBehavior;
            if (behavior != null && behavior.AssociatedObject != null)
            {
                var treeView = behavior.AssociatedObject;
                treeView.SelectedItemChanged -= behavior.AssociatedObject_SelectItemChanged;

                var treeViewItem = treeView.ItemContainerGenerator.ContainerFromItem(e.NewValue) as TreeViewItem;
                if (treeViewItem != null)
                {
                    treeViewItem.IsSelected = true;
                }

                treeView.SelectedItemChanged += behavior.AssociatedObject_SelectItemChanged;
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectedItemChanged += AssociatedObject_SelectItemChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (AssociatedObject != null)
            {
                AssociatedObject.SelectedItemChanged -= AssociatedObject_SelectItemChanged;
            }
        }

        private void AssociatedObject_SelectItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedItem = e.NewValue;
        }
    }
}
