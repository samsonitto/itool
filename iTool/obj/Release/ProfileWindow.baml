   M S B A M L   `   `   `  ���� @  <iTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:iTooliTool      iTool.ProfileWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     %localclr-namespace:iTool       � Title$  iTool: User Profile��$	��800��$
��1200�� � 
ResizeMode$ NoResize=� � SizeToContent$ WidthAndHeight=� � 	Resources  �� 
TargetType �� Property �� Value��%+   '��       �� " ��.���  � |� .  .��� .+��� $	��Top=�$	��770��.+��� -    ��Name$ lblUserProfile��$��iTool: User Profile��$��35(�$
��Left=�$
��Bold"����#aaaaaa$��20 5 0 5q�$��Courier New)���  �� Orientation$ 
Horizontal=�.+�� $	��680��.+��� ��. $��Hidden=�.���� $	��300��$	��680��
�������$��Stretch=�.+��� -   	 ��Name$	 bdrProfileImg��$	��200��$��
50 50 50 0q�$��1q�
���   �._��� -   
 ��Name$
 imgUserProfile������  �� ElementName$ bdrProfileImg�� �� Path$ ActualWidth��� -    ��Name$ 	txbUserID��$
��Left=�$��20��$��	75 20 0 0q�$��18(�$��Medium"��� -   $ txbAvgRating��$
��Left=�$��20��$��	75 0 0 30q�$��18(�$��Medium"��� -    ��Name$ 
btnAddTool��$	��150��$��30��$��
Add a tool��$��5q��� -   $ btnEditProfile��$	��150��$��30��$��Edit profile��$��5q��� -   $ btnDeleteProfile��$	��150��$��30��$��Delete profile��$��5q��� -	   $ btnBackToMainPage��$	��150��$��30��$��Back to main page��$��5q��� -
   $ 	btnLogout��$	��150��$��30��$��Log out��$��5q�� $	��680��.+��� ��. $��Hidden=�.���� $	��600��$	��680��.+��� $��My Tools��$��Center=�$��26(�$
��Bold"�$��0 30 0 0q��� $
��Auto=�$
��Auto=�.��&   System.Windows.Controls.DataGrid  -     Name$ 	dgMyTools��$
��20 0q�$	��250��   
IsReadOnly .    SelectionMode$ Single=��� $��My Rented Tools��$��Center=�$��26(�$
��Bold"�$��0 30 0 0q��� $
��Auto=�$
��Auto=�.��  -   $ dgRentedToolsByMe��$
��20 0q�$	��250�� . $ Single=��� $��My Transactions��$��Center=�$��26(�$
��Bold"�$��0 30 0 0q��� $
��Auto=�$
��Auto=�.��  -   $ dgMyTransactions��$
��20 0q�$	��250�� . $ Single=�� $	��680��.+��� ��. $��Hidden=�.���� $	��300�����#e6f2ff$	��680��.+��� -   $ 	lblHeader��$��	30 30 0 0q�$
��Tool��$��26(�$
��Bold"�$
��Left=�$��Center=��� -   $	 bdrToolProfile��$��1q�
���   �$	��200��$��	30 20 0 0q�$
��Left=�._��� -   $
 imgToolProfile������ $ bdrToolProfile��$ ActualWidth��� -   $ 
lblHeader1��$��	30 20 0 0q�$��Name: ��$��16(�$
��Left=�$��Center=�$
��Bold"��� -   $ txbToolNameProfile��$��16(�$
��30 0q�$
��Wrap=��� -   $ 
lblHeader2��$��	30 20 0 0q�$��Conditioin: ��$��16(�$
��Left=�$��Center=�$
��Bold"��� -   $ txbToolConditionProfile��$��16(�$��30 0 0 0q��� -   $ 
lblHeader3��$��	30 20 0 0q�$��Price €/day: ��$��16(�$
��Left=�$��Center=�$
��Bold"��� -   $ txbPriceProfile��$��16(�$
��30 0q��� -   $ 
lblHeader4��$��	30 20 0 0q�$��Description: ��$��16(�$
��Left=�$��Center=�$
��Bold"��� -   $ txbDescriptionProfile��$��16(�$
��30 0q�$
��Wrap=��� -    ��Name$ txbMessagesProfile��$��16(�$��40��$��Center=�$��	10 0 10 0q�