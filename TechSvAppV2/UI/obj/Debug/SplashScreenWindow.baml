   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UIUI  5   	       UI.SplashScreenWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:UI     5   	     � Title$  SplashScreen��5       � WindowStartupLocation$ CenterScreen=�5   
    � ShowInTaskbar .   � AllowsTransparency .  � WindowStyle$
 None=�5   	   
������ $	��453��5   	   $	��281��6    � Cursor$
 Wait��5   	    � 	Resources 5         ShowStoryBoard �� TargetProperty �� 
TargetName<  6System.Windows.Media.Animation.EasingThicknessKeyFrame	 p� KeyTime
 p� Value  HideStoryBoard��%�  &	        &	 �     �� 5   
   .��5      r� $ (FrameworkElement.Margin)�6/   $ 
txtLoading��6e   .	�5        $	 0:0:0��6*   $
 0,0,0,0q�6:     5      $	 0:0:1��6*   $
 0,0,0,70q�6:   5      5      �� 5   
   .��5      r� $ (FrameworkElement.Margin)�6/   $ 
txtLoading��6e   .	�5        $	 0:0:0��6*   $
 0,0,0,70q�6:     5      $	 0:0:1��6*   $
 	0,0,0,150q�6:   5      5      5      .��5      � .+�5    
   � $��10q�6   ��5!      �� 5"       �� ImageSource$ SplashScreen.jpg��6    J� Effect 5$      3  -System.Windows.Media.Effects.DropShadowEffect  5%         Color$ #565656��6#      
BlurRadius$ 10Q�63      	Direction$ 1Q�6C      ShadowDepth$ 0Q�6Q   .+�5'      �� $��22,40,0,120q�6   .+�5(      �� $��	TechSvApp��6   
�������$��	30,30,0,0q�6@   $��Tahoma)�6S   $��36(�6g   �� 5)      $��preview v1.1��6   
�������$��100,0q�6C   $��Tahoma)�6R   $��18(�6f   5*      �� 5+      $��exline��6   ���#353535$��Tahoma)�6;   $��40(�6O   $��Right=�6^   $��10q�6z   $��Bottom=�6�   � 5,      $��	0,146,0,0q�6   .+�5-      �� -   5         ��Name$ 
txtLoading��5-      $��InitializeComponent��60    �� TextAlignment$
 Left=�6K   $��16(�6`   $��Normal"�6n   
�������$
��Wrap=�6�   $��Bottom=�6�   $��Right=�6�   $	��421��6�   $��2��6�    5.        5/      $ 6Q�6+   $ 	#FF797979��6:   $	 201Q�6L      Opacity$
 0.68Q�6\   $ 3Q�6k   51      52      53      55      57      