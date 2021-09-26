using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Behaviors
{
    public class TreeViewBehaviors : Behavior<TreeView>
    {
        //Обьект выделенный в TreeView
        public object TreeSelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("TreeSelectedItem", typeof(object), typeof(TreeViewBehaviors), new UIPropertyMetadata(null, OnSelectedItemChanged));

        //Обработчик события изменения выделенного объекта TreeView
        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var item = d as TreeViewItem;
            if (item != null)
                item.SetValue(TreeViewItem.IsSelectedProperty, true);
        }


        //Переопределяем что бы при бинденге подписаться на событие изменения выдленного обьекта
        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.SelectedItemChanged += OnTreeViewSelectedItemChanged;
        }

        //При отвязке удаляем подпись на событие изменения выделенного обьекта
        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (this.AssociatedObject != null)
            {
                this.AssociatedObject.SelectedItemChanged -= OnTreeViewSelectedItemChanged;
            }
        }

        //Обработчик собтия изменения выделенного обьекта.
        private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.TreeSelectedItem = e.NewValue;
        }
    }
}
