   M S B A M L   `   `   `  ����G  CListViewTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ListViewTestListViewTest  5   	   A%clr-namespace:ListViewTest.PropertiesListViewTest.Properties  5   N       ListViewTest.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ListViewTest     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   2local1%clr-namespace:ListViewTest.Properties  6N     � Title$  
MainWindow��5	   	   $	��500��6   $
��1250��6)   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closing��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *
save_xml+6C   5       � DataContext 5          ListViewTest.ListViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��* �6   �� 5      $��25 �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5    
   �� $��1��6   $��1q�6!   
���   �65   �� 5!   
   $��0��6   $��1q�6!   
���   �65   �� 5"   
   $��0��6   $��1��6!   $��1q�6.   
���   �6B   �� 5#   
   $��1��6   $��1��6!   $��1q�6.   
���   �6B   �� 5$   
   $��0��6   $��2��6!   $��1q�6.   
���   �6B   �� 5%   
   $��1��6   $��2��6!   $��1q�6.   
���   �6B   �� 5'   
   $��Stretch=�6   $��Center=�62   $"��ListView DataBinding Example��6M    �� Padding$ 10q�6q   �� 5(   
   $��Stretch=�6   $��1��62   $��Center=�6B   $��ListView Filter��6]   $ 10q�6t   �� 5*   
   -   5        $��	list_view��5*   s   $��1��6�   $��0��6�   $��10q�6�   
���������6   �� *Items+	 �� SelectedIndex	 61   �� *Index+
 �� SelectedItem
 6Q   �� *
Selected+ 5+        5,      $ MouseDoubleClick��6!   . 5-         5.      �� *ListItemClick+5/       �� View 51      �� 52      .P�54      �� $
��Name��6%    �� Width$	 100��63    �� DisplayMemberBinding 6?   �� *Name+�� 55      $	��Age��6%   $	 100��62    6>   �� *Age+�� 56      $��PhoneNumber��6%   $	 270��6:    6F   �� *Phone+�� 57      $��Gender��6%   $ 50��65    �� CellTemplate 58      �� 59      .R�5:   "   �� $��gender��63   $��30��6(   63    �� Triggers 5;   "   �� 5<   &    �� Value$ 여자��6M    �� Binding 62   �� *Gender+.a�5=   *   ��  �� 
TargetName$ gender��61    �� Property � �� �� Value$ /Resources/women.bmp��6W   5>   '   �� 5?   &   $ 남자��6M    62   �� *Gender+.a�5@   *   �� $ gender��61    � ��$ /Resources/men.bmp��6W   5A   '   5C      5E      �� 5F      $��Delete��6%   $ 70��65    5G      �� 5H      .R�5I   "   �� $��50��6*   $��20��65   $��삭제��6�    6A   ��  �� RelativeSource ��  �� AncestorType" � �� Path$ DataContext���6�   �� *
DeleteList+5J      5L      5M       � 	Resources 5P       �� 
TargetType �� Triggers P� Property P� Value��%�   '��       �� 5Q      " ��6    5R      P� 5S       �@J�IsKeyboardFocusWithin . . �5T      ��  �@��
IsSelected . 6;   5U      .�5W      -   5        5X      5Y      5Z      �� 5[   
   $	��New��6   $��Right=�6   $��2��6;   $��Bottom=�6H   $��75��6c   $��0,0,80,0q�6�      	RedButton#���   6�   ��6n   �� *
commandNew+6�   �� 5\   
   $	��Add��6   $��Right=�6   $��2��6;   $��Bottom=�6H   $��75��6c     
BlueButton#���  6�   ��6n   �� *
commandAdd+6�   �� 5]   
   $��75��6   $��Right=�6   $��2��68   $��Bottom=�6E   $��Load XML��6x   $��	0,5,160,0q�6�     GreenButton#���  6�   ��6`   �� *xml+6�   �� 5^   
   $	��남��6   $��1��6   $��1��60   $��40,80,530,300q�6=   ��6T   �� *	manfilter+�� 5_   
   $	��여��6   $��1��6   $��1��60   $��40,100,530,280q�6=   ��6U   �� *womanfilter+�� 5`   
   $��20세미만��6   $��1��6#   $��1��64   $��40,120,500,260q�6A   ��6Y   �� *childfilter+�� 5a   
   $��20세이상��6   $��1��6#   $��1��64   $��40,140,500,240q�6A   ��6Y   �� *adultfilter+�� 5b   
   $��이씨��6   $��1��6    $��1��61   $��40,160,500,220q�6>   ��6V   �� *	leefilter+�� 5c   
   $��김씨��6   $��1��6    $��1��61   $��40,180,500,200q�6>   ��6V   �� *	kimfilter+5e      5g      