   M S B A M L   `   `   `  ����G  CListViewTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ListViewTestListViewTest  5   	   A%clr-namespace:ListViewTest.PropertiesListViewTest.Properties  5   N       ListViewTest.Dialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ListViewTest     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   2local1%clr-namespace:ListViewTest.Properties  6N     � Title$  Dialog��5	   	   $	��200��6   $	��180��6%    � WindowStyle$ 
ToolWindow=�61    � DataContext 5          ListViewTest.ListViewModel  5   
    � 	Resources 5      &    ListViewTest.BoolToEnumConverter   BoolToEnumConverterKey��%   &	          5   
   6$   5      .��5      � $��0,-1,0,1q�6,    6   �� *
Selected+ � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   .+�5   
   �� $��Name:��6   $��Center=�6    $��Center=�6=   �� 5   
   $��Center=�6   $��Center=�60   $��1��6K   $��50��6[   ��6f   �� *Name+�� 5    
   $
��Age:��6   $��Center=�6   $��Center=�6<   $��0��6W   $��1��6g   �� 5!   
   $��Center=�6   $��Center=�60   $��1��6K   $��50��6[   $��1��6{   ��6f   �� *Age+6{   �� 5"   
   $��Phone:��6   $��Center=�6!   $��Center=�6>   $��0��6Y   $��2��6i   �� 5#   
   $��Center=�6   $��Center=�60   $��1��6K   $	��100��6[   $��2��6~   ��6g   �� *Phone+6~   �� 5$   
   $��Gender:��6   $��Center=�6"   $��Center=�6?   $��0��6Z   $��3��6j   	� 5%   
   $��3��6   $��1��6#   $��
20,10,50,5q�63    d� 	IsChecked 6G   ��  �� Path$ Gender� �� 	Converter# [  	 �� ConverterParameter$	 남자��
 �� Mode$
 TwoWay=�.��6�   남6�   	� 5&   
   $��3��6   $��1��6#   $��
60,10,10,5q�63    6G   �� $ Gender�# [  $	 여자��$
 TwoWay=�.��6�   여6�   �� 5'   
   -   5        $��완료��5'      $��1��6   
����� �$��Center=�6S   $��Center=�6p   $��4��6�   5(      5*      