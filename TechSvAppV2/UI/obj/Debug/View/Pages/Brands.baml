   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UI.View.PagesUI.View.Pages  5      3clr-namespace:UI.View.ControlsUI.View.Controls  5      E AUIElements, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM5clr-namespace:UIElements.Controls;assembly=UIElementsUIElements.Controls 5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	          UI.View.Pages.Brands   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:UI.View.Pages     5      3Controlsclr-namespace:UI.View.Controls     5      L
UIElements5clr-namespace:UIElements.Controls;assembly=UIElements     5      jInteractivityPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	        N� Title$  	Dashboard��5
      $��Center=�5      $	��Top=�6$   .��5      � .+�5   
   �� .+�5      9� $
��Yeni��6    9� 
IsExpanded . .��5      � .+�5      �� -   5         ��Name$ 
stackPanel��5   !    �� Orientation$ 
Horizontal=�65   $��Center=�6N   .+�5      �� .+�5      �� $ 
Horizontal=�6)   $��2q�6B   .+�5   "   #  UIElements.Controls.ExTextBox  -   5        $
��name��5   j      TextBoxBaseStyle#��[  67   
 � Tag$ AD��6a    �� 	MaxLength$ 20��6v     validationErrorTemplate =� ErrorTemplate# [ 6�   $	��353��67  ��6�   �� *Model.Model.Ad+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . 	 �� UpdateSourceTrigger$	 PropertyChanged=�67  5      �� 5      $ 
Horizontal=�6)   $��2q�6B   �� 5      $ 
Horizontal=�6)   $��2q�6B   5      �� 5      $ Vertical=�6%   .+�5      �� $ 
Horizontal=�6)   .+�5   "   "  UIElements.Controls.ExButton  $��SaveBtn��6]   ���#2ab677���#18a767$ Yeni Marka Tanımlar��6�   $��Kaydet��6�   
   Image$,
 &/UI;component/Resource/Images/Save.png��6�      Image2$, &/UI;component/Resource/Images/next.png��6�   $	��326��6.  $��2,2,2,2q�6:  ��66   �� *Commands[ClickCmd]+��5   &   �� 5   *    �� 
TargetType"  60     	FavButton �� BasedOn# [ 6Z   .�5    .   ��  �� Property � {� �� Value .  6J    �� Triggers 5!   .   ^� 5"   2    ^� 
Conditions 5#   6   �� 5$   :    �� Binding 6D   �� *(Validation.HasError)+ �� ElementName$
 name�� �� Value	 False6�   .0�5&   6   ��  � {� . 6R   5'   3   5)   +   5+   #     5,   "   #��[ 66   $��	UpdateBtn��6�   ���#ffb748���#d9962d$  Marka bilgisini günceller��6  $��	Güncelle��66  $6
 0/UI;component/Resource/Images/CustomerUpdate.png��6I  $, &/UI;component/Resource/Images/next.png��6�  $	��326��6�  $��Center=�6�  $
��Left=�6�  $��2q�6�  ��6Y   �� *Commands[ClickCmd]+{�6�   �� *Model.ButtonEnable+$	 PropertyChanged=�6�  5/      �� 51      $ 
Horizontal=�6)   .+�52   "     #��[ 66   $��	DeleteBtn��6�   ���#ca6455���#ab4143$ Seçili markayı siler��6  $	��Sil��61  $.
 (/UI;component/Resource/Images/Delete.png��6?  $, &/UI;component/Resource/Images/next.png��6p  $	��656��6�  $��Center=�6�  $
��Left=�6�  $��2q�6�  ��6Y   �� *Commands[ClickCmd]+{�6�   �� *Model.ButtonEnable+$	 PropertyChanged=�6�  53      58      59      5:      5;         UI.View.Controls.Filter  5<         	SearchTag$	 Ad ��6      
FilterType$ Customer��6.   �� 5>      .+�5?      $  UIElements.Controls.ExDataGrid  -   5        $
��Grid��5?   (   &   System.Windows.Controls.DataGrid   
IsReadOnly .    AutoGenerateColumns .   �� AlternationCount$ 2��6�      AlternatingRowBackground
 �����$��0q�60  
������ $��2q�6]     HeadersVisibility$ Column=�6h  $   HorizontalScrollBarVisibility$ Hidden=�6�  ��64   �� *Model.Brands+$	 PropertyChanged=� �� SelectedItem 6~   �� *Model.Model+$	 PropertyChanged=�   Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$	 #ID��6-       Width5  /System.Windows.Controls.DataGridLengthConverter$	  10* 6Q   1	  +System.Windows.Controls.DataGridBoundColumn! 	  Binding! 6:   �� *ID+6Q     5B      $ AD��6-   $	  90* 6P   ! 69   �� *Ad+6P   "   RowHeaderTemplate" 5D      �� 5E      .R�5F      �� ���#55555c._�5G   "   �� $��0��6,   5H      5I      5K      5N      5O      5P      5Q      