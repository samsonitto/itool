   M S B A M L   `   `   `  ���� @  <iTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:iTooliTool      iTool.MainPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     %localclr-namespace:iTool       � Title$  iTool: Main��$	��900��$
��1200�� � 
ResizeMode$ NoResize=� � SizeToContent$ WidthAndHeight=� � 	Resources ��%    .��� .+��� $	��870�����	#FFDADADA$	��Top=�.+���  �� Orientation$ 
Horizontal=�$
��Left=�$��70��$��
0,0,-6.4,0q�$	��Top=�$
��1200�����#a0a0a0.+��� -    ��Name$ bdrProfileImage��$��1q�
���   �$��30 5 0 5q� � Cursor$
 Hand��._��� -    ��Name$ imgMainPageProfile��$
 Hand��$��Center=�$��0q�$	��Top=�����  �� ElementName$ bdrProfileImage��	 �� Path$	 ActualHeight��� -   
 ��Name$
 txtUsername��$��20 5 0 0q�$
��Wrap=�$��	User Name��$
��auto��$
��Bold"�$��18(�$��Center=�$��Center=��� -    ��Name$ txtSearchBar��$��30��$��	250 0 0 0q� �� TextWrapping$
 Wrap=�$��Search Tools��$	��250�����	#FF636262$��16(��� -    ��Name$ btnSearchTools��$��30��$��Search��$��16(�$	��100��$��10 0 0 0q��� $��iTool��$��Center=�$��Right=�$��	175 0 0 0q�$��40(�
����  �$��Black"��� $ 
Horizontal=�$	��350��$	��Top=�.+��� $
��Left=�$	��870��$��0q�$	��Top=�$	��300��.+��� $��	30 30 0 0q�$��Filters��$	��192��$��26(�$
��Bold"�$
��Left=�$��Center=��� $��	30 30 0 0q�$
��City��$
��auto��$��22(�$
��Left=�$��Center=��� -    ��Name$ cbCityFilter��$
��Left=�$��30��$��30 0 0 0q�$��Center=�$	��200��$��16(� �� SelectedIndex$ 0���� $��	30 30 0 0q�$��Tool Category��$
��auto��$��22(�$
��Left=�$��Center=��� -   $ cbToolCategory��$
��Left=�$��30��$��30 0 0 0q�$��Center=�$	��200��$��16(�$ 0���� $	��850��$	��400��.+��� $��Tools For Rent��$��0 30 0 0q�$��Center=�$��26(�$
��Bold"�&   System.Windows.Controls.DataGrid  -     Name$ dgTools��   
IsReadOnly . $��0q�   SelectionMode$ Single=�$	��Top=�   AutoGenerateColumns . ��. $
��Auto=�$
��Auto=�$	��250������ � $	��415��.+��� ��. $��Hidden=�.���� -	    ��Name$ spToolDescription��$ 
Horizontal=�$
��Left=�$	��415��$��0q�$	��Top=�$
��1200�����#e6f2ff.+��� $	��400��.+��� $��	30 30 0 0q�$
��Tool��$��26(�$
��Bold"�$
��Left=�$��Center=��� -
   $ bdrToolImage��$
��Left=�$��	30 0 90 0q�$��1q�
���   �._��� -   $ imgTool��$
��Left=�$��0q�$ ��images/no_picture_tool.png������ $ bdrToolImage��$	 ActualWidth��� $	��400��.+��� $ 
Horizontal=�$��0 40 0 0q�.+��� $��	30 20 0 0q�$��Name: ��$��16(�$
��Left=�$��Center=�$
��Bold"�$	��130���� -   $
 txbToolName�� �� Padding$ 5 0 0 0q�$��16(�$��5 20 0 0q�$��Center=��� $ 
Horizontal=�.+��� $��	30 20 0 0q�$��Conditioin: ��$��16(�$
��Left=�$��Center=�$
��Bold"�$	��130���� -   $
 txbToolCondition��$ 5 0 0 0q�$��16(�$��5 20 0 0q�$��Center=��� $ 
Horizontal=�$��0 0 0 0q�.+��� $��	30 20 0 0q�$��Price €/day: ��$��16(�$
��Left=�$��Center=�$
��Bold"�$	��130���� -   $
 txbPrice��$ 5 0 0 0q�$��16(�$��5 20 0 0q�$��Center=��� $��5 20 0 0q�$	��€��$��16(�$
��Left=�$��Center=��� $��	30 20 0 0q�$��Description: ��$��16(�$
��Left=�$��Center=�$
��Bold"�$	��130���� -   $
 txbDescription��$ 5 0 0 0q�$��16(�$
��30 0q�$
��Wrap=��� $ 
Horizontal=�.+��� $��	30 20 0 0q�$��Owner: ��$��16(�$
��Left=�$��Center=�$
��Bold"�$	��130���� -   $
 txbOwner��$ 5 0 0 0q�$��16(�$��5 20 0 0q�$��Center=��� $ 
Horizontal=�.+��� $��	30 20 0 0q�$��Phone number: ��$��16(�$
��Left=�$��Center=�$
��Bold"�$	��130���� -   $
 	txbNumber��$ 5 0 0 0q�$��16(�$��5 20 0 0q�$��Center=��� $	��400��.+��� $ 
Horizontal=�$��0 40 0 0q�.+��� $��	30 20 0 0q�$��	Rent for:��$��16(�$
��Left=�$��Center=�$
��Bold"��� -   $ txtDays��$��30��$��60��$��	10 20 0 0q�$��Center=��� $��5 20 0 0q�$
��days��$��16(�$
��Left=�$��Center=�$
��Bold"��� $ 
Horizontal=�.+��� $��	30 20 0 0q�$��Total price:��$��16(�$
��Left=�$��Center=�$
��Bold"��� -   $
 txbTotalPrice��$��	10 20 0 0q�$��16(�$��Center=��� -   $��30��$��
30 20 20 0q�$	��100��$
��Left=�$
��Rent��$��16(��� -   $ 
btnComment��$��30��$��
30 20 20 0q�$	��100��$
��Left=�$��Comment��$��16(��� -   $ txbMessages��$s��mHere you can see all tools that are available for rent. Use filters or the search bar to find a tool for you.��$��16(�$��37��$��Center=�$��	10 0 10 0q�