   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:UI.View.ControlsUI.View.Controls  5      E AUIElements, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM5clr-namespace:UIElements.Controls;assembly=UIElementsUIElements.Controls 5      "    UI.View.Controls.PublicAlert   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:UI.View.Controls     5      JControls5clr-namespace:UIElements.Controls;assembly=UIElements     5      $	��158��5	      $	��323��6,     � 	Resources  5
         PublicAlertShow �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  PublicAlertHide��%�  &	        &	     �� 5   
   .��5      U� $ (UIElement.Opacity)�6,   $
 grid��6\   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:1��6'   $ 1Q�67     5      $ 0:0:4��6'   $ 1Q�67     5      $ 0:0:5��6'   $ 0Q�67   5      5      �� 5   
   .��5      U� $ (UIElement.Opacity)�6,   $
 grid��6\   .\�5        $ 0:0:1��6'   $ 0Q�67   5      5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      �� #��[  6   5      .��5      � -   5         �Name$
 grid��5      .+�5   
   �� $��5q�6   ��6%   �� *
Background+��6G   �� *BorderBrush+._�5       �� .+�5!      ��  �� Orientation$ 
Horizontal=�6   .+�5"      �� $��18(�6   
�������$��5q�6W   $��5q�6c   $	��280��6n   ��6*   �� *Title+6n   "  UIElements.Controls.ExButton  5#      -   5          NectAndBack#��[ 5#   (   
������ $��5q�6f   $��Right=�6q   $	��Top=�6�   $��0q�6�   $��15��6�   $��15��6�   	   Image$-	 '/UI;component/Resource/Images/Close.png��6�   
 J� RenderTransformOrigin$
 0.3,0.7&�6   6   5$      �� 5%      $ 
Horizontal=�6   .+�5&      �� $��90��6   $��90��6(   $��7q�63   ��6>   �� *Image+�� 5'      $��14(�6    
������� �� Padding$ 5q�6Z   $��5q�6f   $
��Wrap=�6q   $��Center=�6�   $	��204��6�   $	��100��6�   ��6.   �� *	Message+6�   5(      5)      5+      5,      5-      